using LKV2.Helpers;
using LKV2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKV2.Handlers
{
    public class ScheduledActivityIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            //commonModel.Response.Ssml = "<speak>Today, you have 2 Activities. </speak>";
            commonModel.Response.Text = ActivityHelper.GetActivityResult();// "Today, you have 2 Activities.";
            //commonModel.Response.Prompt = "If you want to any Help about Actions, say, \"Help\".";
            commonModel.Session.EndSession = true;
            return commonModel;

        }
    }
}