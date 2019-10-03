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
            lbxPortInfo.Items.Clear();
            try
            {
                selectedSwitch = new Switch(lbxIPList.SelectedItem.ToString());

                foreach (Interface ifc in selectedSwitch.Interfaces)
                {
                    lbxInterfaces.Items.Add(ifc.Description);
                }

                lblSwitch.Text = "Switch: " + selectedSwitch.Description;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to Host!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbxInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxVLANS.Items.Clear();
            lbxPortInfo.Items.Clear();
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

                        lbxPortInfo.Items.Add(string.Format("Description: {0}", selectedSwitch.Interfaces[i].Description));
                        lbxPortInfo.Items.Add(string.Format("Port-Index: {0}", selectedSwitch.Interfaces[i].Index));
                        lbxPortInfo.Items.Add(string.Format("Port-Type-ID: {0}", selectedSwitch.Interfaces[i].Type));
                        lbxPortInfo.Items.Add(string.Format("Link Established: {0}", selectedSwitch.Interfaces[i].IsUp));
                        lbxPortInfo.Items.Add(string.Format("Port Speed: {0} MBit", selectedSwitch.Interfaces[i].Speed / 1000000));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to Host!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            ExportResults("All");
        }

        private void btnExportSwitch_Click(object sender, EventArgs e)
        {
            ExportResults("Switch");
        }

        private void btnExportInterface_Click(object sender, EventArgs e)
        {
            ExportResults("Interface");
        }

        private void ExportResults(string pType)
        {
            if(sfdSave.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(sfdSave.FileName);

                switch(extension.ToLower())
                {
                    case ".txt":
                        StreamWriter sw = new StreamWriter(sfdSave.FileName);


                        switch(pType)
                        {
                            case "All":
                                Switch tmpSwitch;
                                foreach (object ip in lbxIPList.Items)
                                {
                                    tmpSwitch = new Switch(ip.ToString());
                                    sw.WriteLine("============================");
                                    sw.WriteLine($"Switch: {tmpSwitch.ToString()}");
                                    sw.WriteLine("============================\r\n");
                                    foreach (Interface ifc in tmpSwitch.Interfaces)
                                        sw.WriteLine("Interface: " + ifc.ToString());
                                    sw.WriteLine("\r\n");
                                }
                                break;
                            case "Switch":
                                sw.WriteLine("============================");
                                sw.WriteLine($"Switch: {selectedSwitch.ToString()}");
                                sw.WriteLine("============================\r\n");
                                foreach (Interface ifc in selectedSwitch.Interfaces)
                                    sw.WriteLine("Interface: " + ifc.ToString());
                                break;
                            default:
                                sw.WriteLine("============================");
                                sw.WriteLine($"Switch: {selectedSwitch.ToString()}");
                                sw.WriteLine("============================\r\n");
                                foreach(Interface ifc in selectedSwitch.Interfaces)
                                    if (lbxInterfaces.Text == ifc.Description)
                                    {
                                        sw.WriteLine("Interface: " + ifc.ToString());
                                        foreach (PortTaggingInfo portTI in ifc.VLANTagInfo)
                                            lbxVLANS.Items.Add(portTI.ToString());
                                    }
                                break;
                        }

                        sw.Close();
                        break;
                    case ".ini":
                        MessageBox.Show("Not supported yet!");
                        break;
                    case ".pdf":
                        MessageBox.Show("Not supported yet!");
                        break;
                    default:
                        MessageBox.Show($"{extension}-Files are not Supported.");
                        break;
                }
            }
        }
    }
}
