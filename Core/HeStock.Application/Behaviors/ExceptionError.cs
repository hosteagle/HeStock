﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Behaviors
{
    public class ExceptionError
    {
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
    }
}
