﻿namespace SNMP_Analyser_UI
{
    partial class SNMP_Info
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SNMP_Info));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetConfig = new System.Windows.Forms.Button();
            this.btnRemoveIP = new System.Windows.Forms.Button();
            this.btnAddIP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxIPList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSwitch = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.btnExportSwitch = new System.Windows.Forms.Button();
            this.btnExportInterface = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxPortInfo = new System.Windows.Forms.ListBox();
            this.lbxVLANS = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbxInterfaces = new System.Windows.Forms.ListBox();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.txbIPAddress = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbIPAddress);
            this.groupBox1.Controls.Add(this.btnGetConfig);
            this.groupBox1.Controls.Add(this.btnRemoveIP);
            this.groupBox1.Controls.Add(this.btnAddIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbxIPList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 426);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Switches";
            // 
            // btnGetConfig
            // 
            this.btnGetConfig.Location = new System.Drawing.Point(6, 383);
            this.btnGetConfig.Name = "btnGetConfig";
            this.btnGetConfig.Size = new System.Drawing.Size(159, 37);
            this.btnGetConfig.TabIndex = 4;
            this.btnGetConfig.Text = "Reload Config";
            this.btnGetConfig.UseVisualStyleBackColor = true;
            this.btnGetConfig.Click += new System.EventHandler(this.btnGetConfig_Click);
            // 
            // btnRemoveIP
            // 
            this.btnRemoveIP.Location = new System.Drawing.Point(6, 354);
            this.btnRemoveIP.Name = "btnRemoveIP";
            this.btnRemoveIP.Size = new System.Drawing.Size(159, 23);
            this.btnRemoveIP.TabIndex = 3;
            this.btnRemoveIP.Text = "Remove";
            this.btnRemoveIP.UseVisualStyleBackColor = true;
            this.btnRemoveIP.Click += new System.EventHandler(this.btnRemoveIP_Click);
            // 
            // btnAddIP
            // 
            this.btnAddIP.Location = new System.Drawing.Point(6, 65);
            this.btnAddIP.Name = "btnAddIP";
            this.btnAddIP.Size = new System.Drawing.Size(159, 23);
            this.btnAddIP.TabIndex = 2;
            this.btnAddIP.Text = "Add to List";
            this.btnAddIP.UseVisualStyleBackColor = true;
            this.btnAddIP.Click += new System.EventHandler(this.btnAddIP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP-Address:";
            // 
            // lbxIPList
            // 
            this.lbxIPList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxIPList.FormattingEnabled = true;
            this.lbxIPList.Location = new System.Drawing.Point(6, 97);
            this.lbxIPList.Name = "lbxIPList";
            this.lbxIPList.Size = new System.Drawing.Size(159, 251);
            this.lbxIPList.TabIndex = 0;
            this.lbxIPList.DoubleClick += new System.EventHandler(this.lbxIPList_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblSwitch);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbxPortInfo);
            this.groupBox2.Controls.Add(this.lbxVLANS);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lbxInterfaces);
            this.groupBox2.Location = new System.Drawing.Point(189, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 426);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SNMP Result-Sets";
            // 
            // lblSwitch
            // 
            this.lblSwitch.AutoEllipsis = true;
            this.lblSwitch.Location = new System.Drawing.Point(3, 16);
            this.lblSwitch.Name = "lblSwitch";
            this.lblSwitch.Size = new System.Drawing.Size(404, 17);
            this.lblSwitch.TabIndex = 8;
            this.lblSwitch.Text = "Switch:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.btnExportAll);
            this.groupBox3.Controls.Add(this.btnExportSwitch);
            this.groupBox3.Controls.Add(this.btnExportInterface);
            this.groupBox3.Location = new System.Drawing.Point(233, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 137);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Export Results";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(90, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(69, 17);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Complete";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(20, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(56, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.Text = "Simple";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnExportAll
            // 
            this.btnExportAll.Location = new System.Drawing.Point(6, 50);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(162, 23);
            this.btnExportAll.TabIndex = 6;
            this.btnExportAll.Text = "Save All Switches";
            this.btnExportAll.UseVisualStyleBackColor = true;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // btnExportSwitch
            // 
            this.btnExportSwitch.Location = new System.Drawing.Point(6, 79);
            this.btnExportSwitch.Name = "btnExportSwitch";
            this.btnExportSwitch.Size = new System.Drawing.Size(162, 23);
            this.btnExportSwitch.TabIndex = 6;
            this.btnExportSwitch.Text = "Save Selected Switch";
            this.btnExportSwitch.UseVisualStyleBackColor = true;
            this.btnExportSwitch.Click += new System.EventHandler(this.btnExportSwitch_Click);
            // 
            // btnExportInterface
            // 
            this.btnExportInterface.Location = new System.Drawing.Point(6, 108);
            this.btnExportInterface.Name = "btnExportInterface";
            this.btnExportInterface.Size = new System.Drawing.Size(162, 23);
            this.btnExportInterface.TabIndex = 6;
            this.btnExportInterface.Text = "Save Selected Interface";
            this.btnExportInterface.UseVisualStyleBackColor = true;
            this.btnExportInterface.Click += new System.EventHandler(this.btnExportInterface_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Port Info:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "VLANS:";
            // 
            // lbxPortInfo
            // 
            this.lbxPortInfo.FormattingEnabled = true;
            this.lbxPortInfo.Location = new System.Drawing.Point(233, 179);
            this.lbxPortInfo.Name = "lbxPortInfo";
            this.lbxPortInfo.Size = new System.Drawing.Size(174, 95);
            this.lbxPortInfo.TabIndex = 4;
            // 
            // lbxVLANS
            // 
            this.lbxVLANS.FormattingEnabled = true;
            this.lbxVLANS.Location = new System.Drawing.Point(233, 49);
            this.lbxVLANS.Name = "lbxVLANS";
            this.lbxVLANS.Size = new System.Drawing.Size(174, 108);
            this.lbxVLANS.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Interfaces:";
            // 
            // lbxInterfaces
            // 
            this.lbxInterfaces.FormattingEnabled = true;
            this.lbxInterfaces.Location = new System.Drawing.Point(6, 49);
            this.lbxInterfaces.Name = "lbxInterfaces";
            this.lbxInterfaces.Size = new System.Drawing.Size(221, 368);
            this.lbxInterfaces.TabIndex = 0;
            this.lbxInterfaces.SelectedIndexChanged += new System.EventHandler(this.lbxInterfaces_SelectedIndexChanged);
            // 
            // sfdSave
            // 
            this.sfdSave.DefaultExt = "txt";
            this.sfdSave.FileName = "SNMP-Result.txt";
            this.sfdSave.Filter = "Text-File|*.txt|PDF-File|*.pdf|Configuration-File|*.ini";
            // 
            // txbIPAddress
            // 
            this.txbIPAddress.Location = new System.Drawing.Point(6, 39);
            this.txbIPAddress.Name = "txbIPAddress";
            this.txbIPAddress.Size = new System.Drawing.Size(159, 20);
            this.txbIPAddress.TabIndex = 4;
            // 
            // SNMP_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SNMP_Info";
            this.Text = "SNMP Interface-Info";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetConfig;
        private System.Windows.Forms.Button btnRemoveIP;
        private System.Windows.Forms.Button btnAddIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxIPList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbxInterfaces;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxVLANS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbxPortInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.Button btnExportSwitch;
        private System.Windows.Forms.Button btnExportInterface;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.Label lblSwitch;
        private System.Windows.Forms.TextBox txbIPAddress;
    }
}

