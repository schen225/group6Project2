using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data;
using System.Data;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace accountmanager
{
	
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService]
	public class AccountServices : System.Web.Services.WebService
	{
        [WebMethod]
        public List<String> HelperAPI(string url = "",string text = "")
        {
            List<String> Responses = new List<string>();
            string APIresponse = APICall(3,url,text);
            JObject json = JObject.Parse(APIresponse);
            string twitter = ParseTwitter(json.Last.ToString());
            Responses.Add(twitter);
            APIresponse = APICall(5,url, text);
            json = JObject.Parse(APIresponse);
            string chatbot = ParseChatbot(json.Last.ToString());
            Responses.Add(chatbot);
            APIresponse = APICall(4, url, text);
            json = JObject.Parse(APIresponse);
            string facebook = ParseFacebook(json.Last.ToString());
            Responses.Add(facebook);
            APIresponse = APICall(3, url, text);
            json = JObject.Parse(APIresponse);
            string abbreviated = ParseAbbreviated(json.Last.ToString());
            Responses.Add(abbreviated);


            return Responses;

        }
        public string ParseSummary(string text)
        {

            char[] summary = { '"', 's', 'u', 'm', 'm', 'a', 'r', 'y', '"', ':', '"' };
            text = text.Trim(summary);
            return text;
        }
        public string ParseTwitter(string text)
        {
            text = ParseSummary(text);
            return text;
        }
        public string ParseChatbot(string text)
        {
            text = ParseSummary(text);
            return text;
        }
        public string ParseFacebook(string text)
        {
            text = ParseSummary(text);
            return text;
        }
        public string ParseAbbreviated(string text)
        {
            text = ParseSummary(text);
            return text;
        }
        public string APICall(int sentenceNum, string url = "",string text = "")
        {
            var client = new RestClient("https://api.meaningcloud.com/summarization-1.0");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "key=980a54fdf7f02c37902b078872ce6eb0&sentences=" + sentenceNum.ToString()+"&txt="+text+"&url="+url+"&doc=", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
            

        }



	}
}
