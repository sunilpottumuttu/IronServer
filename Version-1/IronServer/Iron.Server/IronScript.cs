using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iron.Server;

namespace IronZombie.Server
{
    public class IronScript : IIronScript
    {
        public IronScriptLanguage Language
        {
            get;
            set;
        }

        public string Script
        {
            get;
            set;
        }

        public string ScriptOutput
        {
            get;
            set;
        }

    }
}
