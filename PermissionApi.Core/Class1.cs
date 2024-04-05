using System;
using System.Collections.Generic;
using System.Linq;

namespace PermissionApi.Core
{
    public interface IOperationResult
    {
        bool IsSuccess { get; }
        string Message { get; }
        IEnumerable<string> Messages { get; set; }
    }

    public class OperationResult : IOperationResult
    {
        public bool IsSuccess => Messages.Any();
        public string Message => AddSuccessMessage();
        public IEnumerable<string> Messages { get; set; }
        public OperationResult()
        {

        }
        public string AddSuccessMessage()
        {
            if (IsSuccess)
            {
                return "Operation Completed Sucessfully";
            }
            return "There are Errors that need to be fixed";
        }
    }
}
