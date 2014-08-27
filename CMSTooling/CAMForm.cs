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
    public partial class CAMForm : Form
    {
        public CAMForm()
        {
            InitializeComponent();
        }
        BEL ObjBEL = new BEL();
        BLL ObjBLL = new BLL();
        public string GlobalCam;
       private void button1_Click(object sender, EventArgs e)
        {
            string ValidationMsg = null;
                if (txtboxTubeOd.Text == string.Empty)
                {
                    ValidationMsg += "Please Enter TubeOd";               
                }
                 if (txtboxPortOd.Text == string.Empty)
                {
                    ValidationMsg += "\n Please Enter TubeOd";                  
                }
                if (ValidationMsg != null)
                {
                    MessageBox.Show(ValidationMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
                else 
                {
           
                ObjBEL.TubeOD = Convert.ToDouble(txtboxTubeOd.Text);
                ObjBEL.PortOD = Convert.ToDouble(txtboxPortOd.Text);
                double Difference = Math.Round((ObjBEL.TubeOD / 2) - Math.Sqrt(Math.Pow((ObjBEL.TubeOD / 2), 2) - Math.Pow((ObjBEL.PortOD / 2), 2)), 4);
                //txtboxCam.Text = ObjBLL.GetBestCam(Difference).ToString();
                GlobalCam = ObjBLL.GetBestCam(Difference).ToString();
                this.Close();
                
                }
            
          }

       private void txtboxTubeOd_Leave(object sender, EventArgs e)
       {
           ObjBEL.TubeOD = Convert.ToDouble(txtboxTubeOd.Text);
       }

       private void txtboxPortOd_Leave(object sender, EventArgs e)
       {
           ObjBEL.PortOD = Convert.ToDouble(txtboxPortOd.Text);
       }
    }
}
