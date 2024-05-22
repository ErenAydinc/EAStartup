using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EACrossCuttingConcerns.Exception
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public ExceptionModel? Exception { get; set; }
        public ApiResponse()
        {
            IsSuccess = true;
        }
    }
}
