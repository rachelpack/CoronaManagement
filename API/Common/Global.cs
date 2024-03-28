using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Global
    {

    }
    public class Result
    {
        public Status SaveStatus { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

    }
  
    public enum Status
    {
        Success = 1,
        Fail = 2
    }
}

