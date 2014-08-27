using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer;
namespace CMSTooling
{
    public partial class PortLocatorForm : Form
    {
        public PortLocatorForm()
        {
            InitializeComponent();
        }
        BLL ObjBLL = new BLL();
        BEL ObjBEL;
        TextBox txtOrificeSize = new TextBox();
        TextBox txtOffSet = new TextBox();
   
        public string Global;
        private void PortLocatorForm_Load(object sender, EventArgs e)
        {
            ObjBEL = new BEL();
            txtOrificeSize.ReadOnly = true;
            txtOffSet.ReadOnly = true;
            DataTable ObjDataTable = new DataTable();
            ObjDataTable = ObjBLL.PortlocatorLoad("PortSize");
            this.cmbPortSize.SelectedIndexChanged -= new EventHandler(cmbPortSize_SelectedIndexChanged);
            cmbPortSize.DataSource = ObjDataTable;     
            cmbPortSize.DisplayMember = "PortSize";
            cmbPortSize.SelectedIndex = -1;
            this.cmbPortSize.SelectedIndexChanged += new EventHandler(cmbPortSize_SelectedIndexChanged);
        }
        private void cmbPortSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL = new BEL();
            if (cmbPortSize.SelectedIndex >= 0)
            {
                ObjBEL.PortSize = ((System.Data.DataRowView)(cmbPortSize.SelectedItem)).Row.ItemArray[0].ToString();
                DataTable ObjDataTable = new DataTable();
                ObjDataTable = ObjBLL.PortlocatorLoad("OrificeSize", ObjBEL.PortSize);
                if (ObjDataTable.Rows.Count > 1)
                {
                    txtOffSet.Visible = false;
                    txtOrificeSize.ResetText();
                    cmbOffset.Visible = true;
                    cmbOffset.SelectedIndex = -1;
                    cmbOffset.Enabled = false;
                    txtOrificeSize.Visible = false;
                    cmbOrificeSize.Visible = true;
                    this.cmbOrificeSize.SelectedIndexChanged -= new EventHandler(cmbOrificeSize_SelectedIndexChanged);
                    cmbOrificeSize.DataSource = ObjDataTable;
                    cmbOrificeSize.DisplayMember = "OrificeSize";
                    cmbOrificeSize.SelectedIndex = -1;
                    cmbOrificeSize.Enabled = true;
                    this.cmbOrificeSize.SelectedIndexChanged += new EventHandler(cmbOrificeSize_SelectedIndexChanged);
                }
                else
                {
                    cmbOffset.Visible = true;
                    cmbOrificeSize.Visible = false;
                    tableLayoutPanel1.Controls.Add(txtOrificeSize, 1, 2);
                    txtOrificeSize.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                    txtOrificeSize.Location = new Point(163, 41);
                    txtOrificeSize.Visible = true;
                    txtOrificeSize.Text = ObjDataTable.Rows[0].ItemArray[0].ToString();                  
                    txtOrificeSize_TextChanged();
                }
              //  txtboxPortLoc.ResetText();
           }
        }
        private void txtOrificeSize_TextChanged()
        {
            ObjBEL.OrificeSize = txtOrificeSize.Text;
            DataTable ObjDataTable = new DataTable();
            ObjDataTable = ObjBLL.PortlocatorLoad("OffSet", ObjBEL.PortSize, ObjBEL.OrificeSize);
            if (ObjDataTable.Rows.Count > 1)
            {
                txtOffSet.Visible = false;
                cmbOffset.Visible = true;
                this.cmbOffset.SelectedIndexChanged -= new EventHandler(cmbOffset_SelectedIndexChanged);
                cmbOffset.DataSource = ObjDataTable;
                cmbOffset.DisplayMember = "OffSet";
                cmbOffset.SelectedIndex = -1;
                cmbOffset.Enabled = true;
                this.cmbOffset.SelectedIndexChanged += new EventHandler(cmbOffset_SelectedIndexChanged);
            }
            else
            {
                cmbOffset.Visible = false;
                tableLayoutPanel1.Controls.Add(txtOffSet, 1, 3);
                txtOffSet.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                txtOffSet.Location = new Point(163, 67);
                txtOffSet.Visible = true;
                txtOffSet.Text = ObjDataTable.Rows[0].ItemArray[0].ToString();
                ObjBEL.OffSet = txtOffSet.Text;
            }
        }
    
        private void cmbOrificeSize_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbOrificeSize.SelectedIndex >= 0)
            {
                ObjBEL.OrificeSize = ((System.Data.DataRowView)(cmbOrificeSize.SelectedItem)).Row.ItemArray[0].ToString();
                DataTable ObjDataTable = new DataTable();
                ObjDataTable = ObjBLL.PortlocatorLoad("OffSet", ObjBEL.PortSize, ObjBEL.OrificeSize);
                if (ObjDataTable.Rows.Count > 1)
                {
                    txtOffSet.Visible = false;
                    cmbOffset.Visible = true;
                    this.cmbOffset.SelectedIndexChanged -= new EventHandler(cmbOffset_SelectedIndexChanged);
                    cmbOffset.DataSource = ObjDataTable;
                    cmbOffset.DisplayMember = "OffSet";
                    cmbOffset.SelectedIndex = -1;
                    cmbOffset.Enabled = true;
                    this.cmbOffset.SelectedIndexChanged += new EventHandler(cmbOffset_SelectedIndexChanged);
                }
                else
                {
                    cmbOffset.Visible = false;
                    tableLayoutPanel1.Controls.Add(txtOffSet, 1, 3);
                    txtOffSet.Location = new Point(163, 67);
                    txtOffSet.Visible = true;
                    txtOffSet.Text = ObjDataTable.Rows[0].ItemArray[0].ToString();
                    ObjBEL.OffSet = txtOffSet.Text;
                }
            }           
        }

        private void cmbOffset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOffset.SelectedIndex >= 0)
            {
                ObjBEL.OffSet = ((System.Data.DataRowView)(cmbOffset.SelectedItem)).Row.ItemArray[0].ToString();
            }
        }

        private void btnGetPort_Click(object sender, EventArgs e)
        {
            string validationMsg = ObjBLL.PortLocatorFormValidation(ObjBEL);
            if (validationMsg != null)
            {
                MessageBox.Show(validationMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            else
            {
                //txtboxPortLoc.Text = ObjBLL.GetPortLocator(ObjBEL.PortSize, ObjBEL.OrificeSize, ObjBEL.OffSet);
                Global = ObjBLL.GetPortLocator(ObjBEL.PortSize, ObjBEL.OrificeSize, ObjBEL.OffSet);
                this.Close();
            }
          
        }

        //private void btnOk_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
    }
}
