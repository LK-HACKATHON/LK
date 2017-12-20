using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using LKV2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LKV2.Controllers
{
    public class HomeController : ApiController
    {

        public SkillResponse Post(SkillRequest skillRequest)
        {
            try
            {

                var commmonModel = CommonModelMapper.AlexaToCommonModel(skillRequest);



                var responseText = string.Empty;

                var intentRequest = skillRequest.Request as IntentRequest;

                if (intentRequest != null)
                {

                    switch (intentRequest.Intent.Name)
                    {
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
                            //case "AMAZON.CancelIntent":
                            //    commmonModel = Handlers.CancelIntent.Process(commmonModel);
                            //    break;
                            //case "AMAZON.StopIntent":
                            //    commmonModel = Handlers.CancelIntent.Process(commmonModel);
                            //    break;

                    }

                    return CommonModelMapper.CommmonModelToAlexa(commmonModel);
                }
                else
                {

                    commmonModel = Handlers.WelcomeIntent.Process(commmonModel);

                    return CommonModelMapper.CommmonModelToAlexa(commmonModel);
                }

                //var response = new SkillResponse()
                //{
                //    Version = "1.0",
                //    Response = new ResponseBody()
                //};

                //response.Response.OutputSpeech = new SsmlOutputSpeech()
                //{
                //    // Ssml = "<speak>Today, you dont have any Activities</speak>"

                //    Ssml = "<speak>Today, you dont have 2 Activities. 1. </speak>"
                //};

                //return response;



            }
            catch (Exception ex)
            {
                // ErrorHelper.CreateErrorMessage(ex);

                var response = new SkillResponse()
                {
                    Version = "1.0",
                    Response = new ResponseBody()
                };

                response.Response.OutputSpeech = new SsmlOutputSpeech()
                {
                    // Ssml = "<speak>Today, you dont have any Activities</speak>"

                    Ssml = $"<speak>{ex.Message}</speak>"
                };

                return response;
            }
        }

        //public SkillResponse Post(SkillRequest skillRequest)
        //{
        //    var response = new SkillResponse()
        //    {
        //        Version = "1.0",
        //        Response = new ResponseBody()
        //    };

        //    response.Response.OutputSpeech = new SsmlOutputSpeech()
        //    {
        //        // Ssml = "<speak>Today, you dont have any Activities</speak>"

        //        Ssml = "<speak>Welcome to MatrixCare Marketing!. What Action you want to do? </speak>"
        //    };

        //    return response;
        //}
    }
}
