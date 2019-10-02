using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_Analyser
{
    public class OIDWalk
    {
        public const string InterfaceIndex          = "1.3.6.1.2.1.2.2.1.1";
        public const string InterfaceDescription    = "1.3.6.1.2.1.2.2.1.2";
        public const string InterfaceType           = "1.3.6.1.2.1.2.2.1.3";
        public const string InterfaceSpeed          = "1.3.6.1.2.1.2.2.1.5";
        public const string InterfaceStatus         = "1.3.6.1.2.1.2.2.1.8";

        public const string VLANListName            = "1.3.6.1.2.1.17.7.1.4.3.1.1";
        public const string VLANListNotExcludedStat = "1.3.6.1.2.1.17.7.1.4.3.1.2";
        public const string VLANListUntaggedStat    = "1.3.6.1.2.1.17.7.1.4.3.1.4";

        public const string VLANListNotExcluded     = "1.3.6.1.2.1.17.7.1.4.2.1.4.0";
        public const string VLANListUntagged        = "1.3.6.1.2.1.17.7.1.4.2.1.5.0";

    }

    public class OIDGet
    {
        public const string InterfaceCount          = "1.3.6.1.2.1.2.1.0";
        
    }
}
