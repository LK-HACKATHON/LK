using LKV2.Handlers;
using LKV2.Helpers;
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
            //var s = LeadCreationHelper.CreateLead("Gokul Kumer Alexa 1", "DEMO", "12/12/2017", "7262" ,"MC");
            var s1 = ActivityHelper.GetPendingActivityResult();
            return s1;
        }
    }
}
