using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting.Hosting;

namespace Iron.Server
{
    public interface IIronScript
    {
        IronScriptLanguage Language { get; set; }
        string Script { get; set; }
        string ScriptOutput { get; set; }
    }

}
