using B1SLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Data
{
    public sealed class SL
    {
        private static readonly SLConnection slConnection = new SLConnection(
        ConfigurationManager.AppSettings["ServiceLayerURL"],
        ConfigurationManager.AppSettings["Database"],
        ConfigurationManager.AppSettings["B1User"],
        ConfigurationManager.AppSettings["B1Password"], 29);

        public static SLConnection Connection { get { return slConnection; } }

    }
}
