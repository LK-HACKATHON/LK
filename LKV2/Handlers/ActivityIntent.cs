using LKV2.Models.Common;
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

namespace LKV2.Handlers
{
    public class ActivityIntent
    {

        internal static CommonModel Process(CommonModel commonModel)
        {
            //commonModel.Response.Ssml = "<speak>Today, you have 2 Activities. </speak>";
            commonModel.Response.Text = GetActivityResult();// "Today, you have 2 Activities.";
            //commonModel.Response.Prompt = "If you want to any Help about Actions, say, \"Help\".";
            commonModel.Session.EndSession = true;
            return commonModel;

        }

        internal async static void GetActivities()
        {
            var url = "http://12.33.163.33:18502/api/leads/60C4993AF44E7C09E0530314960AAA00/activities";
            var response = await url.WithHeader("Content-Type", "application/json").GetAsync();
        }

        internal static string GetActivityResult()
        {
            var activityString = new StringBuilder();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://12.33.163.33:18502/");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //client.DefaultRequestHeaders.TryAddWithoutValidation()

            // // Add an Accept header for JSON format.
            // client.DefaultRequestHeaders.Accept.Add(
            //     new MediaTypeWithQualityHeaderValue("text/plain"));
            //// request.addHeader("Content-Type", "text/plain");
            // client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            client.DefaultRequestHeaders.Add("userName", "vasanth");
            //client.DefaultRequestHeaders.Add("Content-Type", "text/plain");




            client.DefaultRequestHeaders.Add("APISecuritytoken", "20+QVkqN10W6jV5wfXRnJQ==");
            //client.DefaultRequestHeaders.Add("Authorization", "20+QVkqN10W6jV5wfXRnJQ== ");


            HttpResponseMessage response = client.GetAsync("api/leads/60C4993AF44E7C09E0530314960AAA00/activities").Result;



            if (response.IsSuccessStatusCode)
            {
                var users = response.Content.ReadAsAsync<CustomResponse>().Result;



                var listofActivitites = Newtonsoft.Json.JsonConvert.DeserializeObject<Activities>(Convert.ToString(users.ResponseData));

                activityString.Append($"You have {listofActivitites.ScheduledActivities.Count} Scheduled Activities");

                var i = 1;
                if (listofActivitites.ScheduledActivities.Count > 0)
                {
                    foreach (var scheduledActivity in listofActivitites.ScheduledActivities)
                    {

                        if (i == 1)
                        {
                            activityString.Append($" You have  the Activity ");
                        }

                        else
                        {
                            if (listofActivitites.ScheduledActivities.Count == i)
                            {
                                activityString.Append(" and ");
                            }
                            else
                            {
                                activityString.Append(" , ");
                            }
                        }


                        activityString.Append($"  {scheduledActivity.ActivityName} for {scheduledActivity.ProspectorcontactName} at {scheduledActivity.StartEndTime.Split('-')[0]}");

                        i++;

                    }
                }

                return Convert.ToString(activityString);
                // usergrid.ItemsSource = users;

            }
            else
            {
                // MessageBox.Show("Error Code" +
                //response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

            return "Sorry. Unable to Fetch Activities";
        }



    }

    public class CustomResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object ResponseData { get; set; }
    }

    public class ScheduledActivity
    {
        public string ActivityId { get; set; }
        public string DueDate { get; set; }
        public string StartEndTime { get; set; }
        public string Priority { get; set; }
        public string ProspectorcontactName { get; set; }
        public string Phone { get; set; }
        public string ActivityName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NoteId { get; set; }
        public string ScheduledFor { get; set; }
    }

    public class Activities
    {
        public List<ScheduledActivity> ScheduledActivities { get; set; }
    }
}