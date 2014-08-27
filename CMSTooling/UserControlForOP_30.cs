using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMSTooling
{
    public partial class UserControlForOP_30 : UserControl
    {
        public UserControlForOP_30()
        {
            InitializeComponent();
        }

        CAMForm ObjCAMForm;
        PortLocatorForm ObjPortLoc;
        WPDSForm ObjWPDS;
        BEL ObjBEL=new BEL();

        private void txtboxCam_Click(object sender, EventArgs e)
        {
            ObjCAMForm = new CAMForm();
            ObjCAMForm.Show();
            ObjCAMForm.txtboxTubeOd.Focus();          
            this.Parent.Enabled = false;
            ObjCAMForm.FormClosed += new FormClosedEventHandler(CAMForm_FormClosed);       
        }

        private void CAMForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Parent.Enabled = true;
            txtboxCam.Text = ObjCAMForm.GlobalCam;         
        }

        private void txtboxPortLocator_Click(object sender, EventArgs e)
        {
            ObjPortLoc = new PortLocatorForm();
            ObjPortLoc.Show();
            this.Parent.Enabled = false;
            ObjPortLoc.FormClosed += new FormClosedEventHandler(PortLocatorForm_FormClosed);

        }
        private void PortLocatorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Parent.Enabled = true;
            txtboxPortLocator.Text = ObjPortLoc.Global;
        }

        private void txtboxWpds_Click(object sender, EventArgs e)
        {
            ObjWPDS = new WPDSForm();
            ObjWPDS.Show();
            this.Parent.Enabled = false;
            ObjWPDS.FormClosed += new FormClosedEventHandler(WPDSForm_FormClosed);
        }
        private void WPDSForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Parent.Enabled = true;
            txtboxWpds.Text = ObjWPDS.GlobalWpDS;
         
        }
    }
}
