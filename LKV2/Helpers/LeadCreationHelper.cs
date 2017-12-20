using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace LKV2.Helpers
{
    public class LeadCreationHelper
    {



        public static string CreateLead(string LeadName, string community, string InquiryDate, string classification, string careSetting)
        {

            var leadList = new List<RootObject>();


           

            RootObject lead = new RootObject();
            var randorm = new Random();
            lead.externalLeadID = Convert.ToString(randorm.Next());
            lead.leadID= "-1";
            lead.communityCode = community;
            lead.transactionType = "Add";
            lead.careSetting = careSetting;
            lead.classificationID = classification;
            lead.inquiryDate = InquiryDate;
            lead.Demographics = new Demographics();

            var Source = new Source();

            lead.Source = new List<Source>();



            lead.Demographics.lastName = LeadName;

            lead.Demographics.leadType = "PS";

            lead.Demographics.relationshipID = "18";

            leadList.Add(lead);

            CreateObject(leadList);

            return "";

        }


        private static void CreateObject(List<RootObject> leadInfo)
        {

            var leadInfoStr = Newtonsoft.Json.JsonConvert.SerializeObject(leadInfo);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://12.33.163.33:18502/api/LeadDemographics/setLeadDemographics");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("userName", "vasanth");
            request.Headers.Add("APISecuritytoken", "20+QVkqN10W6jV5wfXRnJQ==");

            //request.ContentLength = leadInfo.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(leadInfoStr);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            Console.Out.WriteLine(response);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }

        }


    }

    public class Source
    {
        public string sourceCode { get; set; }
        public string subSourceCode { get; set; }
    }

    public class Address
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
    }

    public class Communication
    {
        public string communicationID { get; set; }
        public string phoneNumber { get; set; }
        public string phoneExtension { get; set; }
        public string phoneType { get; set; }
    }

    public class Demographics
    {
        public string relationshipID { get; set; }
        public string leadType { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public string birthdate { get; set; }
        public string ssn { get; set; }
        public string gender { get; set; }
        public string maritalStatus { get; set; }
        public Address address { get; set; }
        public List<Communication> communication { get; set; }
    }

    public class RootObject
    {
        public string externalLeadID { get; set; }
        public string leadID { get; set; }
        public string transactionType { get; set; }
        public string communityCode { get; set; }
        public string careSetting { get; set; }
        public string classificationID { get; set; }
        public string residentID { get; set; }
        public string inquiryDate { get; set; }
        public List<Source> Source { get; set; }
        public Demographics Demographics { get; set; }
    }
}

