using LKV2.Helpers;
using LKV2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKV2.Handlers
{
    public class LeadCreationIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {

            var date = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "date");
            var person = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "person");
            var community = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "community");
            var classification = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "classification");
            var caresetting = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "caresetting");


            //commonModel.Response.Ssml = $"<speak>Perfect, Lead { person.Value}  has been Created for the Inquiry Date  {date.Value}  under {community.Value} Community. Your Confirmation Code is <say-as interpret-as=\"spell-out\">hello</say-as>. Thank you. Have a Nice Day!</speak>";
            if (string.IsNullOrWhiteSpace(person.Value) || string.IsNullOrWhiteSpace(community.Value) || string.IsNullOrWhiteSpace(date.Value) || string.IsNullOrWhiteSpace(classification.Value) || string.IsNullOrWhiteSpace(caresetting.Value))
            {
                return commonModel;
            }

            if (commonModel.Request.State == "COMPLETED")
            {
                var resObj = LeadCreationHelper.CreateLead(person.Value, "DEMO", "12/20/2017", "7262", "MC");
            }


            commonModel.Response.Text = $"Perfect, Lead { person.Value}  has been Created for the Inquiry Date {date.Value} under {community.Value} Community.  Thank you. Have a Nice Day!";

            commonModel.Response.Card = new Card
            {
                Title = "MatrixCare Marketing Lead Creation",
                Text = $"Lead { person.Value}  has been Created for the Inquiry Date {date.Value} under {community.Value} Community. Your Confirmation Code is 1258452. "
            };

            commonModel.Session.EndSession = true;



            return commonModel;
        }
    }
}