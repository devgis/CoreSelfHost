using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

namespace CoreSelfHost
{
    public class HomeController
    {
        [HttpPost("/post", Order = 0)]
        public string Index(string data)
        {
            return data;
            //if (data != null && data.name != null)
            //{
            //    return $"Hello {data.name}";
            //}
            //else
            //{
            //    return "null";
            //}
            
        }

        [HttpGet("/{name}", Order = 1)]
        public string Index2(string name)
        {
            
            return $"Hello {name}";
        }

        

        [HttpGet("/{name}/{value}", Order = 0)]
        public string Index(string name, string value)
        {
            return $"Hello {name} ---{value}";
        }

        //[HttpGet("/{name}?{value}", Order = 0)]
        //public string Index2(string name, string value)
        //{
        //    return $"Hello {name} ---{value}";
        //}
    }
}
