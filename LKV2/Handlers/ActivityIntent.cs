﻿using LKV2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Flurl.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;
using LKV2.Helpers;

namespace LKV2.Handlers
{
    public class ActivityIntent
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