using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EACrossCuttingConcerns.Exception
{
    public class AuthorizationException : System.Exception
    {
        public AuthorizationException() { }

        public AuthorizationException(string? message)
            : base(message) { }

        public AuthorizationException(string? message, System.Exception? innerException)
            : base(message, innerException) { }
    }
}
