using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SNMP_Analyser;

namespace SNMP_Analyser_UI
{
    public partial class SNMP_Info : Form
    {
        Switch selectedSwitch = null;

        public SNMP_Info()
        {
            InitializeComponent();
            try
            {
                string line;
                StreamReader sr = new StreamReader("networkIPList.ini");
                while ((line = sr.ReadLine()) != null)
                    lbxIPList.Items.Add(line);
            }
            catch { }
        }

        private void btnAddIP_Click(object sender, EventArgs e)
        {
            lbxIPList.Items.Add(txbIPAddress.Text);
            txbIPAddress.Text = "";
        }

        private void btnRemoveIP_Click(object sender, EventArgs e)
        {
            if(lbxIPList.SelectedIndex != -1)
                lbxIPList.Items.RemoveAt(lbxIPList.SelectedIndex);
        }

        private void btnGetConfig_Click(object sender, EventArgs e)
        {
            GetConfig();
        }

        private void lbxIPList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetConfig();
        }

        private void GetConfig()
        {
            lbxInterfaces.Items.Clear();
            lbxVLANS.Items.Clear();
            try
            {
                selectedSwitch = new Switch(lbxIPList.SelectedItem.ToString());

                foreach (Interface ifc in selectedSwitch.Interfaces)
                {
                    lbxInterfaces.Items.Add(ifc.Description);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to Host!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbxInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxVLANS.Items.Clear();
            try
            {

                for (int i = 0; i < selectedSwitch.Interfaces.Count; i++) 
                {
                    if(lbxInterfaces.Text == selectedSwitch.Interfaces[i].Description)
                    {
                        foreach(PortTaggingInfo portTI in selectedSwitch.Interfaces[i].VLANTagInfo)
                        {
                            lbxVLANS.Items.Add(portTI.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to Host!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
