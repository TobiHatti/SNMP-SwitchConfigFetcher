using SnmpSharpNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNMP_Analyser
{
    public class Switch
    {
        public IpAddress IPAddress { get; private set; } = new IpAddress("127.0.0.1");
        public int Port { get; private set; } = 161;
        public string Community { get; private set; } = "public";
        public List<Interface> Interfaces { get; private set; } = new List<Interface>();
        public List<VLAN> VLANs { get; private set; } = new List<VLAN>();
        public SwitchConfig Config { get; private set; } = new SwitchConfig();

        private bool error1Displayed = false;
        private bool error2Displayed = false;

        public SNMP SnmpClient { get; set; } = null;

        public Switch(string pIPAddress, string pCommunity = "public", int pPort = 161)
        {
            IPAddress = new IpAddress(pIPAddress);
            Port = pPort;
            Community = pCommunity;

            SnmpClient = new SNMP(IPAddress, Community, Port);

            LoadInterfaces();
            LoadVLANs();
            AssignVLANs();

            
        }

        public void LoadInterfaces()
        {
            // Load interface-data from SNMP
            SNMPResultSet[] rsIndex = SnmpClient.Walk(OIDWalk.InterfaceIndex);
            SNMPResultSet[] rsDesc  = SnmpClient.Walk(OIDWalk.InterfaceDescription);
            SNMPResultSet[] rsType  = SnmpClient.Walk(OIDWalk.InterfaceType);
            SNMPResultSet[] rsSpeed = SnmpClient.Walk(OIDWalk.InterfaceSpeed);
            SNMPResultSet[] rsState = SnmpClient.Walk(OIDWalk.InterfaceStatus);

            Interface tmpIF = null;

            // Create interface-object
            for (int i = 0; i < rsIndex.Length; i++)
            {
                tmpIF = new Interface();

                tmpIF.Index = int.Parse(rsIndex[i].Value);
                tmpIF.Description = rsDesc[i].Value;
                tmpIF.Type = rsType[i].Value;
                tmpIF.Speed = int.Parse(rsSpeed[i].Value);

                if (rsState[i].Value == "1") tmpIF.IsUp = true;
                else tmpIF.IsUp = false;

                Interfaces.Add(tmpIF);
            }
        }

        public void LoadVLANs()
        {
            // Load vlan-data from SNMP
            SNMPResultSet[] rsNames = SnmpClient.Walk(OIDWalk.VLANListName);

            VLAN tmpVLAN = null;

            // Create vlan-object
            for (int i = 0; i < rsNames.Length; i++)
            {
                tmpVLAN = new VLAN();
                tmpVLAN.Name = rsNames[i].Value;
                VLANs.Add(tmpVLAN);
            }
        }

        public void AssignVLANs()
        {
            // Get vlan-tagging-info from SNMP
            SNMPResultSet[] rsNotExcluded = SnmpClient.Walk(OIDWalk.VLANListNotExcluded);
            SNMPResultSet[] rsNotExcludedStat = SnmpClient.Walk(OIDWalk.VLANListNotExcludedStat);
            SNMPResultSet[] rsUntagged = SnmpClient.Walk(OIDWalk.VLANListUntagged);

            List<object> notExcludedBits;
            List<object> notExcludedStatBits;
            List<object> untaggedBits;
            

            bool notExcludedBit;
            bool notExcludedStatBit;
            bool untaggedBit;

            // Cycle through all vlans
            for(int i = 0; i < VLANs.Count; i++)
            {
                // Convert tagging-info
                notExcludedBits = new List<object>();
                notExcludedStatBits = new List<object>();
                untaggedBits = new List<object>();

                try
                {
                    foreach (object bit in ConvertHexToBit(rsNotExcluded[i].Value))
                        notExcludedBits.Add(bit);

                    foreach (object bit in ConvertHexToBit(rsNotExcludedStat[i].Value))
                        notExcludedStatBits.Add(bit);

                    foreach (object bit in ConvertHexToBit(rsUntagged[i].Value))
                        untaggedBits.Add(bit);

                      // Add vlan-tagging-info to interfaces
                    for (int k = 0; k < Interfaces.Count; k++)
                    {
                        if ((bool)notExcludedBits[Interfaces[k].Index - 1] != (bool)notExcludedStatBits[Interfaces[k].Index - 1])
                            MessageBox.Show("The SNMP-Data returns faulty results. Some data may be incorrect!");

                        if (k >= notExcludedBits.Count) notExcludedBit = false;
                        else notExcludedBit = (bool)notExcludedBits[Interfaces[k].Index - 1];

                        if (k >= untaggedBits.Count) untaggedBit = false;
                        else untaggedBit = (bool)untaggedBits[Interfaces[k].Index - 1];

                        if (!notExcludedBit) Interfaces[k].VLANTagInfo.Add(new PortTaggingInfo(VLANs[i], TagType.Excluded));
                        else if (untaggedBit) Interfaces[k].VLANTagInfo.Add(new PortTaggingInfo(VLANs[i], TagType.Untagged));
                        else Interfaces[k].VLANTagInfo.Add(new PortTaggingInfo(VLANs[i], TagType.Tagged));
                    }
                }
                catch(Exception ex)
                {
                    if(!error1Displayed)
                    {
                        error1Displayed = true;
                        MessageBox.Show("At least 1 error occured whilst trying to Parse SNMP-Data. Some data may be incorrect!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                
            }
        }

        private BitArray ConvertHexToBit(string hexData)
        {
            if (hexData == null)
                return null;

            byte[] bya;
            string hexString;

            if (hexData.Contains("\0"))
            {
                hexData = hexData.Replace("\0", "");
                // Convert string to Hex

                bya = Encoding.Default.GetBytes(hexData);
                hexString = BitConverter.ToString(bya);
                hexData = hexString.Replace("-", "");

                if (!error2Displayed)
                {
                    error2Displayed = true;
                    MessageBox.Show("SMPT-Data seems to be corrupted.\r\n Try Parsing...\r\n\r\nNote: Some Results may not be correct.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            hexData = hexData.Replace(" ", "");

            BitArray ba = new BitArray(4 * hexData.Length);
            for (int i = 0; i < hexData.Length; i++)
            {
                byte b = byte.Parse(hexData[i].ToString(), NumberStyles.HexNumber);
                for (int j = 0; j < 4; j++)
                {
                    ba.Set(i * 4 + j, (b & (1 << (3 - j))) != 0);
                }
            }
            return ba;
        }
    }
}
