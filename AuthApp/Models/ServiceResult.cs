using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Models
{
    public class ServiceResult
    {
        public bool Success { get; set; } = false;
        public Error Error { get; set; } = new Error();
    }

    public class ServiceResult<T> : ServiceResult where T : BaseEntity
    {
        public T Result { get; set; }
    }

    public class Error
    {
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }

}
