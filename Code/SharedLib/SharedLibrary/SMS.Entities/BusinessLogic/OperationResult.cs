using SMS.Entities.DataInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities.BusinessLogic
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; } = true;
        public OperationErrorCode ErrorCode { get; set; } = 0;
        public Exception Exception { get; set; } 
    }

    public class OperationResult<T> :OperationResult
    {
        public T Result { get; set; }
    }
}
