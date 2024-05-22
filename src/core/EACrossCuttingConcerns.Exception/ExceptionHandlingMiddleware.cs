using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EACrossCuttingConcerns.ExceptionLogging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace EACrossCuttingConcerns.Exception
{
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context,IExceptionLogService exceptionLogService)
        {
            try
            {
                await next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex,exceptionLogService);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, System.Exception exception,IExceptionLogService exceptionLogService)
        {
            // Kendi eklediğimiz exception'lardan biri ise ona göre bir HttpStatusCode yazdık.
            // Custom exception'lar artırılarak burası genişletilebilir.
            var statusCode = exception switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                //UnauthorizedException => (int)HttpStatusCode.Unauthorized,
                //ValidationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            // ApiResponse oluşturulur.
            var response = new ApiResponse<object>
            {
                // Hata fırlatıldığı için IsSuccess "false" olarak ayarlanır.
                IsSuccess = false,
                Message = exception.Message,
                StatusCode = statusCode,
                // Yakalanan hata oluşturduğumuz ApiResponse içinde bulunan Exception
                // alanına oluşturularak atanır.            
                Exception = new ExceptionModel
                {
                    // Yakalanan hatanın hangi hata olduğu, hata mesajı ve stack trace 
                    // burada atanır.
                    ExceptionType = exception.GetType().Name,
                    ExceptionMessage = exception.Message,
                    StackTrace = exception.StackTrace
                }
            };
            // Burada yakalanan exception database'deki 'exceptionlogs' tablosuna loglanır.
            ExceptionLog exceptionLog = new(response.Message, exception.StackTrace, exception.GetType().Name,response.StatusCode);
            await exceptionLogService.Add(exceptionLog);

            // Response Json formatına çevrilir ve WriteAsync fonksiyonu ile 
            // HttpContext'in response'u doldurulur.
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(payload);
        }
    }
}
