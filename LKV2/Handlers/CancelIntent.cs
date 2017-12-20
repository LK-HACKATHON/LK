using LKV2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKV2.Handlers
{
    public class CancelIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {

            commonModel.Response.Text = "Ok. All Cancelled. Have a Wonderful Day!";
            commonModel.Session.EndSession = true;
            return commonModel;

        }
    }
}