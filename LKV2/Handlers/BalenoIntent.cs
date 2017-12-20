using LKV2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKV2.Handlers
{
    public class BalenoIntent
    {

        internal static CommonModel Process(CommonModel commonModel)
        {

            commonModel.Response.Text = "Welcome to MatrixCare India Private Limited";

            return commonModel;

        }
    }
}