using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class JsonDataModel
    {
        public string data { get; set; }
    }

    public class JsonDataResponseModel
    {
        public string code { get; set; }
        public string description { get; set; }
        public string data { get; set; }
    }

    public class JsonTimeDataResponseModel
    {
        public string code { get; set; }
        public string description { get; set; }
        public string data { get; set; }
    }
}