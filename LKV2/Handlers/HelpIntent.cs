using LKV2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKV2.Handlers
{
    public class HelpIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            var responseText = "if you want to create a lead, Say, \"Create a Lead\".!  if you want to Get Scheduled Activity, Say, \"Get Scheduled Activity\".!  if you want to Get Pending Activity, Say, \"Get Pending Activity\".!";
            commonModel.Response.Text = "How Can i Help you. " + responseText;
            commonModel.Response.Prompt = responseText;
            commonModel.Session.EndSession = false;
            return commonModel;

        }
    }
}