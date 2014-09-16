using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using BusinessAccessLayer;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;
using Scripting;


namespace CMSTooling
{
    public partial class CMSTool : Form
    {

        DAL ObjDAL = new DAL();
        BEL ObjBEL = new BEL();
        BEL ObjBEL1 = new BEL();
        BLL ObjBLL = new BLL();
        SaveFileDialog sfd = new SaveFileDialog();
        clsImageCapture oclsImageCapture = new clsImageCapture();

        DataTable ObjDataTable = new DataTable();
        DataRow dRow;
        FileSystemObject fso;
       
        
        public UserControlForOP_30 ObjUctrOP_30 = new UserControlForOP_30();
        public UserControlForOP_059 ObjUctrOP_59 = new UserControlForOP_059();
        public UserControlForOP_070 ObjUctrOp_70 = new UserControlForOP_070();
        public UserControlDoubleWorkInstruction objUctrDoubleWorkInstruction = new UserControlDoubleWorkInstruction();
        public UserControlOP33_155_1 objUctrOP33_155_1 = new UserControlOP33_155_1();
        TextBox txtSop_43 = new TextBox();
        Label lblSop_43 = new Label();
        Label lblWallThickness = new Label();
        ComboBox cmbWallThickness = new ComboBox();
        Label lblTubeEndConfiguration = new Label();
        ComboBox cmbTubeEndConfiguration = new ComboBox();
        Label lblWeldSize = new Label();
        ComboBox cmbWeldSize = new ComboBox();
        Label lblPartWeight = new Label();
        ComboBox cmbPartWeight = new ComboBox();
        Label lblpPinHoleSize = new Label();
        TextBox txtPinHoleSize = new TextBox();
        Label lblHoleDepth = new Label();
        TextBox txtHoleDepth = new TextBox();
        Label lblPort = new Label();
        ComboBox cmbPorts = new ComboBox();
        Point UsercontrolLocation = new Point();
        public CMSTool()
        {
            InitializeComponent();

        }
      
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            changeTextBoxBackGround(groupBox1);
            changeTextBoxBackGround(groupBox2);
            changeTextBoxBackGround(groupBox3);
            btnSaveToNotepad.Enabled = true;
            ObjBEL.MainCAM = ObjUctrOP_30.txtboxCam.Text;
            ObjBEL.MainPortLocator = ObjUctrOP_30.txtboxPortLocator.Text;
            ObjBEL.MainWPDS = ObjUctrOP_30.txtboxWpds.Text;
            txtWieghtTool.Text = "Caution Weight";
            btnScreenCapture.Enabled = true;
           

            string Validation = ObjBLL.MainFormvalidations(ObjBEL);
            if (Validation != null)
            {
                MessageBox.Show(Validation, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            else
            {
                try
                {
                    ObjDataTable = ObjBLL.GetWorkcenterDetails(ObjBEL.OpNo);
                    txtWorkCenter.Text = ObjDataTable.Rows[0].ItemArray[1].ToString();
                    txtDepartment.Text = ObjDataTable.Rows[0].ItemArray[2].ToString();
                    txtOperation.Text = ObjDataTable.Rows[0].ItemArray[3].ToString();
                    txtSetUps.Text = ObjDataTable.Rows[0].ItemArray[4].ToString();
                }
                catch (Exception ex)
                {
                }
                if ((ObjBEL.OpNo == "OP_030_1") || (ObjBEL.OpNo == "OP_031_1") || (ObjBEL.OpNo == "OP_043_1") || (ObjBEL.OpNo == "OP_044_1"))
                {
                    ObjUctrOP_30.txtboxWorkInstuction.Text = "WI09-E-27";
                    txtStandardRunTime.Text = ObjBLL.GetStandardRunTime(ObjBEL);
                    if ((ObjBEL.OpNo == "OP_030_1") || (ObjBEL.OpNo == "OP_043_1") || (ObjBEL.OpNo == "OP_044_1"))
                    {
                        if (ObjBEL.PortType == "One Port")
                        {
                            switch (ObjBEL.OpNo)
                            {
                                case "OP_030_1":
                                    DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_030_1_1");
                                    break;
                                case "OP_043_1":
                                    DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_043_1_1");
                                    break;
                                case "OP_044_1":
                                    DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_044_1");
                                    break;
                                default:
                                    DGV_OP_Sheet.AutoResizeColumns();
                                    break;
                            }

                        }
                        else if (ObjBEL.PortType == "Two Port")
                        {
                            switch (ObjBEL.OpNo)
                            {
                                case "OP_030_1":
                                    DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_030_1_2");
                                    break;
                                case "OP_043_1":
                                    DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_043_1_2");
                                    break;
                                case "OP_044_1":
                                    DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_044_1");
                                    break;
                                default:
                                    DGV_OP_Sheet.AutoResizeColumns();
                                    break;
                            }
                        }

                    }
                    else
                    {
                        DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);
                        DGV_OP_Sheet.AutoResizeColumns();
                    }

                }
                else if ((ObjBEL.OpNo == "OP_061_1") || (ObjBEL.OpNo == "OP_062_1"))
                {
                    ObjUctrOP_59.Visible = true;
                    ObjUctrOP_59.txtboxWorkInstuction.Text = "WI09-E-67";
                    txtStandardRunTime.Text = ObjBLL.GetStandardRunTime(ObjBEL);
                    DGV_OP_Sheet.AutoResizeColumns();
                    if (ObjBEL.OpNo == "OP_061_1")
                    {
                        ObjUctrOP_59.txtWPDS.Text = ObjBLL.GetWPDSForOP_60(ObjBEL.BoreDiameter, ObjBEL.WallThickness);
                        ObjUctrOP_59.txtCollect.Text = ObjBLL.GetFixtureForOP_61(ObjBEL.TubeEndconfiguration);

                        if (ObjBEL.TubeEndconfiguration == "Double Lug")
                        {
                            DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_061_1_2");
                        }
                        else
                        {
                            DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_061_1_1");
                        }
                    }
                    else
                    {
                        ObjUctrOP_59.txtWPDS.Text = "299770";
                        ObjUctrOP_59.txtCollect.Text = "Roller Jig";
                        DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);
                    }
                }


                else if ((ObjBEL.OpNo == "OP_059_1") || (ObjBEL.OpNo == "OP_060_1"))
                {
                    ObjUctrOP_59.Visible = true;
                    ObjUctrOP_59.txtboxWorkInstuction.Text = "WI09-E-106";
                    txtStandardRunTime.Text = ObjBLL.GetStandardRunTimeForAll(ObjBEL).ToString();

                    if (ObjBEL.OpNo == "OP_059_1")
                    {
                        ObjUctrOP_59.txtboxWorkInstuction.Text = "WI09-E-106";
                        DataTable ObjDataTableforOP_59 = ObjBLL.GetWPDSForOP_59(ObjBEL.BoreDiameter, ObjBEL.WallThickness);
                        ObjUctrOP_59.txtWPDS.Text = ObjDataTableforOP_59.Rows[0].ItemArray[0].ToString();
                        ObjUctrOP_59.txtCollect.Text = ObjDataTableforOP_59.Rows[0].ItemArray[1].ToString();

                        if (Convert.ToInt32(ObjBEL.TubeLength) > 30 && (ObjBEL.Design == "WR"))
                        {
                            DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_059_1_2");
                        }
                        else
                        {
                            DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_059_1_1");
                        }
                    }
                    else
                    {
                        ObjUctrOP_59.txtboxWorkInstuction.Text = "WI09-E-63";
                        ObjUctrOP_59.txtWPDS.Text = ObjBLL.GetWPDSForOP_60(ObjBEL.BoreDiameter, ObjBEL.WallThickness);
                        ObjUctrOP_59.txtCollect.Text = ObjBLL.GetFixtureForOP_60(ObjBEL.BoreDiameter);
                        DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);
                    }
                    DGV_OP_Sheet.AutoResizeColumns();
                }
                else if ((ObjBEL.OpNo == "OP_070_1") || (ObjBEL.OpNo == "OP_070_3"))
                {
                    //  ObjBEL.PinHoleSize = Convert.ToDouble(txtPinHoleSize.Text);
                    //  ObjBEL.HoleDepth = Convert.ToDouble(txtHoleDepth.Text);
                    try
                    {
                        if (ObjBEL.TubeEndconfiguration == "Double Lug")
                        {
                            ObjBEL.HoleDepth = (Convert.ToDouble(txtHoleDepth.Text) * 3);
                        }
                        else
                        {
                            ObjBEL.HoleDepth = Convert.ToDouble(txtHoleDepth.Text);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Enter Valid Hole Depth","Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                    txtStandardRunTime.Text = ObjBLL.GetStandardRunTimeForOP_70(ObjBEL.PartWeight, ObjBEL.PinHoleSize, ObjBEL.HoleDepth);
                    ObjDataTable = ObjBLL.GetWorkcenterDetails(ObjBEL.OpNo);
                    if (ObjBEL.OpNo == "OP_070_1")
                    {
                        DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);
                        DGV_OP_Sheet.AutoResizeColumns();
                    }
                }
                else if (ObjBEL.OpNo == "OP_020_1" || ObjBEL.OpNo == "OP_022_1" || ObjBEL.OpNo == "OP_042_1" || ObjBEL.OpNo == "OP_042_2" || ObjBEL.OpNo == "OP_042_3" || ObjBEL.OpNo == "OP_050_1" || ObjBEL.OpNo == "OP_050_2" || ObjBEL.OpNo == "OP_050_3")
                {
                  
                    dRow = ObjDAL.getDoubleWorkInstructionTooling(ObjBEL);
                    groupBox1.Visible = false;
                    objUctrDoubleWorkInstruction.Visible = true;
                    objUctrDoubleWorkInstruction.txtboxWorkInstuction.Text = dRow.ItemArray[0].ToString();
                    objUctrDoubleWorkInstruction.txtWorkInstruction2.Text = dRow.ItemArray[1].ToString();
                    txtStandardRunTime.Text = ObjBLL.GetStandardRunTimeForAll(ObjBEL).ToString();
                    DGV_OP_Sheet.AutoResizeColumns();
                    if (ObjBEL.OpNo == "OP_042_1" || ObjBEL.OpNo == "OP_042_2" || ObjBEL.OpNo == "OP_042_3")
                    {
                        txtSop.Text = "275322";
                        txtSmallHole.Text = "502031";
                        DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);

                    }
                    else if (ObjBEL.OpNo == "OP_020_1")
                    {
                        if (ObjBEL.Ports == "Radiused")
                        {
                            DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_020_1_1");
                        }
                        else
                        {
                            DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet("OP_020_1_2");
                        }
                    }
                    else
                    {
                        DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);
                    }

                }

