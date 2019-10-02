using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_Analyser
{
    public enum TagType
    {
        Tagged,
        Untagged,
        Excluded
    }

    public class Interface
    {
        public int Index { get; set; } = 0;
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public int Speed { get; set; } = 0;
        public bool IsUp { get; set; } = false;

        public List<PortTaggingInfo> VLANTagInfo { get; set; } = new List<PortTaggingInfo>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Interface [{Index}] \t {Description} ({Type}) \t Up = {IsUp} \t");

            foreach(PortTaggingInfo ti in VLANTagInfo)
            {
                sb.AppendLine($"\t VLAN {ti.VLAN.Name} - {ti.TagType}");
            }

            return sb.ToString();

        }
    }
}
