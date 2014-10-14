using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IronZombie.Server
{
    public interface IIronScriptHandler
    {
        //string Code { get; set; }
        dynamic Execute(string code, out string output);
        //string Output{get;}
    }

}
