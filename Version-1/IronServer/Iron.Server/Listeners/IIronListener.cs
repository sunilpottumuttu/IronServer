using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iron.Server;

namespace IronZombie.Server
{
    public interface IIronListener
    {
        void Start();
        void Stop();
    }
}
