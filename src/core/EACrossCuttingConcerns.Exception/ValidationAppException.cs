using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EACrossCuttingConcerns.Exception
{
    public class ValidationAppException : System.Exception
    {
        public IReadOnlyDictionary<string, string[]> Errors { get; }
        public ValidationAppException(IReadOnlyDictionary<string, string[]> errors)
            :base("One or more validation errors occurred")
            => Errors = errors;
    }
}
