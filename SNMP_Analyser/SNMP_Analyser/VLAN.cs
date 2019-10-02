using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_Analyser
{
    public class PortTaggingInfo
    {
        public VLAN VLAN { get; set; } = null;
        public TagType TagType { get; set; }

        public PortTaggingInfo(VLAN pVLAN, TagType pTagType)
        {
            this.VLAN = pVLAN;
            this.TagType = pTagType;
        }

        public override string ToString()
        {
            return $"{VLAN.Name}\t{TagType}";
        }
    }


    public class VLAN
    {
        public string Name { get; set; } = "";

        public override string ToString()
        {
            return $"VLAN: {Name}";
        }
    }
}
