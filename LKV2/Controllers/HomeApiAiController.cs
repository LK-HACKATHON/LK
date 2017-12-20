using ApiAiSDK.Model;
using LKV2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LKV2.Controllers
{
    public class HomeApiAiController : ApiController
    {
        public dynamic Post(AIResponse aiResponse)
        {


            var commmonModel = CommonModelMapper.ApiAiToCommonModel(aiResponse);

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

            //var intentRequest = skillRequest.Request as IntentRequest;

            switch (commmonModel.Request.Intent)
            {
                case "WelcomeIntent":
                    commmonModel = Handlers.HomeIntent.Process(commmonModel);
                    break;
                case "HomeIntent":
                    commmonModel = Handlers.HomeIntent.Process(commmonModel);
                    break;
                case "PendingActivityIntent":
                    commmonModel = Handlers.PendingAcivityIntent.Process(commmonModel);
                    break;
                case "ScheduledActivityIntent":
                    commmonModel = Handlers.ScheduledActivityIntent.Process(commmonModel);
                    break;
                case "LeadCreationIntent":
                    commmonModel = Handlers.LeadCreationIntent.Process(commmonModel);
                    break;
                case "HelpIntent":
                    commmonModel = Handlers.HelpIntent.Process(commmonModel);
                    break;
                case "AMAZON.HelpIntent":
                    commmonModel = Handlers.HelpIntent.Process(commmonModel);
                    break;
            }
            // commmonModel = Handlers.WelcomeIntent.Process(commmonModel);




            var resoponeNew = CommonModelMapper.CommonModelToApiAi(commmonModel);


            return resoponeNew;
            //var responseOld = new
            //{
            //    speech = "Welcome To MatrixCare. If you want to Create a Lead Say Create a Lead(s) " + commmonModel.Request.Intent,
            //    displayText = "Welcome To MatrixCare. If you want to Create a Lead Say Create a Lead" + commmonModel.Request.Intent
            //};
            //return responseOld;

        }

        public string Get()
        {
            return "Home API. AI";
        }

    }
}
