using Core.EADomain;

namespace Core.EACrossCuttingConcerns.ExceptionLogging
{
    public class ExceptionLog(string message, string stackTree, string type,int statusCode) : EAEntity
    {
        public string Message { get; set; } = message;
        public string StackTree { get; set; } = stackTree;
        public string Type { get; set; } = type;
        public int StatusCode { get; set; } = statusCode;
    }
}
