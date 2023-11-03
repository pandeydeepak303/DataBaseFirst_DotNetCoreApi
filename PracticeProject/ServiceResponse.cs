using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeProject
{
    public class ServiceResponse
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public string version { get; set; }
        public object data { get; set; }
        public bool Success { get; internal set; }
    }
}