using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using LKV2.Helpers;
using LKV2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LKV2.Controllers
{
    public class SayMatrixCareController : ApiController
    {
        public SkillResponse Post(SkillRequest skillRequest)
        {


            var commmonModel = CommonModelMapper.AlexaToCommonModel(skillRequest);

            //var response = new SkillResponse()
            //{
            //    Version = "1.0",
            //    Response = new ResponseBody()
            //};

            //response.Response.OutputSpeech = new SsmlOutputSpeech()
            //{
            //    Ssml = "<speak>Welcome to MatrixCare India Pvt Ltd</speak>"
            //};

            var responseText = string.Empty;

            var intentRequest = skillRequest.Request as IntentRequest;

            switch (intentRequest.Intent.Name)
            {
                case "WelcomeIntent":
                    commmonModel = Handlers.WelcomeIntent.Process(commmonModel);
                    break;
                case "LeadCreationIntent":
                    commmonModel = Handlers.LeadCreationIntent.Process(commmonModel);
                    break;
                case "AMAZON.HelpIntent":
                    commmonModel = Handlers.HelpIntent.Process(commmonModel);
                    break;
                case "AMAZON.CancelIntent":
                    commmonModel = Handlers.CancelIntent.Process(commmonModel);
                    break;
                case "AMAZON.StopIntent":
                    commmonModel = Handlers.CancelIntent.Process(commmonModel);
                    break;

            }
            // commmonModel = Handlers.WelcomeIntent.Process(commmonModel);




            return CommonModelMapper.CommmonModelToAlexa(commmonModel);
        }
    }
}
