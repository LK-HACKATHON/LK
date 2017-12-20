using LKV2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKV2.Handlers
{
    public class WelcomeIntent
    {

        internal static CommonModel Process(CommonModel commonModel)
        {
            //if (commonModel.Request.Channel == "Alexa")
            //{
            //    commonModel.Response.Text = $"Welcome to MatrixCare Marketing, if you want to create a lead, Say, \"Create a Lead\".!";
            //    commonModel.Response.Prompt = "If you want to Create a Lead, say, \"Create a Lead\".";

            //}
            //else
            //{
            //    commonModel.Response.Text = $"Welcome to MatrixCare Marketing, if you want to create a lead, Say or Type, \"Create a Lead\".!";
            //    commonModel.Response.Prompt = "If you want to Create a Lead, Say or Type, \"Create a Lead\".";

            //}

            commonModel.Response.Text = $"Welcome to MatrixCare Marketing!. What Action you want to do?";
            commonModel.Response.Prompt = "If you want any Help about Actions, say, \"Help\".";

            commonModel.Session.EndSession = false;
            return commonModel;

        }
    }
}