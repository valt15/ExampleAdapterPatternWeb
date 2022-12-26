using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplicationAI.Models {
    public class Model { 
        string OPENAI_API_KEY = "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";
        string API_ENDPOINT = "https://api.openai.com/v1/completions";
        int MAX_TOKENS = 2048;
        double TEMPERATURE = (double)0.5;
        string USER_ID = "1";

        public string GetName(string name) {


            //XmlDocument doc = new XmlDocument();
            //string appdata = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath,@"App_Data\config.xml");
            //doc.Load(appdata);

            //XmlNode themeNode = doc.SelectSingleNode("/configuration/customSettings/add[@key='Theme']");
            //string theme = themeNode.Attributes["value"].Value;
       
 string sAnswer = SendMsg(name);
            return (sAnswer.Replace("\n","\r\n"));
        }
        public string SendMsg(string name) {
            System.Net.ServicePointManager.SecurityProtocol=System.Net.SecurityProtocolType.Ssl3|System.Net.SecurityProtocolType.Tls12|System.Net.SecurityProtocolType.Tls11|System.Net.SecurityProtocolType.Tls;
            var request = WebRequest.Create(API_ENDPOINT);
            request.Method="POST";
            request.ContentType="application/json";
            request.Headers.Add("Authorization","Bearer "+OPENAI_API_KEY);
            if(TEMPERATURE<0d|TEMPERATURE>1d) {
                return ("Randomness has to be between 0 and 1 with higher values resulting in more random text");
            }
            string data = "{"+" \"model\":\"text-davinci-002\","+" \"prompt\": \""+name+"\","+" \"max_tokens\": "+MAX_TOKENS+","+" \"user\": \""+USER_ID+"\", "+" \"temperature\": "+TEMPERATURE+"}";
            using(var streamWriter = new StreamWriter(request.GetRequestStream())) {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
                var response = request.GetResponse();
                var streamReader = new StreamReader(response.GetResponseStream());
                string sJson = streamReader.ReadToEnd();
                dynamic jsonObject = JsonConvert.DeserializeObject(sJson);
                return jsonObject.choices[0].text;
            }
        }
    }
}