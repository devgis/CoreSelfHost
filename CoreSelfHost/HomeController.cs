using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CoreSelfHost
{
    public class HomeController
    {
        [HttpGet("/{name}",Order =0)]
        public string Index(string name)
        {
            return $"Hello {name}";
        }

        [HttpGet("/{name}/{value}", Order = 0)]
        public string Index(string name,string value)
        {
            return $"Hello {name} ---{value}";
        }
    }
}