                else if (ObjBEL.OpNo == "OP_050_4")
                {
                    txtWorkInstruction.Text = "WI09-E-78";
                    lblTool.Visible = false;
                    txtTool.Visible = false;
                    txtProgram.Visible = false;
                    lblProgram.Visible = false;
                    txtStandardRunTime.Text = ObjBLL.GetStandardRunTimeForAll(ObjBEL).ToString();
                    DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);

                }
                else if (ObjBEL.OpNo == "OP_005")
                {
                    txtWorkInstruction.Visible = false;
                    lblWorkInstruction.Visible = false;
                    txtProgram.Visible = false;
                    lblProgram.Visible = false;
                    txtTool.Width = 100 * 21;
                    txtTool.Text = "ME1 estimated RUN Std	";
                    txtStandardRunTime.Text = ObjBLL.GetStandardRunTimeForAll(ObjBEL).ToString();
                    DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);
                }
                else if (ObjBEL.OpNo == "OP_033_1" || ObjBEL.OpNo == "OP_055_1")
                {
                //    lblTool.Visible = false;
                //    txtTool.Visible = false;
                   
                    objUctrOP33_155_1.txtWorkInstruction.Text = "WI09-E-91";
                    //txtWorkInstruction.Visible = true;
                    //lblWorkInstruction.Visible = true;
                    //txtWorkInstruction2.Visible = false;
                    //lblWorkInstruction2.Visible = false;
                    objUctrOP33_155_1.txtProgram.Text = OP55_1andOP33_1(ObjBEL.BoreDiameter);
                    //txtProgram.Visible = true;
                    //lblProgram.Visible = true;
                    txtStandardRunTime.Text = ObjBLL.GetStandardRunTimeForAll(ObjBEL).ToString();
                    DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);
                }
                else if (ObjBEL.OpNo == "OP_040_1" || ObjBEL.OpNo == "OP_040_2")
                {

                    txtStandardRunTime.Text = ObjBLL.GetStandardRunTimeForAll(ObjBEL).ToString();

                    DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);
                }
                else if (ObjBEL.OpNo == "OP_045_1")
                {
                    txtStandardRunTime.Text = ObjBLL.GetStandardRunTimeForAll(ObjBEL).ToString();

                    DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);
                }
                else if (ObjBEL.OpNo == "OP_011_1" || ObjBEL.OpNo == "OP_011_2" || ObjBEL.OpNo == "OP_011_3")
                {
                    txtStandardRunTime.Text = ObjBLL.GetStandardRunTimeForAll(ObjBEL).ToString();
                    if (ObjBEL.OpNo == "OP_011_3")
                    {
                        txtWorkInstruction.Text = "WI09-E-91";
                        txtWorkInstruction.Visible = true;
                        lblWorkInstruction.Visible = true;
                       // txtWorkInstruction2.Visible = false;
                        txtTool.Visible = false;
                        lblTool.Visible = false;
                        if (cmbBoreDiameter.SelectedItem.ToString() == "3.25")
                        {
                            txtProgram.Text = "O8175";
                        }
                        else if (cmbBoreDiameter.SelectedItem.ToString() == "3.75")
                        {
                            txtProgram.Text = "O8175";
                        }
                        else if (cmbBoreDiameter.SelectedItem.ToString() == "4.25")
                        {
                            txtProgram.Text = "O8219";
                        }
                        else if (cmbBoreDiameter.SelectedItem.ToString() == "4.75")
                        {
                            txtProgram.Text = "O7910";
                        }

                    }
                    else
                    {
                        txtWorkInstruction.Visible = false;
                        lblWorkInstruction.Visible = false;
                        txtProgram.Visible = false;
                        lblProgram.Visible = false;
                        txtTool.Visible = false;
                        lblTool.Visible = false;
                    }

                }
                else if (ObjBEL.OpNo == "OP_054")
                {
                    txtWorkInstruction.Visible = false;
                    lblWorkInstruction.Visible = false;
                    txtProgram.Visible = false;
                    lblProgram.Visible = false;
                    txtTool.Visible = false;
                    lblTool.Visible = false;

                }
                else
                {
                  
                    lblProgram.Visible = true;
                    txtProgram.Visible = true;
                    lblTool.Visible = true;
                    txtTool.Visible = true;
                    if (ObjBEL.OpNo == "OP_010_1" || ObjBEL.OpNo == "OP_010_3" || ObjBEL.OpNo == "OP_010_4" || ObjBEL.OpNo == "OP_010_5")
                    {
                        dRow = ObjDAL.GetToolingData(ObjBEL);
                        txtWorkInstruction.Text = dRow.ItemArray[0].ToString();
                        txtProgram.Text = dRow.ItemArray[1].ToString();
                        txtTool.Text = dRow.ItemArray[2].ToString();
                    }
                    else
                    {
                        dRow = ObjDAL.GetToolData(ObjBEL);
                    }


                    try
                    {
                        txtStandardRunTime.Text = ObjBLL.GetStandardRunTimeForAll(ObjBEL).ToString();
                    }
                    catch
                    {
                    }

                    try
                    {
                        DGV_OP_Sheet.DataSource = ObjBLL.GetOp_sheet(ObjBEL.OpNo);
                        DGV_OP_Sheet.AutoResizeColumns();

                    }
                    catch (Exception ex)
                    {
                    }

                }
            }
        }

        private string OP55_1andOP33_1(string boredia)
        {
            string value = "";
            if (boredia == "1.50")
                value = "O0695";
            else if (boredia == "1.75")
                value = "O0696";
            else if (boredia == "2.00")
                value = "O0665";
            else if (boredia == "2.25")
                value = "O0674";
            else if (boredia == "2.50")
                value = "O0705";
            else if (boredia == "2.75")
                value = "O0677";
            else if (boredia == "3.00(.188)")
                value = "O0701";
            else if (boredia == "3.00(.250)")
                value = "O1041";
            else if (boredia == "3.25")
                value = "O1052";
            else if (boredia == "3.50")
                value = "O0038";
            else if (boredia == "3.75")
                value = "O1097";
            else if (boredia == "4.00")
                value = "O1093";
            else if (boredia == "4.25")
                value = "O1094";
            else if (boredia == "4.50")
                value = "O1095";
            else if (boredia == "5.00")
                value = "O1138";
            return value;
        }

        private void cmbOpNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL = new BEL();
          //  ObjUctrOP_3 = new UserControlForOP_30();
            btnScreenCapture.Enabled = false;

            lblPort.Visible = false;
            cmbPorts.Visible = false;
            objUctrOP33_155_1.Visible = false;
            objUctrDoubleWorkInstruction.Visible = false;
            lblWeldSize.Visible = false;
            cmbWeldSize.Visible = false;
            lblPortType.Visible = false;
            cmbPortType.Visible = false;
            lblWallThickness.Visible = false;
            cmbWallThickness.Visible = false;
            lblTubeEndConfiguration.Visible = false;
            cmbTubeEndConfiguration.Visible = false;
            ObjUctrOP_30.Visible = false;
            ObjUctrOP_59.Visible = false;
            ObjUctrOp_70.Visible = false;
            lblPartWeight.Visible = false;
            cmbPartWeight.Visible = false;
            lblpPinHoleSize.Visible = false;
            txtPinHoleSize.Visible = false;
            txtPinHoleSize.ResetText();
            lblTubeEndConfiguration.Visible = false;
            cmbTubeEndConfiguration.Visible = false;
            lblHoleDepth.Visible = false;
            txtHoleDepth.Visible = false;
            txtHoleDepth.ResetText();
            cmbWeldSize.SelectedIndexChanged -= new EventHandler(cmbWeldSize_SelectedIndexChanged);
            cmbWeldSize.SelectedIndex = -1;
            cmbWeldSize.SelectedIndexChanged += new EventHandler(cmbWeldSize_SelectedIndexChanged);
            ClrearingAllUsercontrolsdata();
           
            
            this.Controls.ClearControls<GroupBox>();
            if (ObjUctrOP_30.txtboxCam.Text !=string.Empty)
            {
                ObjUctrOP_30.txtboxCam.Text = "";
                ObjUctrOP_30.txtboxWorkInstuction.Text = "";
                ObjUctrOP_30.txtboxPortLocator.Text = "";
                ObjUctrOP_30.txtboxWpds.Text = "";
            }
            cmbBoreDiameter.Enabled = true;
            cmbTubeLength.Enabled = false;
            cmbTubeLength.SelectedIndexChanged -= new EventHandler(cmbTubeLength_SelectedIndexChanged);
            cmbTubeLength.SelectedIndex = -1;
            cmbTubeLength.SelectedIndexChanged += new EventHandler(cmbTubeLength_SelectedIndexChanged);
            cmbPortType.Enabled = false;
            cmbWallThickness.SelectedIndexChanged -= new EventHandler(cmbWallThickness_SelectedIndexChanged);
            cmbWallThickness.SelectedIndex = -1;
            cmbWallThickness.SelectedIndexChanged += new EventHandler(cmbWallThickness_SelectedIndexChanged);
            cmbWallThickness.Enabled = false;
            ObjBEL.OpNo = "OP_" + cmbOpNo.SelectedItem.ToString();
            loadBoreDiameter();
            if (ObjBEL.OpNo == "OP_040_1" || ObjBEL.OpNo == "OP_040_2")
                {
                    lblWeldSize.Location = new Point(735, 18);
                    lblWeldSize.Text = "Weld Size :";
                    lblWeldSize.Visible = true;
                    tableLayoutPanel2.Controls.Add(lblWeldSize, 6, 1);
                    lblWeldSize.Dock = DockStyle.Bottom;
                    lblWeldSize.TextAlign = ContentAlignment.MiddleCenter;
                    cmbWeldSize.Location = new Point(875, 7);
                    tableLayoutPanel2.Controls.Add(cmbWeldSize, 7, 1);
                    cmbWeldSize.Visible = true;
                    cmbWeldSize.Dock = DockStyle.Bottom;
                    cmbWeldSize.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbWeldSize.FlatStyle = FlatStyle.Popup;
                    cmbWeldSize.Enabled = false;
                }
            if (ObjBEL.OpNo == "OP_020_1")
            {
                lblPort.Location = new Point(735, 18);
                lblPort.Text = "Port Type :";
                lblPort.Visible = true;
                tableLayoutPanel2.Controls.Add(lblPort, 6, 1);
                lblPort.Dock = DockStyle.Bottom;
                lblPort.TextAlign = ContentAlignment.MiddleCenter;
                cmbPortAngle.Location = new Point(875, 7);
                tableLayoutPanel2.Controls.Add(cmbPorts, 7, 1);
                cmbPorts.Visible = true;
                cmbPorts.Dock = DockStyle.Bottom;
                cmbPorts.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbPorts.FlatStyle = FlatStyle.Popup;
                cmbPorts.Enabled = true;
                cmbPorts.SelectedIndexChanged -= new EventHandler(cmbPorts_SelectedIndexChanged);
                cmbPorts.SelectedIndex = -1;
                cmbPorts.SelectedIndexChanged += new EventHandler(cmbPorts_SelectedIndexChanged);             
            }

            if ((ObjBEL.OpNo == "OP_030_1") || (ObjBEL.OpNo == "OP_031_1") || (ObjBEL.OpNo=="OP_043_1") || (ObjBEL.OpNo=="OP_044_1"))
            {
                if ((ObjBEL.OpNo == "OP_030_1") || (ObjBEL.OpNo=="OP_043_1") || (ObjBEL.OpNo=="OP_044_1"))
                {
                    lblPortType.Visible = true;
                    cmbPortType.Visible = true;
                }
                else
                {
                    lblPortType.Visible = false;
                    cmbPortType.Visible = false;
                }
                if ((ObjBEL.OpNo == "OP_043_1") ||(ObjBEL.OpNo =="OP_044_1"))
                {
                    groupBox1.Visible = false;
                    this.Controls.Add(ObjUctrOP_30);
                    ObjUctrOP_30.Location = UsercontrolLocation;
                    ObjUctrOP_30.Visible = true;

                    lblSop_43.Text = "SOP :";
                    lblSop_43.Dock = DockStyle.Bottom;
                    lblSop_43.TextAlign = ContentAlignment.BottomLeft;
                    lblSop_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9);
                    AddingNewRowToTlp(5, 0, lblSop_43);
                   
                    txtSop_43.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                    txtSop_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9);
                    txtSop_43.Size = new System.Drawing.Size(100,21);
                    txtSop_43.Enabled = false;
                    txtSop_43.ReadOnly = true;
                    ObjUctrOP_30.tableLayoutPanel1.Controls.Add(txtSop_43, 1, 5);
                    if (ObjBEL1.Rephasing == "Yes")
                    {
                        txtSop_43.Enabled = true;
                        txtSop_43.Text = "275375";
                    }
                     else
                    {
                        txtSop_43.Enabled = false;
                        txtSop_43.Clear();
                    }

                }
                else
                {
                    groupBox1.Visible = false;
                    this.Controls.Add(ObjUctrOP_30);
                    ObjUctrOP_30.Location =UsercontrolLocation;
                    ObjUctrOP_30.Visible = true;
                }
            
            } 
            else if(ObjBEL.OpNo=="OP_045_1")
            {
                groupBox1.Visible = false;
               //ObjUctrOp_70.Location = new Point(34, 486);
                ObjUctrOp_70.Location = UsercontrolLocation;
               
                this.Controls.Add(ObjUctrOp_70);
                ObjUctrOp_70.Visible = true;
                ObjUctrOp_70.txtTooling70.Text = "Caution Weight";
            }
            else if ((ObjBEL.OpNo == "OP_059_1") || (ObjBEL.OpNo == "OP_060_1") || (ObjBEL.OpNo == "OP_061_1") || (ObjBEL.OpNo == "OP_062_1" ))
            {
                if (ObjBEL.OpNo =="OP_061_1")
                {
                    lblTubeEndConfiguration.Location = new Point(735, 18);
                    lblTubeEndConfiguration.Text = "TubeEndConfiguration";
                    lblTubeEndConfiguration.Visible = true;
                    tableLayoutPanel2.Controls.Add(lblTubeEndConfiguration, 6, 1);
                    lblTubeEndConfiguration.Dock = DockStyle.Bottom;
                    lblTubeEndConfiguration.TextAlign = ContentAlignment.MiddleCenter;
                    cmbTubeEndConfiguration.Location = new Point(875, 7);
                    tableLayoutPanel2.Controls.Add(cmbTubeEndConfiguration, 7, 1);
                    cmbTubeEndConfiguration.Visible = true;
                    cmbTubeEndConfiguration.Dock = DockStyle.Bottom;
                    cmbTubeEndConfiguration.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbTubeEndConfiguration.FlatStyle = FlatStyle.Popup;
                    cmbTubeEndConfiguration.Enabled = false;
                    lblWallThickness.Location = new Point(735, 18);
                    lblWallThickness.Text = "Wall Thickness";
                    lblWallThickness.Visible = true;
                    tableLayoutPanel2.Controls.Add(lblWallThickness, 0, 2);
                    lblWallThickness.Dock = DockStyle.Bottom;
                    lblWallThickness.TextAlign = ContentAlignment.MiddleCenter;
                    cmbWallThickness.Location = new Point(875, 7);
                    tableLayoutPanel2.Controls.Add(cmbWallThickness, 1, 2);
                    cmbWallThickness.Visible = true;
                    cmbWallThickness.Dock = DockStyle.Bottom;
                    cmbWallThickness.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbWallThickness.FlatStyle = FlatStyle.Popup;
                }
                else if (ObjBEL.OpNo == "OP_062_1" )  //weld size for 40_1_2
                {
                    lblWeldSize.Location = new Point(735, 18);
                    lblWeldSize.Text = "Weld Size :";
                    lblWeldSize.Visible = true;
                    tableLayoutPanel2.Controls.Add(lblWeldSize, 6, 1);
                    lblWeldSize.Dock = DockStyle.Bottom;
                    lblWeldSize.TextAlign = ContentAlignment.MiddleCenter;
                    cmbWeldSize.Location = new Point(875, 7);
                    tableLayoutPanel2.Controls.Add(cmbWeldSize, 7, 1);
                    cmbWeldSize.Visible = true;
                    cmbWeldSize.Dock = DockStyle.Bottom;
                    cmbWeldSize.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbWeldSize.FlatStyle = FlatStyle.Popup;
                    cmbWeldSize.Enabled = false;
                }
                
                else
                {
                    lblWallThickness.Location = new Point(735, 18);
                    lblWallThickness.Text = "Wall Thickness :";
                    lblWallThickness.Visible = true;
                    tableLayoutPanel2.Controls.Add(lblWallThickness, 6, 1);
                    lblWallThickness.Dock = DockStyle.Bottom;
                    lblWallThickness.TextAlign = ContentAlignment.MiddleCenter;
                    cmbWallThickness.Location = new Point(875, 7);
                    tableLayoutPanel2.Controls.Add(cmbWallThickness, 7, 1);
                    cmbWallThickness.Visible = true;
                    cmbWallThickness.Dock = DockStyle.Bottom;
                    cmbWallThickness.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbWallThickness.FlatStyle = FlatStyle.Popup;
                }
                this.Controls.Add(ObjUctrOP_59);
                groupBox1.Visible = false;
                ObjUctrOP_59.Location =UsercontrolLocation;
                if ((ObjBEL.OpNo == "OP_060_1") || (ObjBEL.OpNo=="OP_061_1")||(ObjBEL.OpNo=="OP_062_1"))
                {
                    ObjUctrOP_59.lblCollect.Text = "Fixture";
                }
                else
                {
                    ObjUctrOP_59.lblCollect.Text = "Collect";
                }
                ObjUctrOP_59.Visible = true;

            }
            else if (ObjBEL.OpNo == "OP_020_1" || ObjBEL.OpNo == "OP_022_1" || ObjBEL.OpNo == "OP_042_1" || ObjBEL.OpNo == "OP_042_2" || ObjBEL.OpNo == "OP_042_3" || ObjBEL.OpNo == "OP_050_1" || ObjBEL.OpNo == "OP_050_2" || ObjBEL.OpNo == "OP_050_3")
            {
                groupBox1.Visible = false;
                objUctrDoubleWorkInstruction.Location = UsercontrolLocation;
                this.Controls.Add(objUctrDoubleWorkInstruction);
                objUctrDoubleWorkInstruction.Visible = true;
                ObjUctrOp_70.txtTooling70.Text = "Caution Weight";

            }
            else if (ObjBEL.OpNo == "OP_033_1" || ObjBEL.OpNo == "OP_055_1")
            {
                groupBox1.Visible = false;
                objUctrOP33_155_1.Location = UsercontrolLocation;
                this.Controls.Add(objUctrOP33_155_1);
                objUctrOP33_155_1.Visible = true;
            }
            else if ((ObjBEL.OpNo == "OP_070_1") || (ObjBEL.OpNo == "OP_070_3"))
            {
                cmbBoreDiameter.Enabled = false;
                cmbTubeLength.Enabled = false;
                cmbTubeEndConfiguration.Enabled = true;

                lblPartWeight.Text = "Part Weight :";
                lblPartWeight.Visible = true;
                tableLayoutPanel2.Controls.Add(lblPartWeight, 6, 1);
                lblPartWeight.Dock = DockStyle.Bottom;
                lblPartWeight.TextAlign = ContentAlignment.MiddleCenter;

                cmbPartWeight.Visible = true;
                tableLayoutPanel2.Controls.Add(cmbPartWeight, 7, 1);
                cmbPartWeight.Dock = DockStyle.Bottom;
                cmbPartWeight.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbPartWeight.FlatStyle = FlatStyle.Popup;
                cmbPartWeight.Items.Clear();
                cmbPartWeight.Items.Add("0-10lbs");
                cmbPartWeight.Items.Add("11-15lbs");
                cmbPartWeight.Items.Add("16-20lbs");
                cmbPartWeight.Items.Add("21-40lbs");
                cmbPartWeight.SelectedIndexChanged -= new EventHandler(cmbPartWeight_SelectedIndexChanged);
                cmbPartWeight.SelectedIndex = -1;
                cmbPartWeight.SelectedIndexChanged += new EventHandler(cmbPartWeight_SelectedIndexChanged);

                lblpPinHoleSize.Text = "PinHole Size :";
                lblpPinHoleSize.Visible = true;
                tableLayoutPanel2.Controls.Add(lblpPinHoleSize, 0, 2);
                lblpPinHoleSize.Dock = DockStyle.Bottom;
                lblpPinHoleSize.TextAlign = ContentAlignment.MiddleCenter;

                txtPinHoleSize.Visible = true;
                tableLayoutPanel2.Controls.Add(txtPinHoleSize, 1, 2);
                txtPinHoleSize.Dock = DockStyle.Bottom;
                txtPinHoleSize.Leave += new EventHandler(PinHoleSize_Leave);

                lblTubeEndConfiguration.Text = "TubeEndConfiguration :";
                lblTubeEndConfiguration.Visible = true;
                tableLayoutPanel2.Controls.Add(lblTubeEndConfiguration, 2, 2);
                lblTubeEndConfiguration.Dock = DockStyle.Bottom;
                lblTubeEndConfiguration.TextAlign = ContentAlignment.MiddleCenter;

                cmbTubeEndConfiguration.Visible = true;
                tableLayoutPanel2.Controls.Add(cmbTubeEndConfiguration, 3, 2);
                cmbTubeEndConfiguration.Dock = DockStyle.Bottom;
                cmbTubeEndConfiguration.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbTubeEndConfiguration.FlatStyle = FlatStyle.Popup;
                cmbTubeEndConfiguration.Items.Clear();
                cmbTubeEndConfiguration.Items.Add("Cross Tube");
                cmbTubeEndConfiguration.Items.Add("Single Lug");
                cmbTubeEndConfiguration.Items.Add("Base plug");
                cmbTubeEndConfiguration.Items.Add("Double Lug");
                cmbTubeEndConfiguration.SelectedIndexChanged -= new EventHandler(cmbTubeEndConfiguration_SelectedIndexChanged);
                cmbTubeEndConfiguration.SelectedIndex = -1;
                cmbTubeEndConfiguration.SelectedIndexChanged += new EventHandler(cmbTubeEndConfiguration_SelectedIndexChanged);
                lblHoleDepth.Text = "Hole Depth :";
                lblHoleDepth.Visible = true;
                tableLayoutPanel2.Controls.Add(lblHoleDepth, 4, 2);
                lblHoleDepth.Dock = DockStyle.Bottom;
                lblHoleDepth.TextAlign = ContentAlignment.MiddleCenter;

                txtHoleDepth.Visible = true;
                tableLayoutPanel2.Controls.Add(txtHoleDepth, 5, 2);
                txtHoleDepth.Dock = DockStyle.Bottom;
                txtHoleDepth.Leave += new EventHandler(HoleDepth_Leave);
                txtHoleDepth.Click += new EventHandler(txtHoleDepth_Onclick);

                groupBox1.Visible = false;
                ObjUctrOp_70.Location = UsercontrolLocation;
                this.Controls.Add(ObjUctrOp_70);
                ObjUctrOp_70.Visible = true;

            }

            else
            {
                groupBox1.Visible = true;
                lblPortType.Visible = false;
                cmbPortType.Visible = false;
                lblWallThickness.Visible = false;
                cmbWallThickness.Visible = false;
            }
        }
        private void cmbBoreDiameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL.TubeLength = null;
            ObjBEL.BoreDiameter = cmbBoreDiameter.SelectedItem.ToString();  
            if (ObjBEL.OpNo == "OP_005" || ObjBEL.OpNo == "OP_054")
            {
                cmbTubeLength.Items.Clear();
                loadTubeLength();
                cmbTubeLength.Enabled = true;
            }
            else if ((ObjBEL.OpNo == "OP_059_1") || (ObjBEL.OpNo=="OP_060_1") || (ObjBEL.OpNo=="OP_061_1")||(ObjBEL.OpNo=="OP_062_1"))
            {
                cmbTubeLength.Items.Clear();
                cmbTubeLength.Enabled = true;
                cmbTubeLength.Items.AddRange(new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60","61"
                ,"62","63","64","65","66","67","68","69","70","71","72"});
                if ((ObjBEL.OpNo == "OP_059_1") || (ObjBEL.OpNo == "OP_060_1") || (ObjBEL.OpNo == "OP_061_1"))
                {
                    if (ObjBEL.OpNo == "OP_061_1")
                    {
                        cmbTubeEndConfiguration.Items.Clear();
                        cmbTubeEndConfiguration.SelectedIndexChanged -= new EventHandler(cmbTubeEndConfiguration_SelectedIndexChanged);
                        cmbTubeEndConfiguration.Items.Add("Cross Tube");
                        cmbTubeEndConfiguration.Items.Add("Single Lug");
                        cmbTubeEndConfiguration.Items.Add("U-Lug");
                        cmbTubeEndConfiguration.Items.Add("Double Lug");
                        cmbTubeEndConfiguration.SelectedIndex = -1;
                        cmbTubeEndConfiguration.SelectedIndexChanged += new EventHandler(cmbTubeEndConfiguration_SelectedIndexChanged);
                    }
                    DataTable ObjDatatable = ObjBLL.WallThickness(ObjBEL.BoreDiameter);
                    //cmbWallThickness.Items.Clear();
                    cmbWallThickness.SelectedIndexChanged -= new EventHandler(cmbWallThickness_SelectedIndexChanged);
                    cmbWallThickness.DataSource = ObjDatatable;
                    cmbWallThickness.DisplayMember = "WallThickness";
                    cmbWallThickness.SelectedIndex = -1;
                    cmbWallThickness.SelectedIndexChanged += new EventHandler(cmbWallThickness_SelectedIndexChanged);
                }
                else
                {
                    cmbWeldSize.Items.Clear();
                    cmbWeldSize.SelectedIndexChanged -= new EventHandler(cmbWeldSize_SelectedIndexChanged);
                    cmbWeldSize.Items.Add("1/4\" Weld");
                    cmbWeldSize.Items.Add("Less Than 1/4\" Weld");
                    cmbWeldSize.Items.Add("Greater 1/4\" Weld");
                    cmbWeldSize.SelectedIndex = -1;
                    cmbWeldSize.SelectedIndexChanged += new EventHandler(cmbWeldSize_SelectedIndexChanged);
                }
            }
            else if (ObjBEL.OpNo == "OP_040_1" || ObjBEL.OpNo == "OP_040_2")
            {
                cmbTubeLength.Items.Clear();
                cmbTubeLength.Enabled = true;
                cmbTubeLength.Items.AddRange(new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60","61"
                ,"62","63","64","65","66","67","68","69","70","71","72"});

                cmbWeldSize.Items.Clear();
                cmbWeldSize.Items.Add("0.188");
                cmbWeldSize.Items.Add("0.250");
                cmbWeldSize.SelectedIndex = 0;
                lblTool.Text = "Gauge";
                lblTool.Visible = true;
                txtWorkInstruction.Text = "WI09-E-91";
                txtWorkInstruction.Visible = true;

            }
            else if (ObjBEL.OpNo == "OP_020_1")
            {
                cmbTubeLength.Items.Clear();
                cmbTubeLength.Enabled = true;
                cmbTubeLength.Items.AddRange(new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60","61"
                ,"62","63","64","65","66","67","68","69","70","71","72"});
                cmbPorts.Enabled = true;
                cmbPorts.Items.Clear();
                cmbPorts.Items.Add("Radiused");
                cmbPorts.Items.Add("Flat");
                cmbPorts.SelectedIndex = 0;

            }
            else
            {
                cmbTubeLength.Items.Clear();
                cmbTubeLength.Enabled = true;
                cmbTubeLength.Items.AddRange(new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60" });
            }
            
        }


        private void LoadWeldSize()
        {
            if ((ObjBEL.OpNo == "OP_040_1" || ObjBEL.OpNo == "OP_040_2"))
            {
                if (cmbBoreDiameter.SelectedItem.ToString() == "1.50")
                {
                    cmbWeldSize.SelectedIndex = 0;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "01515";
                    txtTool.Text = "TB7";
                }
                else if (cmbBoreDiameter.SelectedItem.ToString() == "1.75")
                {
                    cmbWeldSize.SelectedIndex = 0;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "O1715";
                    txtTool.Text = "TB6";
                }

                else if (cmbBoreDiameter.SelectedItem.ToString() == "2.00")
                {
                    cmbWeldSize.SelectedIndex = 0;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "O2015";
                    txtTool.Text = "TB5";
                }
                else if (cmbBoreDiameter.SelectedItem.ToString() == "2.25")
                {
                    cmbWeldSize.SelectedIndex = 0;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "O2215";
                    txtTool.Text = "TB013";
                }
                else if (cmbBoreDiameter.SelectedItem.ToString() == "2.50")
                {
                    cmbWeldSize.SelectedIndex = 0;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "O2515";
                    txtTool.Text = "TB4";
                }
                else if (cmbBoreDiameter.SelectedItem.ToString() == "2.75")
                {
                    cmbWeldSize.SelectedIndex = 0;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "O3015";
                    txtTool.Text = "TB9";
                }
                else if (cmbBoreDiameter.SelectedItem.ToString() == "3.00(.188)")
                {
                    cmbWeldSize.SelectedIndex = 0;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "O3015";
                    txtTool.Text = "TB11";
                }
                else if (cmbBoreDiameter.SelectedItem.ToString() == "3.00(.250)")
                {
                    cmbWeldSize.SelectedIndex = 0;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "O3025";
                    txtTool.Text = "TB11";
                }
                else if (cmbBoreDiameter.SelectedItem.ToString() == "3.25")
                {
                    cmbWeldSize.SelectedIndex = 0;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "O3515";
                    txtTool.Text = "TB012";
                }
                else if (cmbBoreDiameter.SelectedItem.ToString() == "3.50")
                {
                    if (cmbWeldSize.SelectedItem.ToString() == "0.188")
                    {
                        txtProgram.Text = "O3515";
                    }
                    else
                    {
                        txtProgram.Text = "O3525";
                    }
                    txtTool.Text = "TB22";
                }
                else if (cmbBoreDiameter.SelectedItem.ToString() == "4.00")
                {
                    cmbWeldSize.SelectedIndex = 1;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "O4025";
                    txtTool.Text = "TB31";
                }
                else if (cmbBoreDiameter.SelectedItem.ToString() == "4.50")
                {
                    cmbWeldSize.SelectedIndex = 1;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "O4525";
                    txtTool.Text = "TB011-1";
                }
                else if (cmbBoreDiameter.SelectedItem.ToString() == "5.00")
                {
                    cmbWeldSize.SelectedIndex = 1;
                    cmbWeldSize.Enabled = false;
                    txtProgram.Text = "O4525";
                }
            }
                     
        }

        private void cmbTubeLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPortType.Enabled = true;
            ObjBEL.TubeLength = cmbTubeLength.SelectedItem.ToString();
            cmbWallThickness.Enabled = true;
            cmbTubeEndConfiguration.Enabled = true;
            cmbWeldSize.Enabled = true;
            if ((ObjBEL.OpNo == "OP_040_1" || ObjBEL.OpNo == "OP_040_2"))
            {

                LoadWeldSize();
            }
            
        }

        private void cmbWallThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL.WallThickness = ((System.Data.DataRowView)(cmbWallThickness.SelectedItem)).Row.ItemArray[0].ToString();
        }

        private void cmbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL.Ports = cmbPorts.SelectedItem.ToString();
        }
        private void cmbTubeEndConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL.TubeEndconfiguration = cmbTubeEndConfiguration.SelectedItem.ToString();
            if ((ObjBEL.OpNo == "OP_070_1") || (ObjBEL.OpNo == "OP_070_3"))
            {
                if (ObjBEL.TubeEndconfiguration == "Cross Tube")
                {
                    txtHoleDepth.Text = "Enter Width";
                }
                else if (ObjBEL.TubeEndconfiguration == "Single Lug")
                {

                    txtHoleDepth.Text = "Enter Lug width";
                }
                else if (ObjBEL.TubeEndconfiguration == "Base plug")
                {
                    txtHoleDepth.Text = "Enter Diameter";
                }
                else
                {
                    txtHoleDepth.Text = "Enter Lug thickness";
                }
                    
            }
                
            btnSaveToNotepad.Enabled = false;
        }
        private void txtHoleDepth_Onclick(object sender, EventArgs e)
        {
            txtHoleDepth.ResetText();
        }
        private void cmbWeldSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL.WeldSize = cmbWeldSize.SelectedItem.ToString();
        }


        private void cmbPartWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL.PartWeight = cmbPartWeight.SelectedItem.ToString();
        }

        private void PinHoleSize_Leave(object sender, EventArgs e)
        {
            try
            {
                ObjBEL.PinHoleSize = Convert.ToDouble(txtPinHoleSize.Text);
            }
            catch
            {
            }
        }
        private void HoleDepth_Leave(object sender, EventArgs e)
        {
            try
            {
                ObjBEL.HoleDepth = Convert.ToDouble(txtHoleDepth.Text);
            }
            catch
            {
            }
        }
        private void loadTubeLength()
        {

            cmbTubeLength.Items.AddRange(new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"});

        }
       
        private void cmbPortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL.PortType = cmbPortType.SelectedItem.ToString();
        }

        private void CMSTool_Load(object sender, EventArgs e)
        {
            UsercontrolLocation = groupBox1.Location;
            //ObjBEL = new BEL();
            //txtWorkInstruction2.Visible = false;
            //lblWorkInstruction2.Visible = false;
            cmbOrificeSize.DrawItem += new DrawItemEventHandler(cmbOrificeSize_DrawItem);
            cmbOrificeSize.MeasureItem += new MeasureItemEventHandler(cmbOrificeSize_MeasureItem);
            cmbFabricationDrillingHole.DrawItem += new DrawItemEventHandler(cmbFabrication_DrawItem);
            cmbFabricationDrillingHole.MeasureItem += new MeasureItemEventHandler(cmbFabrication_MeasureItem);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
       
        private void loadBoreDiameter()
        {
            // ObjBEL.OpNo = cmbOpNo.SelectedItem.ToString();
            cmbBoreDiameter.Items.Clear();
            ObjBEL.OpNo = "OP_" + cmbOpNo.SelectedItem.ToString();
            LoadControls();
            switch (ObjBEL.OpNo)
            {
                case "OP_011_3":

                    cmbBoreDiameter.Items.Add("3.25");
                    cmbBoreDiameter.Items.Add("3.75");
                    cmbBoreDiameter.Items.Add("4.25");
                    cmbBoreDiameter.Items.Add("4.75");
                    break;
                case "OP_059_1":
                    cmbBoreDiameter.Items.Add("1.00");
                    cmbBoreDiameter.Items.Add("1.25");
                    cmbBoreDiameter.Items.Add("1.50");
                    cmbBoreDiameter.Items.Add("1.75");
                    cmbBoreDiameter.Items.Add("2.00");
                    cmbBoreDiameter.Items.Add("2.25");
                    cmbBoreDiameter.Items.Add("2.50");
                    cmbBoreDiameter.Items.Add("2.75");
                    cmbBoreDiameter.Items.Add("3.00");
                    cmbBoreDiameter.Items.Add("3.25");
                    cmbBoreDiameter.Items.Add("3.50");
                    cmbBoreDiameter.Items.Add("3.75");
                    cmbBoreDiameter.Items.Add("4.00");
                    cmbBoreDiameter.Items.Add("4.25");
                    cmbBoreDiameter.Items.Add("4.50");
                    cmbBoreDiameter.Items.Add("5.00");
                    break;
                case "OP_060_1":
                case "OP_061_1":
                case "OP_062_1":
                    cmbBoreDiameter.Items.Add("1.00");
                    cmbBoreDiameter.Items.Add("1.25");
                    cmbBoreDiameter.Items.Add("1.50");
                    cmbBoreDiameter.Items.Add("1.75");
                    cmbBoreDiameter.Items.Add("2.00");
                    cmbBoreDiameter.Items.Add("2.25");
                    cmbBoreDiameter.Items.Add("2.50");
                    cmbBoreDiameter.Items.Add("2.75");
                    cmbBoreDiameter.Items.Add("3.00");
                    cmbBoreDiameter.Items.Add("3.25");
                    cmbBoreDiameter.Items.Add("3.50");          
                    cmbBoreDiameter.Items.Add("4.00");
                    cmbBoreDiameter.Items.Add("4.50");
                    cmbBoreDiameter.Items.Add("5.00");
                    cmbBoreDiameter.Items.Add("5.50");
                    cmbBoreDiameter.Items.Add("6.00");
                    break;
                case "OP_050_4":

                    cmbBoreDiameter.Items.Add("2.00");
                    cmbBoreDiameter.Items.Add("2.25");
                    cmbBoreDiameter.Items.Add("2.50");
                    cmbBoreDiameter.Items.Add("2.75");
                    cmbBoreDiameter.Items.Add("3.00");
                    cmbBoreDiameter.Items.Add("3.25");
                    cmbBoreDiameter.Items.Add("3.50");
                    cmbBoreDiameter.Items.Add("4.00");
                    cmbBoreDiameter.Items.Add("4.50");
                    cmbBoreDiameter.Items.Add("5.00");
                    break;
                case "OP_022_1":
                case "OP_050_1":
                case "OP_050_2":
                case "OP_050_3":

                    cmbBoreDiameter.Items.Add("1.50");
                    cmbBoreDiameter.Items.Add("1.75");
                    cmbBoreDiameter.Items.Add("2.00");
                    cmbBoreDiameter.Items.Add("2.25");
                    cmbBoreDiameter.Items.Add("2.50");
                    cmbBoreDiameter.Items.Add("3.00");
                    cmbBoreDiameter.Items.Add("3.50");
                    cmbBoreDiameter.Items.Add("4.00");
                    cmbBoreDiameter.Items.Add("4.50");
                    cmbBoreDiameter.Items.Add("5.00");
                    break;
                case "OP_020_1":
                case "OP_042_1":
                case "OP_042_2":
                case "OP_042_3":

                    cmbBoreDiameter.Items.Add("1.50");
                    cmbBoreDiameter.Items.Add("1.75");
                    cmbBoreDiameter.Items.Add("2.00");
                    cmbBoreDiameter.Items.Add("2.50");
                    cmbBoreDiameter.Items.Add("2.75");
                    cmbBoreDiameter.Items.Add("3.00(.188)");
                    cmbBoreDiameter.Items.Add("3.00(.250)");
                    cmbBoreDiameter.Items.Add("3.50");
                    cmbBoreDiameter.Items.Add("4.00");
                    cmbBoreDiameter.Items.Add("4.50");
                    cmbBoreDiameter.Items.Add("5.00");
                    break;

                case "OP_010_4":

                    cmbBoreDiameter.Items.Add("1.50");
                    cmbBoreDiameter.Items.Add("1.75");
                    cmbBoreDiameter.Items.Add("2.00");
                    cmbBoreDiameter.Items.Add("2.25");
                    cmbBoreDiameter.Items.Add("2.50");
                    cmbBoreDiameter.Items.Add("2.75");
                    cmbBoreDiameter.Items.Add("3.00");
                    cmbBoreDiameter.Items.Add("3.50");
                    cmbBoreDiameter.Items.Add("4.00");
                    cmbBoreDiameter.Items.Add("4.50");
                    cmbBoreDiameter.Items.Add("5.00");
                    break;
                default:
                    cmbBoreDiameter.Items.Add("1.50");
                    cmbBoreDiameter.Items.Add("1.75");
                    cmbBoreDiameter.Items.Add("2.00");
                    cmbBoreDiameter.Items.Add("2.25");
                    cmbBoreDiameter.Items.Add("2.50");
                    cmbBoreDiameter.Items.Add("2.75");
                    cmbBoreDiameter.Items.Add("3.00(.188)");
                    cmbBoreDiameter.Items.Add("3.00(.250)");
                    cmbBoreDiameter.Items.Add("3.50");
                    cmbBoreDiameter.Items.Add("4.00");
                    cmbBoreDiameter.Items.Add("4.50");
                    cmbBoreDiameter.Items.Add("5.00");
                    break;
            }
        }
        private void LoadControls()
        {
            ObjBEL.OpNo = "OP_" + cmbOpNo.SelectedItem.ToString();
            if (ObjBEL.OpNo == "OP_042_1" || ObjBEL.OpNo == "OP_042_2" || ObjBEL.OpNo == "OP_042_3")
            {
                //lblWorkInstruction2.Visible = true;
                //txtWorkInstruction2.Visible = true;
                lblProgram.Visible = false;
                txtProgram.Visible = false;
                lblTool.Visible = false;
                txtTool.Visible = false;
                lblSmallHole.Visible = true;
                txtSmallHole.Visible = true;
                lblSOP.Visible = true;
                txtSop.Visible = true;
            }
            //else if (ObjBEL.OpNo == "OP_005")
            //{
            //    txtTool.Text = "ME1  estimated RUN Std";              
            //}
            else
            {
            }

        }
        private void btnSaveToNotepad_Click(object sender, EventArgs e)
        {
            if (ObjBEL.OpNo == "OP_070_3")
            {
                MessageBox.Show("Leave Operation Sheet Blank, Note in Action List Process Engineer to Set Up 199 OP");
            }
            else if (ObjBEL.OpNo == "OP_054")
            {
                MessageBox.Show("No Details Page for OP_054");
            }
            else if (ObjBEL.OpNo == "OP_011_1" || ObjBEL.OpNo == "OP_011_2" || ObjBEL.OpNo == "OP_011_3")
            {
                string str = System.Environment.CurrentDirectory + "\\DetailingSheet\\";
                string filename = str + ObjBEL.OpNo + ".txt";
                System.Diagnostics.Process.Start(filename);
              
                
            }
            else
            {
                sfd.Filter = "Text Files (*.txt)|*.txt";
                sfd.FileName = ObjBEL.OpNo + ".txt";
                sfd.CreatePrompt = true;
                ToNotePad(DGV_OP_Sheet, sfd.FileName);
                string filename = sfd.FileName;
                System.Diagnostics.Process.Start(filename);
            }
        }

        private void ToNotePad(DataGridView dgv, string filename)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
            try
            {
                string sLine = "";
                for (int r = 0; r <= dgv.Rows.Count - 1; r++)
                {
                    for (int c = 0; c <= dgv.Columns.Count - 1; c++)
                    {
                        sLine = sLine + dgv.Rows[r].Cells[c].Value;
                        if (c != dgv.Columns.Count - 1)
                        {
                            sLine = sLine + "            ";
                        }
                    }
                    file.WriteLine(sLine);
                    sLine = "";
                }

                file.Close();
            }
            catch (System.Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                file.Close();
            }
        }

        private void LoadCylinderHead()
        {
            if (cmbDesign.SelectedItem.ToString() == "Conventional")
            {
                cmbCylinderHead.Items.Add("THD");
                cmbCylinderHead.Items.Add("RR");
            }
            else
            {
                cmbCylinderHead.Items.Add("RR");
             
                cmbCylinderHead.SelectedIndex = 0;
              
            }
        }
        private void LoadRephasing()
        {
           
            if ((cmbCylinderHead.SelectedItem.ToString() == "THD") || ((cmbDesign.SelectedItem.ToString() == "WR") && (cmbCylinderHead.SelectedItem.ToString() == "RR") && (cmbTubeMaterial.SelectedItem.ToString() == "Honed")))
            {
                cmbRephasing.Items.Clear();
                cmbRephasing.Items.Add("No");
                cmbRephasing.SelectedIndex = 0;
                cmbRephasing.Enabled = false;
              
            }
            else
            {
                cmbRephasing.Enabled = true;
                cmbRephasing.Items.Clear();
                cmbRephasing.Items.Add("Yes");
                cmbRephasing.Items.Add("No");
            }
        }
        public void LoadMultipleOP()
        {
            int no = int.Parse(txtFlowPath.Text);
            switch(no)
            {
                case 1:
                cmbOpNo.Items.Add("010_1");
                cmbOpNo.Items.Add("020_1");
                cmbOpNo.Items.Add("030_1");
                if (chkOP031_1.Checked == true)
                {
                    cmbOpNo.Items.Add("031_1");
                }
                LoadFlowPath(3);
                LoadFlowPath(5);
                cmbOpNo.Items.Add("060_1");
                if (chkOP070_3.Checked == true)
                {
                    cmbOpNo.Items.Add("070_3");
                }
                break;
                case 2:
                cmbOpNo.Items.Add("010_1");
                cmbOpNo.Items.Add("020_1");
                cmbOpNo.Items.Add("030_1");
                if (chkOP031_1.Checked == true)
                {
                    cmbOpNo.Items.Add("031_1");
                }
                LoadFlowPath(3);
                LoadFlowPath(5);    
                cmbOpNo.Items.Add("060_1");
                if (chkOP062_1.Checked == true)
                {
                    cmbOpNo.Items.Add("062_1");
                }
                LoadFlowPath(6);
                break;
                case 3:
                cmbOpNo.Items.Add("011_1");
                cmbOpNo.Items.Add("020_1");
                cmbOpNo.Items.Add("030_1");
                if (chkOP031_1.Checked == true)
                {
                    cmbOpNo.Items.Add("031_1");
                }
                LoadFlowPath(3);
                cmbOpNo.Items.Add("060_1");
                if (chkOP070_3.Checked == true)
                {
                    cmbOpNo.Items.Add("070_3");
                }
                break;
                case 4:
                cmbOpNo.Items.Add("011_1");
                cmbOpNo.Items.Add("020_1");
                cmbOpNo.Items.Add("030_1");
                if (chkOP031_1.Checked == true)
                {
                    cmbOpNo.Items.Add("031_1");
                }
                LoadFlowPath(3);
                cmbOpNo.Items.Add("061_1");
                if (chkOP062_1.Checked == true)
                {
                    cmbOpNo.Items.Add("062_1");
                }
                LoadFlowPath(6);
                break;
                case 5:
                cmbOpNo.Items.Add("010_1");
                cmbOpNo.Items.Add("020_1");
                cmbOpNo.Items.Add("030_1");
                if (chkOP031_1.Checked == true)
                {
                    cmbOpNo.Items.Add("031_1");
                }
                LoadFlowPath(4);
                LoadFlowPath(5);
                cmbOpNo.Items.Add("055_1");
                cmbOpNo.Items.Add("060_1");
                if (chkOP070_3.Checked == true)
                {
                    cmbOpNo.Items.Add("070_3");
                }
                break;
                case 6:
                cmbOpNo.Items.Add("010_1");
                cmbOpNo.Items.Add("020_1");
                cmbOpNo.Items.Add("030_1");
                if (chkOP031_1.Checked == true)
                {
                    cmbOpNo.Items.Add("031_1");
                }
                LoadFlowPath(4);
                LoadFlowPath(5);
                cmbOpNo.Items.Add("055_1");
                cmbOpNo.Items.Add("061_1");
                if (chkOP062_1.Checked == true)
                {
                    cmbOpNo.Items.Add("062_1");
                }
                LoadFlowPath(6);
                break;
                case 7:
                cmbOpNo.Items.Add("011_1");
                cmbOpNo.Items.Add("020_1");
                cmbOpNo.Items.Add("030_1");
                if (chkOP031_1.Checked == true)
                {
                    cmbOpNo.Items.Add("031_1");
                }
                cmbOpNo.Items.Add("055_1");
                cmbOpNo.Items.Add("060_1");
                if (chkOP070_3.Checked == true)
                {
                    cmbOpNo.Items.Add("070_3");
                }
                break;
                case 8:
                cmbOpNo.Items.Add("011_1");
                cmbOpNo.Items.Add("020_1");
                cmbOpNo.Items.Add("030_1");
                if (chkOP031_1.Checked == true)
                {
                    cmbOpNo.Items.Add("031_1");
                }
                cmbOpNo.Items.Add("055_1");
                cmbOpNo.Items.Add("061_1");
                if (chkOP062_1.Checked == true)
                {
                    cmbOpNo.Items.Add("062_1");
                }
                LoadFlowPath(6);
                break;
                case 9:
                LoadFlowPath(1);
                cmbOpNo.Items.Add("050_4");
                if (chkOP054.Checked == true)
                {
                    cmbOpNo.Items.Add("054");
                }
                cmbOpNo.Items.Add("059_1");
                cmbOpNo.Items.Add("060_1");
                if (chkOP070_3.Checked == true)
                {
                    cmbOpNo.Items.Add("070_3");
                }
                break;
                case 10:
                LoadFlowPath(1);
                cmbOpNo.Items.Add("050_4");
                if (chkOP054.Checked == true)
                {
                    cmbOpNo.Items.Add("054");
                }
                cmbOpNo.Items.Add("059_1");
                cmbOpNo.Items.Add("061_1");
                if (chkOP062_1.Checked == true)
                {
                    cmbOpNo.Items.Add("062_1");
                }
                LoadFlowPath(6);
                break;
                case 11:
                cmbOpNo.Items.Add("005");
                LoadFlowPath(2);
                cmbOpNo.Items.Add("059_1");
                cmbOpNo.Items.Add("060_1");
                if (chkOP070_3.Checked == true)
                {
                    cmbOpNo.Items.Add("070_3");
                }
                break;
                case 12:
                cmbOpNo.Items.Add("005");
                LoadFlowPath(2);
                cmbOpNo.Items.Add("059_1");
                cmbOpNo.Items.Add("061_1");
                if (chkOP062_1.Checked == true)
                {
                    cmbOpNo.Items.Add("062_1");
                }
                LoadFlowPath(6);
                break;
                case 13:
                cmbOpNo.Items.Add("010_1");
                cmbOpNo.Items.Add("022_1");
                cmbOpNo.Items.Add("033_1");
                LoadFlowPath(7);
                cmbOpNo.Items.Add("043_1");
                if (chkOP044_1.Checked == true)
                {
                    cmbOpNo.Items.Add("044_1");
                }
                LoadFlowPath(4);
                cmbOpNo.Items.Add("060_1");
                if (chkOP070_3.Checked == true)
                {
                    cmbOpNo.Items.Add("070_3");
                }
                break;
                case 14:
                cmbOpNo.Items.Add("010_1");
                cmbOpNo.Items.Add("022_1");
                cmbOpNo.Items.Add("033_1");
                LoadFlowPath(7);
                cmbOpNo.Items.Add("043_1");
                if (chkOP044_1.Checked == true)
                {
                    cmbOpNo.Items.Add("044_1");
                }
                LoadFlowPath(4);
                cmbOpNo.Items.Add("061_1");
                if (chkOP062_1.Checked == true)
                {
                    cmbOpNo.Items.Add("062_1");
                }
                LoadFlowPath(6);
                break;
                case 15:
                LoadFlowPath(1);
                cmbOpNo.Items.Add("042_3");
                cmbOpNo.Items.Add("050_2");
                cmbOpNo.Items.Add("059_1");
                cmbOpNo.Items.Add("060_1");
                if (chkOP070_3.Checked == true)
                {
                    cmbOpNo.Items.Add("070_3");
                }
                break;
                case 16:
                LoadFlowPath(1);
                cmbOpNo.Items.Add("042_3");
                cmbOpNo.Items.Add("050_2");
                cmbOpNo.Items.Add("059_1");
                cmbOpNo.Items.Add("061_1");
                if (chkOP062_1.Checked == true)
                {
                    cmbOpNo.Items.Add("062_1");
                }
                LoadFlowPath(6);
                break;
                case 17:
                cmbOpNo.Items.Add("011_1");
                cmbOpNo.Items.Add("033_1");
                LoadFlowPath(7);
                cmbOpNo.Items.Add("043_1");
                if (chkOP044_1.Checked == true)
                {
                    cmbOpNo.Items.Add("044_1");
                }
                LoadFlowPath(4);
                cmbOpNo.Items.Add("060_1");
                if (chkOP070_3.Checked == true)
                {
                    cmbOpNo.Items.Add("070_3");
                }
                break;
                case 18:
                cmbOpNo.Items.Add("011_1");
                cmbOpNo.Items.Add("033_1");
                LoadFlowPath(7);
                cmbOpNo.Items.Add("043_1");
                if (chkOP044_1.Checked == true)
                {
                    cmbOpNo.Items.Add("044_1");
                }
                LoadFlowPath(4);
                cmbOpNo.Items.Add("061_1");
                if (chkOP062_1.Checked == true)
                {
                    cmbOpNo.Items.Add("062_1");
                }
                LoadFlowPath(6);
                break;
                default:
                break;
            }

        }
        public void LoadFlowPath(int no)
        {
            try
            {
                switch (no)
                {
                    case 1:
                        if (cmbWeldType.SelectedItem.ToString() == "Fillet Weld")
                        {
                            cmbOpNo.Items.Add("010_3");
                        }
                        else
                        {
                            cmbOpNo.Items.Add("010_4");
                        }
                        break;

                    case 2:
                        if (cmbWeldType.SelectedItem.ToString() == "Fillet Weld")
                        {
                            cmbOpNo.Items.Add("011_2");
                        }
                        else
                        {
                            cmbOpNo.Items.Add("011_3");
                        }
                        break;

                    case 3:
                        if (cmbPortOrientation.SelectedItem.ToString() == "90 Ports")
                        {
                            cmbOpNo.Items.Add("040_2");
                        }
                        else
                        {
                            cmbOpNo.Items.Add("040_1");
                        }

                        break;

                    case 4:
                        if (cmbPortAngle.SelectedItem.ToString() == "St Ports or one 90 Port")
                        {
                            cmbOpNo.Items.Add("045_1");
                        }
                        else
                        {
                            cmbOpNo.Items.Add("045_2");
                        }
                        break;

                    case 5:
                        if (cmbOrificeSize.SelectedItem.ToString() == "both orifices 0.125 or above")
                        {
                            cmbOpNo.Items.Add("050_1");
                        }
                        else if (cmbOrificeSize.SelectedItem.ToString() == "both orifices below 0.125")
                        {
                            cmbOpNo.Items.Add("050_2");
                        }
                        else
                        {
                            cmbOpNo.Items.Add("050_3");
                        }
                        break;
                    case 6:
                        if (cmbFabricationDrillingHole.SelectedItem.ToString() == "SL || DL || UL W/O pre drilled hole")
                        {
                            cmbOpNo.Items.Add("070_1");
                        }
                        else
                        {
                            cmbOpNo.Items.Add("070_3");
                        }
                        break;
                    case 7:
                        if (cmbRephasingAt.SelectedItem.ToString() == "One End")
                        {
                            cmbOpNo.Items.Add("042_1");
                        }
                        else
                        {
                            cmbOpNo.Items.Add("042_2");
                        }
                        break;

                    default:
                        break;

                }
            }
            catch
            {
                MessageBox.Show("You Have Missed To Fill Some Fileds Please Check It Once","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void cmbDesign_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ResetControls();
            cmbCylinderHead.Items.Clear();
            cmbCylinderHead.Text = "";        
            ObjBEL1.Design = cmbDesign.SelectedItem.ToString();
            cmbCylinderHead.Enabled = true;
            LoadCylinderHead();
        }

        private void cmbCylinderHead_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BaseEndReset();
            CommonResetControls();
            ObjBEL1.CylinderHead = cmbCylinderHead.SelectedItem.ToString();
            cmbTubeMaterial.Enabled = true;
            //cmbCylinderHead.Enabled = false;
        }

        private void cmbTubeMaterial_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BaseEndReset();
            CommonResetControls();
            ObjBEL1.TubeMaterial = cmbTubeMaterial.SelectedItem.ToString();
            cmbBaseEndPiece.Enabled = true;
           // cmbTubeMaterial.Enabled = false;
          
        }

        private void cmbBaseEndPiece_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CommonResetControls();
            ObjBEL1.BaseEnd = cmbBaseEndPiece.SelectedItem.ToString();
            cmbRephasing.Enabled = true;
            LoadRephasing();
           // cmbBaseEndPiece.Enabled = false;
        }

        private void cmbRephasing_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        

            CommonResetControls();
            ObjBEL1.Rephasing = cmbRephasing.SelectedItem.ToString();
            txtFlowPath.Text = ObjBLL.ReadData(ObjBEL1.Design, ObjBEL1.CylinderHead, ObjBEL1.BaseEnd, ObjBEL1.TubeMaterial, ObjBEL1.Rephasing);

           // cmbRephasing.Enabled = false;
        }

        private void txtFlowPath_TextChanged_1(object sender, EventArgs e)
        {
            FlowpathchangeSetup();
            ObjBEL1.FlowPathNumber = int.Parse(txtFlowPath.Text);
           // int no = int.Parse(txtFlowPath.Text);
            switch (ObjBEL1.FlowPathNumber)
            {
                case 1:
                    cmbPortOrientation.Enabled = true;
                    cmbOrificeSize.Enabled = true;
                    
                    chkOP031_1.Enabled = true;
                    chkOP070_3.Enabled = true;
                    break;

                case 2:
                    cmbPortOrientation.Enabled = true;
                    cmbOrificeSize.Enabled = true;
                    cmbFabricationDrillingHole.Enabled = true;
                    
                    chkOP031_1.Enabled = true;
                    chkOP062_1.Enabled = true;
                    break;
                case 3:
                    cmbPortOrientation.Enabled = true;
                    chkOP031_1.Enabled = true;
                    chkOP070_3.Enabled = true;
                    break;
                case 4:
                    cmbPortOrientation.Enabled = true;
                    cmbFabricationDrillingHole.Enabled = true;

                     chkOP031_1.Enabled = true;
                    chkOP062_1.Enabled = true;
                    break;
                case 5:
                    cmbPortAngle.Enabled = true;
                    cmbOrificeSize.Enabled = true;

                    chkOP031_1.Enabled = true;
                    chkOP070_3.Enabled = true;
                    break;
                case 6:
                    cmbPortAngle.Enabled = true;
                    cmbOrificeSize.Enabled = true;
                    cmbFabricationDrillingHole.Enabled = true;

                     chkOP031_1.Enabled = true;
                    chkOP062_1.Enabled = true;
                    break;

                case 7:
                    chkOP031_1.Enabled = true;
                    chkOP070_3.Enabled = true;
                    break;

                   
                case 14:
                case 18:
                    cmbPortAngle.Enabled = true;
                    cmbFabricationDrillingHole.Enabled = true;
                    cmbRephasingAt.Enabled = true;


                    //chkOP042_1.Enabled = true;
                    //chkOP042_2.Enabled = true;
                    chkOP044_1.Enabled = true;
                    chkOP062_1.Enabled = true;
                    break;
                case 8:
                    cmbFabricationDrillingHole.Enabled = true;

                     chkOP031_1.Enabled = true;
                    chkOP062_1.Enabled = true;
                    break;
                case 9:
                case 15:
                case 11:
                    cmbWeldType.Enabled = true;
                    if (ObjBEL1.FlowPathNumber == 9)
                    {
                        chkOP054.Enabled = true;
                        chkOP070_3.Enabled = true;

                    }
                    else
                    {
                        chkOP070_3.Enabled = true;
                    }
                   
                    break;
                case 10:
                case 16:
                case 12:
                    cmbWeldType.Enabled = true;
                    cmbFabricationDrillingHole.Enabled = true;

                    if (ObjBEL1.FlowPathNumber == 10)
                    {
                        chkOP054.Enabled = true;
                        chkOP062_1.Enabled = true;

                    }
                    else
                    {
                        chkOP062_1.Enabled = true;

                    }
                    
                    break;
                case 13:
                case 17:
                    cmbPortAngle.Enabled = true;
                    cmbRephasingAt.Enabled = true;

                    //chkOP042_1.Enabled = true;
                    //chkOP042_2.Enabled = true;
                    chkOP044_1.Enabled = true;
                    chkOP070_3.Enabled = true;


                    
                    break;
                default:
                    cmbWeldType.Enabled = false;
                    cmbPortOrientation.Enabled = false;
                    cmbPortAngle.Enabled = false;
                    cmbOrificeSize.Enabled = false;
                    cmbFabricationDrillingHole.Enabled = false;
                    cmbRephasingAt.Enabled = false;
                    break;
            }
        }

        private void btnOpNo_Click_1(object sender, EventArgs e)
        {
            //string ValidationMsg = ObjBLL.GetOpButtonValidation(ObjBEL1);

            //if (ValidationMsg != null)
            //{
            //    MessageBox.Show(ValidationMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            //}
            //else 
            //{
            //    cmbOpNo.Items.Clear();
            //    LoadMultipleOP();
            //    cmbOpNo.SelectedIndex = 0;
            //    cmbOpNo.Enabled = true;
            //    txtWorkInstruction.Visible = true;
            //    lblWorkInstruction.Visible = true;
            //    txtProgram.Visible = true;
            //    lblProgram.Visible = true;
            //    txtTool.Visible = true;
            //    lblTool.Visible = true;
            //}
           
        }

        private void cmbOrificeSize_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (cmbOrificeSize.Items[e.Index].ToString().Length > 22)
            {
                e.ItemHeight = e.ItemHeight + 3;
            }
        }
        private void cmbOrificeSize_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(cmbOrificeSize.Items[e.Index].ToString(), cmbOrificeSize.Font, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }

        private void cmbFabrication_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (cmbFabricationDrillingHole.Items[e.Index].ToString().Length > 22)
            {
                e.ItemHeight = e.ItemHeight + 3;
            }
        }

        private void cmbFabrication_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(cmbFabricationDrillingHole.Items[e.Index].ToString(), cmbFabricationDrillingHole.Font, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }
        public void ResetControls()
        {
            cmbTubeMaterial.SelectedIndexChanged -= new EventHandler(cmbTubeMaterial_SelectedIndexChanged_1);
            cmbTubeMaterial.SelectedIndex = -1;
            cmbTubeMaterial.SelectedIndexChanged += new EventHandler(cmbTubeMaterial_SelectedIndexChanged_1);
            cmbBaseEndPiece.SelectedIndexChanged -= new EventHandler(cmbBaseEndPiece_SelectedIndexChanged_1);
            cmbBaseEndPiece.SelectedIndex = -1;
            cmbBaseEndPiece.SelectedIndexChanged += new EventHandler(cmbBaseEndPiece_SelectedIndexChanged_1);
            cmbRephasing.SelectedIndexChanged -= new EventHandler(cmbRephasing_SelectedIndexChanged_1);
            cmbRephasing.SelectedIndex = -1;
            cmbRephasing.SelectedIndexChanged += new EventHandler(cmbRephasing_SelectedIndexChanged_1);
            txtFlowPath.TextChanged -= new EventHandler(txtFlowPath_TextChanged_1);
            txtFlowPath.ResetText();
            txtFlowPath.TextChanged += new EventHandler(txtFlowPath_TextChanged_1);
            CommonResetControls();
            //ObjBEL = new BEL();
            this.Controls.ClearControls<GroupBox>();
            if (ObjUctrOP_30.txtboxCam.Text != string.Empty)
            {
                ObjUctrOP_30.txtboxCam.Text = "";
                ObjUctrOP_30.txtboxWorkInstuction.Text = "";
                ObjUctrOP_30.txtboxPortLocator.Text = "";
                ObjUctrOP_30.txtboxWpds.Text = "";
            }
            cmbOpNo.Enabled = false;
            cmbOpNo.SelectedIndexChanged -= new EventHandler(cmbOpNo_SelectedIndexChanged);
            cmbOpNo.SelectedIndex = -1;
            cmbOpNo.SelectedIndexChanged += new EventHandler(cmbOpNo_SelectedIndexChanged);
            cmbBoreDiameter.Enabled = false;
            cmbBoreDiameter.SelectedIndexChanged -= new EventHandler(cmbBoreDiameter_SelectedIndexChanged);
            cmbBoreDiameter.SelectedIndex = -1;
            cmbBoreDiameter.SelectedIndexChanged += new EventHandler(cmbBoreDiameter_SelectedIndexChanged);
            cmbTubeLength.Enabled = false;
            cmbTubeLength.SelectedIndexChanged -= new EventHandler(cmbTubeLength_SelectedIndexChanged);
            cmbTubeLength.SelectedIndex = -1;
            cmbTubeLength.SelectedIndexChanged += new EventHandler(cmbTubeLength_SelectedIndexChanged);
            cmbPortType.Enabled = false;
            cmbPortType.SelectedIndexChanged -= new EventHandler(cmbPortType_SelectedIndexChanged);
            cmbPortType.SelectedIndex = -1;
            cmbPortType.SelectedIndexChanged += new EventHandler(cmbPortType_SelectedIndexChanged);
        }

        private void linkReferenceNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // this.Enabled = false;
            ReferenceNotes ObjReferenceNotes = new ReferenceNotes();
            ObjReferenceNotes.Show();
            ObjReferenceNotes.FormClosed += new FormClosedEventHandler(ObjReferenceNotes_FormClosed);
        }
        private void ObjReferenceNotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
        }
        public void BaseEndReset()
        {
            cmbBaseEndPiece.SelectedIndexChanged -= new EventHandler(cmbBaseEndPiece_SelectedIndexChanged_1);
            cmbBaseEndPiece.SelectedIndex = -1;
            cmbBaseEndPiece.SelectedIndexChanged += new EventHandler(cmbBaseEndPiece_SelectedIndexChanged_1);
        }
        public void AddingNewRowToTlp(int NewRowIndex,int NewColumnIndex,Control ControlToAdd)
        {
            ObjUctrOP_30.tableLayoutPanel1.RowStyles.Insert(NewRowIndex, new RowStyle(SizeType.AutoSize));
            ObjUctrOP_30.tableLayoutPanel1.RowCount++;
            foreach (Control ExistControl in ObjUctrOP_30.tableLayoutPanel1.Controls)
            {
                if (ObjUctrOP_30.tableLayoutPanel1.GetRow(ExistControl) >= NewRowIndex)
                {
                    ObjUctrOP_30.tableLayoutPanel1.SetRow(ExistControl,
                                            ObjUctrOP_30.tableLayoutPanel1.GetRow(ExistControl) + 1);
                }
            }
            ObjUctrOP_30.tableLayoutPanel1.Controls.Add(ControlToAdd, NewColumnIndex, NewRowIndex);
        }
        public void FlowpathchangeSetup()
        {
            cmbWeldType.Enabled = false;
            cmbPortOrientation.Enabled = false;
            cmbPortAngle.Enabled = false;
            cmbOrificeSize.Enabled = false;
            cmbFabricationDrillingHole.Enabled = false;
            cmbRephasingAt.Enabled = false;

            chkOP031_1.Enabled = false;
            //chkOP042_1.Enabled = false;
            //chkOP042_2.Enabled = false;
            chkOP044_1.Enabled = false;
            chkOP054.Enabled = false;
            chkOP062_1.Enabled = false;
            chkOP070_3.Enabled = false;
        }

        public void FindEmptyControls(TableLayoutPanel tablelayoutcontrol)
        {
             Color windowcolor = Color.FromArgb(255, 255, 255);
             foreach (Control item in tablelayoutcontrol.Controls)
             {
                 if (item is ComboBox)
                 {
                     if (item.Text == "" && item.Enabled == true)
                     {
                         item.BackColor = Color.LightSalmon;

                     }
                     else
                     {
                         item.BackColor = windowcolor;
                     }
                 }
             }


        }

        public void changeTextBoxBackGround(GroupBox objGroupBox)
        {
            foreach (Control item in objGroupBox.Controls)
            {
                if (item is TextBox)
                {
                    item.BackColor = Color.White;
                }
            }
        }

        private void cmbWeldType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL1.WeldType = cmbWeldType.SelectedItem.ToString();
        }

        private void cmbPortOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL1.PortOrientation = cmbPortOrientation.SelectedItem.ToString();
        }

        private void cmbPortAngle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL1.PortAngle = cmbPortAngle.SelectedItem.ToString();
        }

        private void cmbOrificeSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL1.OrificeSize = cmbOrificeSize.SelectedItem.ToString();
        }

        private void cmbFabricationDrillingHole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL1.FabricationDrillingHole = cmbFabricationDrillingHole.SelectedItem.ToString();
        }
        public void CommonResetControls()
        {
            cmbWeldType.Enabled = false;
            cmbWeldType.SelectedIndexChanged -= new EventHandler(cmbWeldType_SelectedIndexChanged);
            cmbWeldType.SelectedIndex = -1;
            cmbWeldType.SelectedIndexChanged += new EventHandler(cmbWeldType_SelectedIndexChanged);
            cmbPortOrientation.Enabled = false;
            cmbPortOrientation.SelectedIndexChanged -= new EventHandler(cmbPortOrientation_SelectedIndexChanged);
            cmbPortOrientation.SelectedIndex = -1;
            cmbPortOrientation.SelectedIndexChanged += new EventHandler(cmbPortOrientation_SelectedIndexChanged);
            cmbPortAngle.Enabled = false;
            cmbPortAngle.SelectedIndexChanged -= new EventHandler(cmbPortAngle_SelectedIndexChanged);
            cmbPortAngle.SelectedIndex = -1;
            cmbPortAngle.SelectedIndexChanged += new EventHandler(cmbPortAngle_SelectedIndexChanged);
            cmbOrificeSize.Enabled = false;
            cmbOrificeSize.SelectedIndexChanged -= new EventHandler(cmbOrificeSize_SelectedIndexChanged);
            cmbOrificeSize.SelectedIndex = -1;
            cmbOrificeSize.SelectedIndexChanged += new EventHandler(cmbOrificeSize_SelectedIndexChanged);
            cmbFabricationDrillingHole.Enabled = false;
            cmbFabricationDrillingHole.SelectedIndexChanged -= new EventHandler(cmbFabricationDrillingHole_SelectedIndexChanged);
            cmbFabricationDrillingHole.SelectedIndex = -1;
            cmbFabricationDrillingHole.SelectedIndexChanged += new EventHandler(cmbFabricationDrillingHole_SelectedIndexChanged);
            cmbRephasingAt.SelectedIndexChanged -= new EventHandler(cmbRephasingAt_SelectedIndexChanged);
            cmbRephasingAt.SelectedIndex= -1;
            cmbRephasingAt.SelectedIndexChanged += new EventHandler(cmbRephasingAt_SelectedIndexChanged);
        }

        private void cmbRephasingAt_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBEL1.RephasingAt = cmbRephasingAt.SelectedItem.ToString();
        }
        private void btnOpNo_Click(object sender, EventArgs e)
        {
            string ValidationMsg = ObjBLL.GetOpButtonValidation(ObjBEL1);

            if (ValidationMsg != null)
            {
               FindEmptyControls(tableLayoutPanel1);
                MessageBox.Show(ValidationMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            else
            {
                cmbOpNo.Items.Clear();
                LoadMultipleOP();
                cmbOpNo.SelectedIndex = 0;
                cmbOpNo.Enabled = true;
                txtWorkInstruction.Visible = true;
                lblWorkInstruction.Visible = true;
                txtProgram.Visible = true;
                lblProgram.Visible = true;
                txtTool.Visible = true;
                lblTool.Visible = true;
            }
        }
        private void ClrearingAllUsercontrolsdata()
        {
            foreach (Control c in this.ObjUctrOP_59.groupBox1.Controls)
            {
                foreach (Control t in c.Controls)
                {
                    if (t.GetType() == typeof(TextBox))
                    {
                        t.Text = "";
                    }
                }
            }
            ObjUctrOP_59.txtTool.Text = "Caution Weight";
            foreach (Control c in this.objUctrDoubleWorkInstruction.groupBox1.Controls)
            {
                foreach (Control t in c.Controls)
                {
                    if (t.GetType() == typeof(TextBox))
                    {
                        t.Text = "";
                    }
                }
            }
            objUctrDoubleWorkInstruction.txtTool.Text="Caution Weight";
            foreach (Control c in this.objUctrOP33_155_1.Tooling.Controls)
            {
                foreach (Control t in c.Controls)
                {
                    if (t.GetType() == typeof(TextBox))
                    {
                        t.Text = "";
                    }
                }
            }
        }

        private void CMSTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            string path = Application.StartupPath;
            string[] txtList = Directory.GetFiles(path, "*.txt");
            foreach (string f in txtList)
            {
                System.IO.File.Delete(f);
            }
        }

        private void btnScreenCapture_Click(object sender, EventArgs e)
        {
           fso=new FileSystemObject();
            oclsImageCapture.CaptureScreen();
            PictureBox pic;
            try
            {
                pic = new PictureBox();
                pic.Image = oclsImageCapture.Background;
                pic.Name = DateTime.Now.ToString();
                string OpNo=cmbOpNo.SelectedItem.ToString();
                if (fso.FolderExists("F:\\TubePrintScreen\\")!=true)
                {
                    fso.CreateFolder("F:\\TubePrintScreen\\");
                }
                if(System.IO.File.Exists("F:\\TubePrintScreen\\"+OpNo+".jpg"));
                {
                    System.IO.File.Delete("F:\\TubePrintScreen\\" + OpNo + ".jpg");
                }
                pic.Image.Save("F:\\TubePrintScreen\\" + OpNo + ".jpg", ImageFormat.Jpeg);
                string msg = @"Screen Shot Saved in Drive F:\TubePrintScreen\" + OpNo + ".jpg";
                MessageBox.Show(msg,"Location");
                
               
            }
            catch (Exception)
            {
                
                throw;
            }

        }
       

   
    }
}



