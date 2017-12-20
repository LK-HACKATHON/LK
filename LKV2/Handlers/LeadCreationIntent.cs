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
            //commonModel.Response.Ssml = $"Perfect, Lead { person.Value}  has been Created for the Inquiry Date  {date.Value}  under {community.Value} Community. Your Confirmation Code is <say-as interpret-as=\"spell-out\">1258452</say-us>. Thank you. Have a Nice Day!";

            commonModel.Response.Text = $"Perfect, Lead { person.Value}  has been Created for the Inquiry Date {date.Value} under {community.Value} Community.  Thank you. Have a Nice Day!";

            //commonModel.Response.Card = new Card
            //{
            //    Title = "MatrixCare Marketing Lead Creation",
            //    Text = $"Lead { person.Value}  has been Created for the Inquiry Date {date.Value} under {community.Value} Community. Your Confirmation Code is 1258452. "
            //};

            commonModel.Session.EndSession = true;

            return commonModel;
        }
    }
}