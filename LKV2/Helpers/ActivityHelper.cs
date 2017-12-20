using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace LKV2.Helpers
{
    public class ActivityHelper
    {

        //internal async static void GetActivities()
        //{
        //    var url = "http://12.33.163.33:18502/api/leads/60C4993AF44E7C09E0530314960AAA00/activities";
        //    var response = await url.WithHeader("Content-Type", "application/json").GetAsync();
        //}

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
                            activityString.Append($" The Activity ");
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


        internal static string GetPendingActivityResult()
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



                var i = 1;
                if (listofActivitites.ScheduledActivities.Count > 0)
                {

                    //  activityString.Append("Pending Activities are");

                    foreach (var scheduledActivity in listofActivitites.ScheduledActivities)
                    {

                        var dateTimeString = Convert.ToDateTime($"{scheduledActivity.DueDate} {scheduledActivity.StartEndTime.Split('-')[0]}").ToString("MM/dd/yyyy HH:mm:ss");

                        var dateTime = Convert.ToDateTime(dateTimeString);


                        var dateTimeNowStr = DateTime.Now.ToString("MM/dd/yyyy HH:mm");// "12/21/2017 11:54 PM";$"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} {DateTime.Now.Hour}:{DateTime.Now.Minute} PM";
                        //var dateTimeNowStr = $"{DateTime.Now.Month}/{DateTime.Now.Day}/{DateTime.Now.Year} {DateTime.Now.Hour}:{DateTime.Now.Minute}";

                        var dateTimeNow = Convert.ToDateTime(dateTimeNowStr);

                        if (dateTime < dateTimeNow)
                        {
                            if (i == 1)
                            {
                                activityString.Append($" The Activity ");
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


                }
                string resultString = $"You have {i - 1} Pending Activities. " + Convert.ToString(activityString);

                // usergrid.ItemsSource = users;..
                return Convert.ToString(resultString);

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