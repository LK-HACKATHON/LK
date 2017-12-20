using LKV2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKV2.Handlers
{
    public class HomeIntent
    {

        internal static CommonModel Process(CommonModel commonModel)
        {
            commonModel.Response.Text = $"Welcome to MatrixCare!. What Action you want to do?";
            commonModel.Response.Prompt = "If you want any Help about Actions, say, \"Help\".";

            commonModel.Session.EndSession = false;
            return commonModel;

        }
    }
}