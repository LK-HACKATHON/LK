using LKV2.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LKV2.Controllers
{
    public class TestController : ApiController
    {
        public string Get()
        {
           var s= ActivityIntent.GetActivityResult();
            return "Hello Alexa";
        }
    }
}
