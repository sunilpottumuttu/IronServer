using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using Microsoft.Scripting;
using System.Threading;
using IronZombie.Server;

namespace Iron.Server
{

    public class IronScriptEngine:IIronScriptEngine
    {
        private IIronScript __ironScript;
        


        public IronScriptEngine(IIronScript izScript)
        {
            izScript.Language = IronScriptLanguage.IronPython;
            this.__ironScript = izScript;
        }

        //string IZombieScriptHandler.GetScript(ZombieScriptLanguage zsLanguage)
        //{
        //    string script = string.Empty;
        //    Uri uri = new Uri(ConfigurationManager.AppSettings["GETSCRIPTURL"].ToString());
        //    if (uri.Scheme == Uri.UriSchemeHttp)
        //    {
        //        HttpWebRequest hwrRequestScript = (HttpWebRequest)HttpWebRequest.Create(uri);
        //        hwrRequestScript.Method = WebRequestMethods.Http.Get;
        //        HttpWebResponse hwrResponseScript = (HttpWebResponse)hwrRequestScript.GetResponse();
        //        StreamReader reader = new StreamReader(hwrResponseScript.GetResponseStream());
        //        script = reader.ReadToEnd();
        //        hwrResponseScript.Close();
        //    }
        //    return script;
        //}

        //string IZombieScriptHandler.ExecuteScript(ZombieScriptLanguage zsLanguage, string script)

        IIronScript IIronScriptEngine.ExecuteScript()
        {
            IIronScriptHandler izsch = null;
            if (this.__ironScript.Language == IronScriptLanguage.IronPython)
            {
                izsch = new IronPythonScriptHandler();

                #region COMMENTED CODE
                //ScriptEngine scriptEngine = Python.CreateEngine();
                //ScriptScope scriptScope = scriptEngine.CreateScope();
                //MemoryStream ms = new MemoryStream();
                //scriptEngine.Runtime.IO.SetOutput(ms, Encoding.ASCII);

                //string scriptOutput = string.Empty;
                //try
                //{
                //    ScriptSource source = scriptEngine.CreateScriptSourceFromString(this.__zombieScript.Script, SourceCodeKind.Statements);
                //    object result = source.Execute(scriptScope);
                //    //Console.WriteLine("asdf: " + result.ToString());

                //    ms.Position = 0;
                //    StreamReader sr = new StreamReader(ms);
                //    this.__zombieScript.ScriptOutput = sr.ReadToEnd();
                //    //Console.WriteLine("output: " + scriptOutput); 
                //}
                //catch (Exception ex)
                //{
                //    //Console.WriteLine(ex.Message);
                //    scriptOutput = ex.Message;
                //} 
                #endregion
            }
            //izsch.Code = this.__zombieScript.Script;
            this.__ironScript.ScriptOutput = string.Empty;
            string scriptOutput = string.Empty;
            dynamic result = izsch.Execute(this.__ironScript.Script,out scriptOutput);
            //this.__zombieScript.ScriptOutput = izsch.Output;
            this.__ironScript.ScriptOutput = scriptOutput;
            return this.__ironScript;
           
        }

        //void IZombieScriptHandler.ReplyToScript(string scriptOutput)
        //{
        //    Uri uri = new Uri(ConfigurationManager.AppSettings["POSTSCRIPTURL"].ToString());
           
        //    HttpWebRequest hwrRequestScript = (HttpWebRequest)HttpWebRequest.Create(uri);
        //    hwrRequestScript.Method = WebRequestMethods.Http.Post;

        //    string data = string.Format("re_txtscript={0}", scriptOutput); ; //replace <value> 
        //    byte[] dataArray = Encoding.UTF8.GetBytes(data);

        //    hwrRequestScript.ContentType = "application/x-www-form-urlencoded";
        //    hwrRequestScript.ContentLength = dataArray.Length;
        //    Stream dataStream = hwrRequestScript.GetRequestStream();
        //    dataStream.Write(dataArray, 0, dataArray.Length);
        //    dataStream.Close();


        //    HttpWebResponse response = (HttpWebResponse)hwrRequestScript.GetResponse();

        //    if (HttpStatusCode.OK == response.StatusCode)
        //    {
        //        dataStream = response.GetResponseStream();
        //        StreamReader reader = new StreamReader(dataStream);
        //        string responseFromServer = reader.ReadToEnd();
        //    }
           
        //}
    }


   
}
