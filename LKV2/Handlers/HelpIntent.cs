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

            commonModel.Response.Text = "How Can i Help you. if you want to create a lead, Say, \"Create a Lead\".!  if you want to Get Activity, Say, \"Get Activity\".!";
            commonModel.Response.Prompt = "if you want to create a lead, Say, \"Create a Lead\".!  if you want to create a lead, Say, \"Create a Lead\".!";
            commonModel.Session.EndSession = false;
            return commonModel;

        }
    }
}