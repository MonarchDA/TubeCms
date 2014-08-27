namespace CMSTooling
{
    partial class PortLocatorForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPortSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOrificeSize = new System.Windows.Forms.ComboBox();
            this.cmbOffset = new System.Windows.Forms.ComboBox();
            this.btnGetPort = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbPortSize, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbOrificeSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbOffset, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnGetPort, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.657899F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.17105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.17105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.17105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.17105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.657899F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(321, 182);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port Size :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPortSize
            // 
            this.cmbPortSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbPortSize.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPortSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPortSize.FormattingEnabled = true;
            this.cmbPortSize.Location = new System.Drawing.Point(163, 29);
            this.cmbPortSize.Name = "cmbPortSize";
            this.cmbPortSize.Size = new System.Drawing.Size(121, 21);
            this.cmbPortSize.TabIndex = 1;
            this.cmbPortSize.SelectedIndexChanged += new System.EventHandler(this.cmbPortSize_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Orifice Size :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(3, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Off-Set :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbOrificeSize
            // 
            this.cmbOrificeSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbOrificeSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrificeSize.Enabled = false;
            this.cmbOrificeSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbOrificeSize.FormattingEnabled = true;
            this.cmbOrificeSize.Location = new System.Drawing.Point(163, 65);
            this.cmbOrificeSize.Name = "cmbOrificeSize";
            this.cmbOrificeSize.Size = new System.Drawing.Size(121, 21);
            this.cmbOrificeSize.TabIndex = 3;
            this.cmbOrificeSize.SelectedIndexChanged += new System.EventHandler(this.cmbOrificeSize_SelectedIndexChanged);
            // 
            // cmbOffset
            // 
            this.cmbOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbOffset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOffset.Enabled = false;
            this.cmbOffset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbOffset.FormattingEnabled = true;
            this.cmbOffset.Location = new System.Drawing.Point(163, 101);
            this.cmbOffset.Name = "cmbOffset";
            this.cmbOffset.Size = new System.Drawing.Size(121, 21);
            this.cmbOffset.TabIndex = 3;
            this.cmbOffset.SelectedIndexChanged += new System.EventHandler(this.cmbOffset_SelectedIndexChanged);
            // 
            // btnGetPort
            // 
            this.btnGetPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetPort.Location = new System.Drawing.Point(163, 138);
            this.btnGetPort.Name = "btnGetPort";
            this.btnGetPort.Size = new System.Drawing.Size(75, 20);
            this.btnGetPort.TabIndex = 4;
            this.btnGetPort.Text = "GetPort";
            this.btnGetPort.UseVisualStyleBackColor = true;
            this.btnGetPort.Click += new System.EventHandler(this.btnGetPort_Click);
            // 
            // PortLocatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(321, 182);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(337, 220);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(337, 220);
            this.Name = "PortLocatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PortLocatorForm";
            this.Load += new System.EventHandler(this.PortLocatorForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetPort;
        public System.Windows.Forms.ComboBox cmbPortSize;
        public System.Windows.Forms.ComboBox cmbOrificeSize;
        public System.Windows.Forms.ComboBox cmbOffset;
    }
}