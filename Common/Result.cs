using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFlowConsole.Common
{
    public class Result
    {
        public bool Success { get; }
        public string Error { get; }

        public bool IsFailure => !Success;

        protected Result(bool success, string error)
        {
            Success = success;
            Error = error;
        }
        
        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }

        public static Result Fail (string error)
        {
            return new Result(false, error);
        }
    }

    public class Result<T> : Result
    {
        public T? Value { get; }

        private Result(bool success, T? value, string error) : base(success, error)
        {
            Value = value;
        }

        public static new Result<T> Ok(T value)
        {
            return new Result<T>(true, value, string.Empty);
        }

        public static new Result<T> Fail(string error)
        {
            return new Result<T>(false, default, error);
        }
    }

}
