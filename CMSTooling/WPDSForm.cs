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
    public partial class WPDSForm : Form
    {
        public WPDSForm()
        {
            InitializeComponent();
        }
        BEL ObjBEL;
        BLL ObjBLL = new BLL();
        TextBox txtOrientation = new TextBox();
        TextBox txtStyle = new TextBox();
        TextBox txtThreadSize = new TextBox();
        TextBox txtTubeODMin = new TextBox();
        public string GlobalWpDS;
        private void cmbPortType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            PortTypeChangedResetControls();
            ObjBEL = new BEL();
            if (cmbPortType.SelectedIndex >= 0)
            {
                ObjBEL.PortTypeWpds = ((System.Data.DataRowView)(cmbPortType.SelectedItem)).Row.ItemArray[0].ToString();
                DataTable ObjDataTable = new DataTable();
                ObjDataTable = ObjBLL.WPDSFormLoad("PortOrientation", ObjBEL.PortTypeWpds);
                if (ObjDataTable.Rows.Count > 1)
                {

                    cmbOrientation.SelectedIndexChanged -= new EventHandler(cmbOrientation_SelectedIndexChanged);
                    cmbOrientation.DataSource = ObjDataTable;
                    cmbOrientation.DisplayMember = "PortOrientation";
                    cmbOrientation.SelectedIndex = -1;
                    cmbOrientation.Enabled = true;
                    cmbOrientation.SelectedIndexChanged += new EventHandler(cmbOrientation_SelectedIndexChanged);
                }
                else
                {
                    cmbOrientation.Visible = false;
                    tableLayoutPanel2.Controls.Add(txtOrientation, 1, 1);
                    txtOrientation.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                    txtOrientation.Visible = true;
                    txtOrientation.Text = ObjDataTable.Rows[0].ItemArray[0].ToString();
                }
            }
            txtboxPartCode.ResetText();
        }

        private void WPDSForm_Load(object sender, EventArgs e)
        {
            ObjBEL = new BEL();
            txtStyle.ReadOnly = true;
            txtOrientation.ReadOnly = true;
            txtThreadSize.ReadOnly = true;
            txtTubeODMin.ReadOnly = true;
            cmbTubeType.Enabled = false;
            cmbTubeType.SelectedIndex = -1;
            DataTable ObjDataTable = new DataTable();
            ObjDataTable=ObjBLL.WPDSFormLoad("PortType");
            cmbPortType.SelectedIndexChanged -= new EventHandler(cmbPortType_SelectedIndexChanged);
            cmbPortType.DataSource = ObjDataTable;
            cmbPortType.DisplayMember = "PortType";
            cmbPortType.SelectedIndex = -1;
            cmbPortType.SelectedIndexChanged += new EventHandler(cmbPortType_SelectedIndexChanged);
           
        }    

        private void cmbOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            OrientationChangedResetControls();
            if (cmbOrientation.SelectedIndex >= 0)
            {
                ObjBEL.Orientation = ((System.Data.DataRowView)(cmbOrientation.SelectedItem)).Row.ItemArray[0].ToString();
                DataTable ObjdataTable = new DataTable();
                ObjdataTable = ObjBLL.WPDSFormLoad("PORT_BASE", ObjBEL.PortTypeWpds, ObjBEL.Orientation);
                if (ObjdataTable.Rows.Count > 1)
                {
                    txtStyle.Visible = false;
                    cmbStyle.Visible = true;
                    cmbStyle.Enabled = true;
                    cmbStyle.SelectedIndexChanged -= new EventHandler(cmbStyle_SelectedIndexChanged);
                    cmbStyle.DataSource = ObjdataTable;
                    cmbStyle.DisplayMember = "PORT_BASE";
                    cmbStyle.SelectedIndex = -1;
                    cmbStyle.Enabled = true;
                    cmbStyle.SelectedIndexChanged += new EventHandler(cmbStyle_SelectedIndexChanged);
                }
                else
                {
                    cmbStyle.Visible = false;
                    tableLayoutPanel2.Controls.Add(txtStyle, 1, 2);
                    txtStyle.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                    txtStyle.Visible = true;
                    txtStyle.Text = ObjdataTable.Rows[0].ItemArray[0].ToString();
                    txtStylee_TextChanged();
                }
            }
 
        }
        private void txtStylee_TextChanged()
        {
            ObjBEL.Style = txtStyle.Text;
           
            DataTable ObjdataTable = new DataTable();
            ObjdataTable = ObjBLL.WPDSFormLoad("PortThread", ObjBEL.PortTypeWpds, ObjBEL.Orientation, ObjBEL.Style);
            if (ObjdataTable.Rows.Count > 1)
            {
                txtThreadSize.Visible = false;
                cmbThreadSize.Visible = true;
                cmbThreadSize.Enabled = false;
                cmbThreadSize.SelectedIndexChanged -= new EventHandler(cmbThreadSize_SelectedIndexChanged);
                cmbThreadSize.DataSource = ObjdataTable;
                cmbThreadSize.DisplayMember = "PortThread";
                cmbThreadSize.SelectedIndex = -1;
                cmbThreadSize.Enabled = true;
                cmbThreadSize.SelectedIndexChanged += new EventHandler(cmbThreadSize_SelectedIndexChanged);
            }
            else
            {
                cmbThreadSize.Visible = false;
                tableLayoutPanel2.Controls.Add(txtThreadSize, 1, 3);
                txtThreadSize.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                txtThreadSize.Visible = true;
                txtThreadSize.Text = ObjdataTable.Rows[0].ItemArray[0].ToString();
                txtThreadSize_TextChanged();
            }
           
        }


        private void cmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            StyleChangedResetControls();
            if (cmbStyle.SelectedIndex >= 0)
            {
                ObjBEL.Style = ((System.Data.DataRowView)(cmbStyle.SelectedItem)).Row.ItemArray[0].ToString();
                DataTable ObjdataTable = new DataTable();
                ObjdataTable = ObjBLL.WPDSFormLoad("PortThread", ObjBEL.PortTypeWpds, ObjBEL.Orientation, ObjBEL.Style);
                if (ObjdataTable.Rows.Count > 1)
                {
                    txtThreadSize.Visible = false;
                    cmbThreadSize.Visible = true;
                    cmbThreadSize.Enabled = false;
                    cmbThreadSize.SelectedIndexChanged -= new EventHandler(cmbThreadSize_SelectedIndexChanged);
                    cmbThreadSize.DataSource = ObjdataTable;
                    cmbThreadSize.DisplayMember = "PortThread";
                    cmbThreadSize.SelectedIndex = -1;
                    cmbThreadSize.Enabled = true;
                    cmbThreadSize.SelectedIndexChanged += new EventHandler(cmbThreadSize_SelectedIndexChanged);
                }
                else
                {
                    cmbThreadSize.Visible = false;
                    tableLayoutPanel2.Controls.Add(txtThreadSize, 1, 3);
                    txtThreadSize.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                    txtThreadSize.Visible = true;
                    txtThreadSize.Text = ObjdataTable.Rows[0].ItemArray[0].ToString();
                    txtThreadSize_TextChanged();
                }
            }

        }
        private void txtThreadSize_TextChanged()
        {
            ObjBEL.ThreadSize = txtThreadSize.Text;
            DataTable ObjdataTable = new DataTable();
            ObjdataTable = ObjBLL.WPDSFormLoad("MinimumTubeOD", ObjBEL.PortTypeWpds, ObjBEL.Orientation, ObjBEL.Style, ObjBEL.ThreadSize);
            if (ObjdataTable.Rows.Count > 1)
            {
                txtTubeODMin.Visible = false;
                cmbTubeODMin.Visible = true;
                cmbTubeODMin.Enabled = true;
                cmbTubeODMin.SelectedIndexChanged -= new EventHandler(cmbTubeODMin_SelectedIndexChanged);
                cmbTubeODMin.DataSource = ObjdataTable;
                cmbTubeODMin.DisplayMember = "MinimumTubeOD";
                cmbThreadSize.SelectedIndex = -1;
                cmbTubeODMin.Enabled = true;
                cmbTubeODMin.SelectedIndexChanged -= new EventHandler(cmbTubeODMin_SelectedIndexChanged);
            }
            else
            {
                cmbTubeODMin.Visible = false;
                tableLayoutPanel2.Controls.Add(txtTubeODMin, 1, 4);
                txtTubeODMin.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                txtTubeODMin.Visible = true;
                txtTubeODMin.Text = ObjdataTable.Rows[0].ItemArray[0].ToString();
                txtTubeODMin_TextChanged();
            }

        }
      
        private void cmbThreadSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThreadChangedResetControls();
            if (cmbThreadSize.SelectedIndex >= 0)
            {
                ObjBEL.ThreadSize = ((System.Data.DataRowView)(cmbThreadSize.SelectedItem)).Row.ItemArray[0].ToString();
                DataTable ObjdataTable = new DataTable();
                ObjdataTable = ObjBLL.WPDSFormLoad("MinimumTubeOD", ObjBEL.PortTypeWpds, ObjBEL.Orientation, ObjBEL.Style, ObjBEL.ThreadSize);
                if (ObjdataTable.Rows.Count > 1)
                {
                    txtTubeODMin.Visible = false;
                    cmbTubeODMin.Visible = true;
                    cmbTubeODMin.Enabled = true;
                    cmbTubeODMin.SelectedIndexChanged -= new EventHandler(cmbTubeODMin_SelectedIndexChanged);
                    cmbTubeODMin.DataSource = ObjdataTable;
                    cmbTubeODMin.DisplayMember = "MinimumTubeOD";
                    cmbTubeODMin.SelectedIndex = -1;
                    cmbTubeODMin.Enabled = true;
                    cmbTubeODMin.SelectedIndexChanged += new EventHandler(cmbTubeODMin_SelectedIndexChanged);
                }
                else
                {
                    cmbTubeODMin.Visible = false;
                    tableLayoutPanel2.Controls.Add(txtTubeODMin, 1, 4);
                    txtTubeODMin.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                    txtTubeODMin.Visible = true;
                    txtTubeODMin.Text = ObjdataTable.Rows[0].ItemArray[0].ToString();
                    txtTubeODMin_TextChanged();
                }
            }
        }
        private void txtTubeODMin_TextChanged()
        {
            ObjBEL.TubeODMin = txtTubeODMin.Text;
            txtboxPartCode.Text = ObjBLL.GetPartNUmber("PortCode", ObjBEL.PortTypeWpds, ObjBEL.Orientation, ObjBEL.Style, ObjBEL.ThreadSize, ObjBEL.TubeODMin);
            ObjBEL.PartCode = txtboxPartCode.Text;
            cmbTubeType.Enabled = true;
        }

        private void cmbTubeODMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTubeODMin.SelectedIndex >= 0)
            {
                ObjBEL.TubeODMin = ((System.Data.DataRowView)(cmbTubeODMin.SelectedItem)).Row.ItemArray[0].ToString();
                txtboxPartCode.Text = ObjBLL.GetPartNUmber("PortCode", ObjBEL.PortTypeWpds, ObjBEL.Orientation, ObjBEL.Style, ObjBEL.ThreadSize, ObjBEL.TubeODMin);
                ObjBEL.PartCode = txtboxPartCode.Text;
                cmbTubeType.Enabled = true;
            }
            else
            {
            }

        }

        private void cmbTubeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTubeType.SelectedItem.ToString() == "Skived")
            {
                ObjBEL.TubeType = "WPDS_Skived";
            }
            else if (cmbTubeType.SelectedItem.ToString() == "Honed")
            {
                ObjBEL.TubeType = "WPDS_Honed";
            }
        }
        private void btnGetWPDS_Click(object sender, EventArgs e)
        {
            string ValidationMsg=ObjBLL.WPDSFormValidation(ObjBEL);
            if (ValidationMsg != null)
            {
                MessageBox.Show(ValidationMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            else
            {
               // txtboxWPDS.Text = ObjBLL.GetWPDS(ObjBEL.PartCode, ObjBEL.TubeType,ObjBEL.TubeODMin);
                GlobalWpDS = ObjBLL.GetWPDS(ObjBEL.PartCode, ObjBEL.TubeType, ObjBEL.TubeODMin);
                cmbOrientation.Enabled = false;
                cmbStyle.Enabled = false;
                cmbThreadSize.Enabled = false;
                cmbTubeODMin.Enabled = true;
                this.Close();
            }
           
           // this.Close();
        }
        private void PortTypeChangedResetControls()
        {
            cmbOrientation.Visible = true;
            cmbOrientation.Enabled = false;
            cmbOrientation.SelectedIndexChanged -= new EventHandler(cmbOrientation_SelectedIndexChanged);
            cmbOrientation.SelectedIndex = -1;
            cmbOrientation.SelectedIndexChanged += new EventHandler(cmbOrientation_SelectedIndexChanged);
            cmbStyle.Visible = true;
            cmbStyle.Enabled = false;
            cmbStyle.SelectedIndex = -1;
            cmbThreadSize.Visible = true;
            cmbThreadSize.Enabled = false;
            cmbThreadSize.SelectedIndex = -1;
            cmbTubeODMin.Visible = true;
            cmbTubeODMin.Enabled = false;
            cmbTubeODMin.SelectedItem = -1;
            txtboxPartCode.ResetText();
          
            txtOrientation.Visible = false;
            txtStyle.Visible = false;
            txtThreadSize.Visible = false;
            txtTubeODMin.Visible = false;
            cmbTubeType.SelectedIndexChanged -= new EventHandler(cmbTubeType_SelectedIndexChanged);
            cmbTubeType.SelectedIndex = -1;
            cmbTubeType.SelectedIndexChanged += new EventHandler(cmbTubeType_SelectedIndexChanged);
            cmbTubeType.Enabled = false;
            
        }
        private void OrientationChangedResetControls()
        {
            cmbStyle.Visible = true;
            cmbStyle.Enabled = false;
            cmbThreadSize.Visible = true;
            cmbThreadSize.Enabled = false;
            cmbThreadSize.SelectedIndex = -1;
            cmbTubeODMin.Visible = true;
            cmbTubeODMin.Enabled = false;
            cmbTubeODMin.SelectedIndex = -1;
            txtboxPartCode.ResetText();
            txtOrientation.Visible = false;
            txtStyle.Visible = false;
            txtThreadSize.Visible = false;
            txtTubeODMin.Visible = false;
            cmbTubeType.SelectedIndexChanged -= new EventHandler(cmbTubeType_SelectedIndexChanged);
            cmbTubeType.SelectedIndex = -1;
            cmbTubeType.SelectedIndexChanged += new EventHandler(cmbTubeType_SelectedIndexChanged);
            
        }
        private void StyleChangedResetControls()
        {
            cmbThreadSize.Visible = true;
            cmbThreadSize.Enabled = false;
            cmbThreadSize.SelectedIndex = -1;
            cmbTubeODMin.Visible = true;
            cmbTubeODMin.Enabled = false;
            cmbTubeODMin.SelectedIndex = -1;
            txtboxPartCode.ResetText();
            txtOrientation.Visible = false;
            txtStyle.Visible = false;
            txtThreadSize.Visible = false;
            txtTubeODMin.Visible = false;
            cmbTubeType.SelectedIndexChanged -= new EventHandler(cmbTubeType_SelectedIndexChanged);
            cmbTubeType.SelectedIndex = -1;
            cmbTubeType.SelectedIndexChanged += new EventHandler(cmbTubeType_SelectedIndexChanged);
        }
        private void ThreadChangedResetControls()
        {
            cmbTubeODMin.Visible = true;
            cmbTubeODMin.Enabled = false;
            cmbTubeODMin.SelectedIndex = -1;
            txtboxPartCode.ResetText();
            txtOrientation.Visible = false;
            txtThreadSize.Visible = false;
            txtTubeODMin.Visible = false;
            cmbTubeType.SelectedIndexChanged -= new EventHandler(cmbTubeType_SelectedIndexChanged);
            cmbTubeType.SelectedIndex = -1;
            cmbTubeType.SelectedIndexChanged += new EventHandler(cmbTubeType_SelectedIndexChanged);
           
        }
     
    }
}
