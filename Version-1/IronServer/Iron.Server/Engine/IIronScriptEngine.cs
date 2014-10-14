using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iron.Server;

namespace IronZombie.Server
{

    public interface IIronScriptEngine
    {
        ////ZombieControllerType Controller { get; set; } 
        //string GetScript(ZombieScriptLanguage zsLanguage);
        IIronScript ExecuteScript();
        //void ReplyToScript(string scriptOutput);
    }
}
