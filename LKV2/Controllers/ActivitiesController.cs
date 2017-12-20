using Alexa.NET.Request;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LKV2.Controllers
{
    public class ActivitiesController : ApiController
    {

        public SkillResponse Post(SkillRequest skillRequest)
        {
            var response = new SkillResponse()
            {
                Version = "1.0",
                Response = new ResponseBody()
            };




            response.Response.OutputSpeech = new SsmlOutputSpeech()
            {
                // Ssml = "<speak>Today, you dont have any Activities</speak>"

                Ssml = "<speak>Today, you dont have 2 Activities. 1. </speak>"
            };

            return response;
        }
    }
}
