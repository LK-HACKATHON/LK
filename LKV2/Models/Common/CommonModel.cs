using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKV2.Models.Common
{
    public class CommonModel
    {

        public string Id { get; set; }
        internal Session Session { get; set; }
        internal Request Request { get; set; }
        internal Response Response { get; set; }
        public CommonModel()
        {
            Id = "";
            Session = new Session();
            Request = new Request();
            Response = new Response();


        }
    }

    internal class Session
    {
        public string Id { get; set; }
        public bool EndSession { get; set; }
    }
    internal class Request
    {
        public string Id { get; set; }
        public string Intent { get; set; }
        public string State { get; set; }
        public string Channel { get; set; }
        public List<KeyValuePair<string, string>> Parameters { get; set; }
    }


    internal class Response
    {
        public string Text { get; set; }
        public string Prompt { get; internal set; }
        public string Ssml { get; set; }
        public Card Card { get; set; }
    }

    public class Card
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}