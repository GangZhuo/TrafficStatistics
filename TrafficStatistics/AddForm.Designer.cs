﻿namespace TrafficStatistics
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PrintLocalPayloadCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LeftAddressTextBox = new System.Windows.Forms.TextBox();
            this.RightTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txSocks5Address = new System.Windows.Forms.TextBox();
            this.chkUseSocks5 = new System.Windows.Forms.CheckBox();
            this.PrintRemotePayloadCheckBox = new System.Windows.Forms.CheckBox();
            this.txDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PrintPayloadAsTextCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // PrintLocalPayloadCheckBox
            // 
            this.PrintLocalPayloadCheckBox.AutoSize = true;
            this.PrintLocalPayloadCheckBox.Location = new System.Drawing.Point(128, 185);
            this.PrintLocalPayloadCheckBox.Name = "PrintLocalPayloadCheckBox";
            this.PrintLocalPayloadCheckBox.Size = new System.Drawing.Size(115, 16);
            this.PrintLocalPayloadCheckBox.TabIndex = 15;
            this.PrintLocalPayloadCheckBox.Text = "Print Local Payload";
            this.PrintLocalPayloadCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Protocol:";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.TypeComboBox.Location = new System.Drawing.Point(128, 12);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(164, 20);
            this.TypeComboBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Local Address:";
            // 
            // LeftAddressTextBox
            // 
            this.LeftAddressTextBox.Location = new System.Drawing.Point(128, 40);
            this.LeftAddressTextBox.MaxLength = 200;
            this.LeftAddressTextBox.Name = "LeftAddressTextBox";
            this.LeftAddressTextBox.Size = new System.Drawing.Size(164, 22);
            this.LeftAddressTextBox.TabIndex = 11;
            this.LeftAddressTextBox.Text = "0.0.0.0:5210";
            // 
            // RightTextBox
            // 
            this.RightTextBox.Location = new System.Drawing.Point(128, 69);
            this.RightTextBox.MaxLength = 200;
            this.RightTextBox.Name = "RightTextBox";
            this.RightTextBox.Size = new System.Drawing.Size(164, 22);
            this.RightTextBox.TabIndex = 13;
            this.RightTextBox.Text = "192.168.1.2:5211";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "Remote Address:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(126, 263);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(217, 262);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "Socks5 Address:";
            // 
            // txSocks5Address
            // 
            this.txSocks5Address.Location = new System.Drawing.Point(128, 100);
            this.txSocks5Address.Name = "txSocks5Address";
            this.txSocks5Address.Size = new System.Drawing.Size(164, 22);
            this.txSocks5Address.TabIndex = 18;
            // 
            // chkUseSocks5
            // 
            this.chkUseSocks5.AutoSize = true;
            this.chkUseSocks5.Location = new System.Drawing.Point(128, 156);
            this.chkUseSocks5.Name = "chkUseSocks5";
            this.chkUseSocks5.Size = new System.Drawing.Size(106, 16);
            this.chkUseSocks5.TabIndex = 19;
            this.chkUseSocks5.Text = "Use socks5 proxy";
            this.chkUseSocks5.UseVisualStyleBackColor = true;
            // 
            // PrintRemotePayloadCheckBox
            // 
            this.PrintRemotePayloadCheckBox.AutoSize = true;
            this.PrintRemotePayloadCheckBox.Location = new System.Drawing.Point(128, 207);
            this.PrintRemotePayloadCheckBox.Name = "PrintRemotePayloadCheckBox";
            this.PrintRemotePayloadCheckBox.Size = new System.Drawing.Size(125, 16);
            this.PrintRemotePayloadCheckBox.TabIndex = 20;
            this.PrintRemotePayloadCheckBox.Text = "Print Remote Payload";
            this.PrintRemotePayloadCheckBox.UseVisualStyleBackColor = true;
            // 
            // txDescription
            // 
            this.txDescription.Location = new System.Drawing.Point(128, 128);
            this.txDescription.Name = "txDescription";
            this.txDescription.Size = new System.Drawing.Size(164, 22);
            this.txDescription.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "Description:";
            // 
            // PrintPayloadAsTextCheckBox
            // 
            this.PrintPayloadAsTextCheckBox.AutoSize = true;
            this.PrintPayloadAsTextCheckBox.Location = new System.Drawing.Point(128, 229);
            this.PrintPayloadAsTextCheckBox.Name = "PrintPayloadAsTextCheckBox";
            this.PrintPayloadAsTextCheckBox.Size = new System.Drawing.Size(122, 16);
            this.PrintPayloadAsTextCheckBox.TabIndex = 23;
            this.PrintPayloadAsTextCheckBox.Text = "Print Payload as Text";
            this.PrintPayloadAsTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 298);
            this.Controls.Add(this.PrintPayloadAsTextCheckBox);
            this.Controls.Add(this.txDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PrintRemotePayloadCheckBox);
            this.Controls.Add(this.chkUseSocks5);
            this.Controls.Add(this.txSocks5Address);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.PrintLocalPayloadCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LeftAddressTextBox);
            this.Controls.Add(this.RightTextBox);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Details";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox PrintLocalPayloadCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LeftAddressTextBox;
        private System.Windows.Forms.TextBox RightTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txSocks5Address;
        private System.Windows.Forms.CheckBox chkUseSocks5;
        private System.Windows.Forms.CheckBox PrintRemotePayloadCheckBox;
        private System.Windows.Forms.TextBox txDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox PrintPayloadAsTextCheckBox;
    }
}