using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.Configuration;
using System.IO;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using IronPython;
using IronZombie.Server;



namespace Iron.Server
{
    class Program
    {

        static void Main(string[] args)
        {
            #region COMMENTED CODE
            //string script = string.Empty;

            ////GET THE LATEST SCRIPT FROM WEBSITE
            //Uri uri = new Uri(ConfigurationManager.AppSettings["GETLATESTSCRIPTURL"].ToString());
            //if (uri.Scheme == Uri.UriSchemeHttp)
            //{
            //    HttpWebRequest hwrRequestScript = (HttpWebRequest)HttpWebRequest.Create(uri);
            //    hwrRequestScript.Method = WebRequestMethods.Http.Get;
            //    HttpWebResponse hwrResponseScript = (HttpWebResponse)hwrRequestScript.GetResponse();
            //    StreamReader reader = new StreamReader(hwrResponseScript.GetResponseStream());
            //    script = reader.ReadToEnd();
            //    hwrResponseScript.Close();
            //}

            ////EXECUTE THE SCRIPT
            ////Dictionary<String, Object> options = new Dictionary<string, object>();
            ////options["DivisionOptions"] = PythonDivisionOptions.New;
            ////ScriptEngine scriptEngine = Python.CreateEngine(options);
            //ScriptEngine scriptEngine = Python.CreateEngine();
            //ScriptScope scriptScope = scriptEngine.CreateScope();
            //MemoryStream ms = new MemoryStream();
            //scriptEngine.Runtime.IO.SetOutput(ms, Encoding.ASCII);

            //string scriptOutput = string.Empty;
            //try
            //{
            //    ScriptSource source = scriptEngine.CreateScriptSourceFromString(script, SourceCodeKind.Statements);
            //    object result = source.Execute(scriptScope);
            //    //Console.WriteLine("asdf: " + result.ToString());

            //    ms.Position = 0;
            //    StreamReader sr = new StreamReader(ms);
            //    scriptOutput = sr.ReadToEnd();
            //    //Console.WriteLine("output: " + scriptOutput); 
            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine(ex.Message);
            //    scriptOutput = ex.Message;
            //}
            //finally
            //{
            //    Console.WriteLine(scriptOutput);
            //}


            ////POST THE SCRIPT OUTPUT TO WEBSITE





            //Console.ReadLine(); 
            #endregion

            IIronServer izServer = new IronServer();
            izServer.Run();

            //IZombieScriptHandler izs = new ZombieScriptHandler();
            //string script = izs.GetScript(ZombieScriptLanguage.IronPython);
            //string scriptOutput = izs.ExecuteScript(ZombieScriptLanguage.IronPython, script);
            //Console.WriteLine(scriptOutput);
            //izs.ReplyToScript(scriptOutput);

        }
    }
}
