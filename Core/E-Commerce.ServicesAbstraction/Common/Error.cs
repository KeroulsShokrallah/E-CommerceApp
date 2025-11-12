using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServicesAbstraction.Common
{
    public partial class Error
    {
        public string Code { get;  }
        public string Descreption { get;  }
            
        public ErrorType Type { get; }
        private Error(string code , string descreption , ErrorType type) {
            
            Code = code;
            Descreption = descreption;
            Type = type;

            
        }

        public static Error Failure (string code ="General.Failure" , string descreption ="A failure has occurred")
        {
            return new Error(code, descreption, ErrorType.Failure);
        }
        public static Error Validation(string code = "General.Validation", string descreption = "A Validation has occurred")
        {
            return new Error(code, descreption, ErrorType.Validation);
        }
        public static Error NotFound(string code = "General.NotFound", string descreption = "A NotFound has occurred")
        {
            return new Error(code, descreption, ErrorType.NotFound);
        }
        public static Error Conflict(string code = "General.Conflict", string descreption = "A Conflict has occurred")
        {
            return new Error(code, descreption, ErrorType.Conflict);
        }
        public static Error UnAuthorized(string code = "General.UnAuthorized", string descreption = "A UnAuthorized has occurred")
        {
            return new Error(code, descreption, ErrorType.UnAuthorized);
        }
    }
}
