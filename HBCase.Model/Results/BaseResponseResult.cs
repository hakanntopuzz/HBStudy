using System.Collections.Generic;
using System.Linq;

namespace HBCase.Model.Results
{
    public class BaseResponseResult<TData> where TData : class
    {
        public BaseResponseResult()
        {
            Errors = new List<string>();
        }

        public bool IsSuccess => !Errors.Any();
        public List<string> Errors { get; set; }
        public TData Result { get; set; }
    }

    public class BaseResponseResult
    {
        public BaseResponseResult()
        {
            Errors = new List<string>();
        }

        public bool IsSuccess => !Errors.Any();
        public List<string> Errors { get; set; }
    }
}