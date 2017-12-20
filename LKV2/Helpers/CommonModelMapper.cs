﻿using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Alexa.NET.Response.Directive;
using ApiAiSDK.Model;
using LKV2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKV2.Helpers
{
    public class CommonModelMapper
    {

        internal static CommonModel AlexaToCommonModel(SkillRequest skillRequest)
        {
            var commonModel = new CommonModel()
            {
                Id = skillRequest.Request.RequestId

            };

            var requestType = skillRequest.GetRequestType();

            commonModel.Request.Channel = "Alexa";

            if (requestType == typeof(IntentRequest))
            {
                var intentRequest = skillRequest.Request as IntentRequest;

                commonModel.Request.Intent = intentRequest.Intent.Name;
                commonModel.Request.State = intentRequest.DialogState;
                if (intentRequest.Intent.Slots != null)
                    commonModel.Request.Parameters = intentRequest.Intent.Slots.ToList().ConvertAll(s => new KeyValuePair<string, string>(s.Value.Name, s.Value.Value));
            }

            else if (requestType == typeof(LaunchRequest))
            {
                var intentRequest = skillRequest.Request as IntentRequest;
                if (intentRequest != null)
                {
                    commonModel.Request.State = intentRequest.DialogState;
                }
                commonModel.Request.Intent = "HomeIntent";
            }

            else if (requestType == typeof(SessionEndedRequest))
            {
                return null;
            }

            return commonModel;
        }

        internal static SkillResponse CommmonModelToAlexa(CommonModel commonModel)
        {
            var response = new SkillResponse()
            {
                Version = "1.0",
                Response = new ResponseBody()
            };


            if (commonModel.Request.State == "STARTED" || commonModel.Request.State == "IN_PROGRESS")
            {
                var directive = new DialogDelegate
                {
                    UpdatedIntent = new Intent
                    {
                        Name = commonModel.Request.Intent,
                        Slots = commonModel.Request.Parameters?.ToDictionary(p => p.Key, p => new Slot { Name = p.Key, Value = p.Value })

                    }

                };
                if (response.Response.Directives != null)
                {
                    response.Response.Directives.Add(directive);
                }

                response.Response.ShouldEndSession = false;
                return response;
            }

            if (string.IsNullOrWhiteSpace(commonModel.Response.Ssml))
            {
                response.Response.OutputSpeech = new PlainTextOutputSpeech()
                {
                    Text = commonModel.Response.Text
                };
            }
            else
            {
                response.Response.OutputSpeech = new SsmlOutputSpeech
                {
                    Ssml = "<speak>" + commonModel.Response.Ssml + "</speak>"
                };
            }

            if (commonModel.Response.Card != null)
            {
                response.Response.Card = new SimpleCard
                {
                    Title = commonModel.Response.Card.Title,
                    Content = commonModel.Response.Card.Text
                };
            }




            if (!string.IsNullOrWhiteSpace(commonModel.Response.Prompt))
            {
                response.Response.Reprompt = new Reprompt { OutputSpeech = new PlainTextOutputSpeech() { Text = commonModel.Response.Prompt } };
            }

            response.Response.ShouldEndSession = commonModel.Session.EndSession;


            return response;
        }



        internal static CommonModel ApiAiToCommonModel(AIResponse aiResponse)
        {
            var commonModel = new CommonModel()
            {
                Id = aiResponse.Id

            };

            commonModel.Session.Id = aiResponse.SessionId;
            commonModel.Request.Channel = aiResponse.Result.Source;
            commonModel.Request.Intent = aiResponse.Result.Metadata.IntentName;
            commonModel.Request.State = aiResponse.Result.ActionIncomplete ? "IN_PROGRESS" : "COMPLETED";
            commonModel.Request.Parameters = aiResponse.Result.Parameters.ToList()
                .ConvertAll(p => new KeyValuePair<string, string>(p.Key, p.Value.ToString()));


            return commonModel;
        }

        internal static dynamic CommonModelToApiAi(CommonModel commonModel)
        {

            return new
            {
                speech = (string.IsNullOrWhiteSpace(commonModel.Response.Ssml)) ? commonModel.Response.Text : "<speak>" + commonModel.Response.Ssml + "</speak>",
                displayText = commonModel.Response.Text,
                data = new { google = new { expectUserResponse = !commonModel.Session.EndSession } },
                source = "LKV1"
            };

        }

    }
}