using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EACrossCuttingConcerns.Generic
{
    public class EAApiResponse:IEAApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null;
        public object Data { get; set; }

        public EAApiResponse(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
