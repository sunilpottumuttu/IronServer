using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronPython.Hosting;
using System.IO;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace IronZombie.Server
{
    public class IronPythonScriptHandler : IIronScriptHandler
    {

        //private string __scriptOutput = string.Empty;

        dynamic IIronScriptHandler.Execute(string code, out string output)
        {
            output = string.Empty;
            ScriptEngine scriptEngine = Python.CreateEngine();
            ScriptScope scriptScope = scriptEngine.CreateScope();
            MemoryStream ms = new MemoryStream();
            scriptEngine.Runtime.IO.SetOutput(ms, Encoding.ASCII);

            dynamic result = null;

            try
            {
                ScriptSource source = scriptEngine.CreateScriptSourceFromString(code, SourceCodeKind.Statements);
                //object result = source.Execute(scriptScope);
                result = source.Execute(scriptScope);

                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                //this.__scriptOutput = sr.ReadToEnd();
                output = sr.ReadToEnd();
                //Console.WriteLine("output: " + scriptOutput); 
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                //this.__scriptOutput = ex.Message;
                output = ex.Message;
            }
            return result;
        }









    }
}
