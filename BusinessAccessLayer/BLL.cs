using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer;
using CMSTooling;

namespace BusinessAccessLayer
{
    public class BLL
    {
        double BoreDiameter;
        int TubeLength;

        DAL ObjDAL = new DAL();
       // BEL ObjBEL = new BEL();
   
        public string MainFormvalidations(BEL ObjBEL)
        {
            string ValidationMsg = null;
            if (ObjBEL.OpNo == null)
            {
                ValidationMsg += " Please Select OP_Number";
            }
            if ((ObjBEL.OpNo == "OP_070_1") || (ObjBEL.OpNo =="OP_070_3"))
            {
                if (ObjBEL.PartWeight == null)
                {
                    ValidationMsg += "\n Please Select PartWeigths";
                }
                if (ObjBEL.PinHoleSize ==0.0)
                {
                    ValidationMsg += "\n Please Enter PinHoleSize";
                }
                if (ObjBEL.TubeEndconfiguration == null)
                {
                    ValidationMsg += "\n Please Select TubeEndConfiguration";
                }
                if (ObjBEL.HoleDepth == 0.0)
                {
                    ValidationMsg += "\n Please Enter HoleDepth";
                }
            }
            else
            {
                if (ObjBEL.BoreDiameter == null)
                {
                    ValidationMsg += "\n Please Select Borediameter";
                }
                if (ObjBEL.TubeLength == null)
                {
                    ValidationMsg += "\n Please Select TubeLength";
                }
              
            }
            if (ObjBEL.OpNo == "OP_062_1")
            {
                if (ObjBEL.WeldSize == null)
                {
                    ValidationMsg += "\n Please Enter WeldSize";
                }
            }
            if (ObjBEL.OpNo == "OP_061_1")
            {
                if (ObjBEL.TubeEndconfiguration == null)
                {
                    ValidationMsg += "\n Please Select TubeEndconfiguration";
                }
                if (ObjBEL.WallThickness == null)
                {
                    ValidationMsg += "\n Please Select Wallthickness";
                }
            }
            if ((ObjBEL.OpNo == "OP_059_1") || (ObjBEL.OpNo =="OP_060_1"))
            {
                if (ObjBEL.WallThickness == null)
                {
                    ValidationMsg += "\n Please Select Wallthickness";
                }
            }
            if ((ObjBEL.OpNo == "OP_030_1")||(ObjBEL.OpNo =="OP_031_1")||(ObjBEL.OpNo=="OP_043_1") || (ObjBEL.OpNo=="OP_044_1"))
            {
                if ((ObjBEL.OpNo == "OP_030_1")||(ObjBEL.OpNo=="OP_043_1")||(ObjBEL.OpNo=="OP_044_1"))
                {
                    if (ObjBEL.PortType == null)
                    {
                        ValidationMsg += "\n Please Select PortType";
                    }
                }
                else 
                {
                }
                 if (ObjBEL.MainCAM == string.Empty)
                {
                        ValidationMsg += "\n Please Enter CAM";
                }
                if (ObjBEL.MainPortLocator == string.Empty)
                {
                 ValidationMsg += "\n Please Enter PortLocator";
                }
                if (ObjBEL.MainWPDS == string.Empty)
                {
                  ValidationMsg += "\n Please Enter WPDS";
                 }
            }
            else 
            {
            }
          
            return ValidationMsg;
        }
        public string GetOpButtonValidation(BEL ObjBEL)
        {
            string VlidationMsg = null;
            if (ObjBEL.Design == null)
            {
                VlidationMsg += " Please Select Design";
            }
            if (ObjBEL.CylinderHead == null)
            {
                VlidationMsg +="\n Please Select CylinderHead";
            }
            if (ObjBEL.TubeMaterial == null)
            {
                VlidationMsg += "\n Please Select TubeMaterial";
            }
            if (ObjBEL.BaseEnd == null)
            {
                VlidationMsg += "\n Please Select BaseEnd";
            }
            if (ObjBEL.Rephasing == null)
            {
                VlidationMsg += "\n Please Select Rephasing";
            }
            switch (ObjBEL.FlowPathNumber)
            {
                case 1:
                    if(ObjBEL.PortOrientation ==null)
                    {
                    VlidationMsg +="\n PLease Enter PortOrientation";
                    }
                    if (ObjBEL.OrificeSize ==null)
                    {
                    VlidationMsg +="\n PLease Enter OrificeSize";
                    }
                    break;

                case 2:
                    if(ObjBEL.PortOrientation ==null)
                    {
                         VlidationMsg +="\n PLease Enter PortOrientation";
                    }
                    if(ObjBEL.OrificeSize ==null)
                    {
                     VlidationMsg +="\n PLease Enter OrificeSize";
                    }
                    if (ObjBEL.FabricationDrillingHole==null)
                    {
                     VlidationMsg +="\n PLease Enter FabricationDrillingHole";
                    }
                    break;
                case 3:
                    if(ObjBEL.PortOrientation==null)
                    {
                     VlidationMsg +="\n PLease Enter PortOrientation";
                    }
                    break;
                case 4:
                    if(ObjBEL.PortOrientation ==null)
                    {
                        VlidationMsg +="\n PLease Enter PortOrientation";
                    }
                    if(ObjBEL.FabricationDrillingHole ==null)
                    {
                       VlidationMsg +="\n PLease Enter FabricationDrillingHole";
                    }
                    break;
                case 5:
                    if(ObjBEL.PortAngle ==null)
                    {
                       VlidationMsg +="\n PLease Enter PortAngle";
                    }
                    if(ObjBEL.OrificeSize ==null)
                    {
                      VlidationMsg +="\n PLease Enter OrificeSize";
                    }
                    break;
                case 6:
                     if(ObjBEL.PortAngle==null)
                    {
                      VlidationMsg +="\n PLease Enter PortAngle";
                    }
                     if (ObjBEL.OrificeSize == null)
                     {
                         VlidationMsg += "\n PLease Enter OrificeSize";
                     }
                    if(ObjBEL.FabricationDrillingHole ==null)
                    {
                         VlidationMsg +="\n PLease Enter FabricationDrillingHole";
                    }
                    break;
                case 14:
                case 18:
                    if(ObjBEL.PortAngle==null)
                    {
                      VlidationMsg +="\n PLease Enter PortAngle";
                    }
                    if(ObjBEL.FabricationDrillingHole ==null)
                    {
                         VlidationMsg +="\n PLease Enter FabricationDrillingHole";
                    }
                    if (ObjBEL.RephasingAt == null)
                    {
                        VlidationMsg +="\n Please Enter Rephasing At";
                    }
                    break;
                case 8:

                    if(ObjBEL.FabricationDrillingHole ==null)
                    {
                         VlidationMsg +="\n PLease Enter FabricationDrillingHole";
                    }
                    break;
                case 9:
                case 15:
                case 11:
                    if(ObjBEL.WeldType ==null)
                    {
                       VlidationMsg +="\n PLease Enter WeldType";
                    }
                    break;
                case 10:
                case 16:
                case 12:
                    if(ObjBEL.WeldType ==null)
                    {
                       VlidationMsg +="\n PLease Enter WeldType";
                    }
                   
                    if(ObjBEL.FabricationDrillingHole ==null)
                    {
                         VlidationMsg +="\n PLease Enter FabricationDrillingHole";
                    }
                    break;
                case 13:
                case 17:

                    if(ObjBEL.PortAngle ==null)
                    {
                       VlidationMsg +="\n PLease Enter PortAngle";
                    }
                    if (ObjBEL.RephasingAt == null)
                    {
                        VlidationMsg += "\n Please Enter Rephasing At";
                    }
                    break;
                default:
                    break;
            }
            return VlidationMsg;
        }
        public string PortLocatorFormValidation(BEL ObjBEL)
        {
            string ValidationMsg = null;
            if (ObjBEL.PortSize == null)
            {
                ValidationMsg += " Please Select PortSize";
            }
            if (ObjBEL.OrificeSize == null)
            {
                ValidationMsg += "\nPlease Select OrificSize";
            }
            if (ObjBEL.OffSet == null)
            {
                ValidationMsg += "\nPlease Select OffSet";
            }
            else
            {
            }
            return ValidationMsg;
        }
        public string WPDSFormValidation(BEL ObjBEL)
        {
            string validationMsg = null;
            if (ObjBEL.PortTypeWpds == null)
            {
                validationMsg += " Please Select PotyType";
            }
            if (ObjBEL.Orientation == null)
            {
                validationMsg += "\nPlease Select Orientation";
            }
            if (ObjBEL.Style == null)
            {
                validationMsg += "\nPlease Select Style";
            }
            if (ObjBEL.ThreadSize == null)
            {
                validationMsg += "\nPlease Select ThreadSize";
            }
            if (ObjBEL.TubeODMin == null)
            {
                validationMsg += "\nPlease Select TubeODMin";
            }
            if (ObjBEL.TubeType == null)
            {
                validationMsg += "\nPlease Select TubeType";
            }
            else
            {
            }
            return validationMsg;
        }
        public DataTable GetWPDSForOP_59(string BoreDia, string WallThickness)
        {
            double vWallThicjness=Convert.ToDouble(WallThickness);
            string WPDS = string.Empty;
            string Collect = string.Empty;
            DataTable ObjDataTable = new DataTable();
            DataColumn ObjColumn;
            DataRow ObjRow;
            ObjColumn = new DataColumn();
            ObjColumn.ColumnName = "WPDS";
            ObjDataTable.Columns.Add(ObjColumn);
            ObjColumn = new DataColumn();
            ObjColumn.ColumnName = "Collect";
            ObjDataTable.Columns.Add(ObjColumn);
            switch (BoreDia)
            {
                case "1.00":

                    Collect = "No Data";

                    if ((vWallThicjness >= 0.120) && (vWallThicjness <= 0.125))
                    {
                        WPDS = "298140";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "1.25":

                    Collect = "502046";

                    if ((vWallThicjness >= 0.120) && (vWallThicjness <= 0.125))
                    {
                        WPDS = "299764";
                    }
                    else if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299780";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "1.50":

                    Collect = "501960";

                    if((vWallThicjness >=0.120)&&(vWallThicjness <=0.125))
                    {
                        WPDS ="298149";
                    }
                    else if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299763";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "1.75":

                    Collect = "501961";

                    if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299500";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "2.00":

                    Collect = "501962";

                    if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299619";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "2.25":

                    Collect = "501963";

                     if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299620";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "2.50":

                    Collect = "501964";

                     if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299621";
                    }
                     else if((vWallThicjness >=0.235)&&(vWallThicjness <=0.250))
                     {
                         WPDS="299765";
                     }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "2.75":

                    Collect = "501965";

                     if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "298162";
                    }
                         else if((vWallThicjness >=0.235)&&(vWallThicjness <=0.250))
                     {
                         WPDS="299622";
                     }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "3.00":

                    Collect = "501966";

                     if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299614";
                    }
                         else if((vWallThicjness >=0.235)&&(vWallThicjness <=0.250))
                     {
                         WPDS="299771";
                     }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "3.25":

                    Collect = "501967";

                     if((vWallThicjness >=0.235)&&(vWallThicjness <=0.250))
                     {
                         WPDS="299624";
                     }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "3.50":

                    Collect = "501968";

                    if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "298128";
                    }
                         else if((vWallThicjness >=0.235)&&(vWallThicjness <=0.250))
                     {
                         WPDS="299625";
                     }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "3.75":

                    Collect = "501969";

                     if((vWallThicjness >=0.235)&&(vWallThicjness <=0.250))
                     {
                         WPDS="298193";
                     }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "4.00":

                    Collect = "501970";

                     if((vWallThicjness >=0.235)&&(vWallThicjness <=0.250))
                     {
                         WPDS="299626";
                     }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "4.25":

                    Collect = "501971";

                     if((vWallThicjness ==0.375))
                     {
                         WPDS="298007";
                     }
                    else
                    {
                        WPDS = "299801";
                     }
                    break;
                case "4.50":

                    Collect = "501972";

                    if((vWallThicjness >=0.235) && (vWallThicjness <=0.250))
                    {
                        WPDS="299627";
                    }
                    else if((vWallThicjness >=0.310) && (vWallThicjness <=0.313)) 
                    {
                        WPDS="298150";
                    }
                    else 
                    {
                         WPDS = "299801";
                    }
                    break;
                case "4.75":
                    Collect = "No Data";
                    WPDS ="299801";
                    break;
                case "5.00":

                    Collect = "501974";

                     if((vWallThicjness >=0.235) && (vWallThicjness <=0.250))
                    {
                        WPDS="298171";
                    }
                    else if((vWallThicjness >=0.310) && (vWallThicjness <=0.313)) 
                    {
                        WPDS="298141";
                    }
                    else 
                    {
                         WPDS = "299801";
                    }
                    break;
                case "5.50":

                    Collect = "No Data";

                    if(vWallThicjness ==0.375)
                    {
                        WPDS ="298146";
                    }
                    else 
                    {
                        WPDS ="299801";
                    }
                    break;
                case "6.00":

                    Collect = "No Data";

                     if(vWallThicjness ==0.375)
                    {
                        WPDS ="299628";
                    }
                    else 
                    {
                        WPDS ="299801";
                    }
                    break;
            }

            ObjRow = ObjDataTable.NewRow();
            ObjRow["WPDS"]=WPDS;
            ObjRow["Collect"] = Collect;
            ObjDataTable.Rows.Add(ObjRow);
            return ObjDataTable;
            
        }
        public string GetWPDSForOP_60(string BoreDia, string WallThickness)
        {
            double vWallThicjness = Convert.ToDouble(WallThickness);
            string WPDS = string.Empty;
            switch (BoreDia)
            {
                case "1.00":

                    if ((vWallThicjness >= 0.120) && (vWallThicjness <= 0.125))
                    {
                        WPDS = "298140";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "1.25":

                    if ((vWallThicjness >= 0.120) && (vWallThicjness <= 0.125))
                    {
                        WPDS = "299764";
                    }
                    else if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299780";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "1.50":

                    if ((vWallThicjness >= 0.120) && (vWallThicjness <= 0.125))
                    {
                        WPDS = "298149";
                    }
                    else if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299763";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "1.75":
                    if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299500";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "2.00":
                    if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299619";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "2.25":                   
                   if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299620";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "2.50":
                    if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299621";
                    }
                    else if ((vWallThicjness >= 0.235) && (vWallThicjness <= 0.250))
                    {
                        WPDS = "299765";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "2.75":
                    if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "298162";
                    }
                    else if ((vWallThicjness >= 0.235) && (vWallThicjness <= 0.250))
                    {
                        WPDS = "299622";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "3.00":
                    if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "299614";
                    }
                    else if ((vWallThicjness >= 0.235) && (vWallThicjness <= 0.250))
                    {
                        WPDS = "299771";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "3.25":
                    if ((vWallThicjness >= 0.235) && (vWallThicjness <= 0.250))
                    {
                        WPDS = "299624";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "3.50":
                    if ((vWallThicjness >= 0.170) && (vWallThicjness <= 0.188))
                    {
                        WPDS = "298128";
                    }
                    else if ((vWallThicjness >= 0.235) && (vWallThicjness <= 0.250))
                    {
                        WPDS = "299625";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "3.75":
                    if ((vWallThicjness >= 0.235) && (vWallThicjness <= 0.250))
                    {
                        WPDS = "298193";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "4.00":
                    if ((vWallThicjness >= 0.235) && (vWallThicjness <= 0.250))
                    {
                        WPDS = "299626";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "4.25":
                    if ((vWallThicjness == 0.375))
                    {
                        WPDS = "298007";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "4.50":                   
                    if ((vWallThicjness >= 0.235) && (vWallThicjness <= 0.250))
                    {
                        WPDS = "299627";
                    }
                    else if ((vWallThicjness >= 0.310) && (vWallThicjness <= 0.313))
                    {
                        WPDS = "298150";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "4.75":
                    WPDS = "299801";
                    break;
                case "5.00":
                    if ((vWallThicjness >= 0.235) && (vWallThicjness <= 0.250))
                    {
                        WPDS = "298171";
                    }
                    else if ((vWallThicjness >= 0.310) && (vWallThicjness <= 0.313))
                    {
                        WPDS = "298141";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "5.50":
                    if (vWallThicjness == 0.375)
                    {
                        WPDS = "298146";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
                case "6.00":
                    if (vWallThicjness == 0.375)
                    {
                        WPDS = "299628";
                    }
                    else
                    {
                        WPDS = "299801";
                    }
                    break;
            }

            return WPDS;

        }
        public string GetFixtureForOP_60(string BoreDia)
        {
            string Fixture=string.Empty;
            double vBoreDia=Convert.ToDouble(BoreDia);
            if (vBoreDia < 2.50)
            {
                Fixture ="502077";
            }
            else if (vBoreDia >= 2.50 && vBoreDia <= 3.50)
            {
                Fixture = "502078";
            }
            else if (vBoreDia > 3.50)
            {
                Fixture = "502079";
            }
            return Fixture;
        }
        public string GetFixtureForOP_61(string TubeConfiguration)
        {
            string Fixture = string.Empty;
            if (TubeConfiguration == "Cross Tube")
            {
                Fixture = "500991";
            }
            else 
            {
                Fixture = "500990";
            }
            return Fixture;
        }
        public object GetStandardRunTimeForAll(BEL ObjBEL)
        {
            return ObjDAL.GetStandardRunTimeForAll(ObjBEL);
        }
        public string GetStandardRunTime(BEL ObjBEL)
        {
            BoreDiameter = Convert.ToDouble(ObjBEL.BoreDiameter.Split('(')[0]);
            TubeLength = Convert.ToInt32(ObjBEL.TubeLength);
            double MUlboreLength = BoreDiameter * TubeLength;
            double GetStandardRunTime = 0;
            string WeldSize = string.Empty;
            if (ObjBEL.OpNo == "OP_061_1")
            {
                if (BoreDiameter <= 2) 
                {
                    if (ObjBEL.TubeEndconfiguration == "Cross Tube" || ObjBEL.TubeEndconfiguration == "Single Lug" || ObjBEL.TubeEndconfiguration == "U-Lug")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 18;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 16.5;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 15.5;
                        }
                    }
                    else if (ObjBEL.TubeEndconfiguration == "Double Lug")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 21;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 20;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 90;
                        }
                    }
                }
                else if ((BoreDiameter >= 2.25) && (BoreDiameter <= 3.00)) 
                {
                    if (ObjBEL.TubeEndconfiguration == "Cross Tube" || ObjBEL.TubeEndconfiguration == "Single Lug" || ObjBEL.TubeEndconfiguration == "U-Lug")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 16.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 15.5;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 14.5;
                        }
                    }
                    else if (ObjBEL.TubeEndconfiguration == "Double Lug")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 19;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 18;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 17;
                        }
                    }
                }
                else if((BoreDiameter >=3.25)&&(BoreDiameter <=4.00))
                {
                    if (ObjBEL.TubeEndconfiguration == "Cross Tube" || ObjBEL.TubeEndconfiguration == "Single Lug" || ObjBEL.TubeEndconfiguration == "U-Lug")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 15.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 14.5;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 13.5;
                        }
                    }
                    else if (ObjBEL.TubeEndconfiguration == "Double Lug")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 17;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 16;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 15;
                        }
                    }
                }
                else if ((BoreDiameter >= 4.25) && (BoreDiameter <= 5.00))
                {
                    if (ObjBEL.TubeEndconfiguration == "Cross Tube" || ObjBEL.TubeEndconfiguration == "Single Lug" || ObjBEL.TubeEndconfiguration == "U-Lug")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 14.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 13.5;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 12.5;
                        }
                    }
                    else if (ObjBEL.TubeEndconfiguration == "Double Lug")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 15;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 14;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 13;
                        }
                    }
                }
                else if ((BoreDiameter >= 5.50) && (BoreDiameter <= 6.00))
                {
                    if (ObjBEL.TubeEndconfiguration == "Cross Tube" || ObjBEL.TubeEndconfiguration == "Single Lug" || ObjBEL.TubeEndconfiguration == "U-Lug")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 13.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 12.5;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 11.5;
                        }
                    }
                    else if (ObjBEL.TubeEndconfiguration == "Double Lug")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 13;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 12;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 11;
                        }
                    }
                }
            }
            else if(ObjBEL.OpNo =="OP_062_1")
            {
                if (BoreDiameter <= 2)
                {
                    if (ObjBEL.WeldSize == "1/4\" Weld" || ObjBEL.WeldSize == "Less Than 1/4\" Weld")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 20;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 18;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 16.5;
                        }
                    }
                    else if (ObjBEL.WeldSize=="Greater 1/4\" Weld")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 14.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 14;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 13.5;
                        }
                    }
                }
                else if ((BoreDiameter >= 2.25) && (BoreDiameter <= 3.00))
                {
                    if (ObjBEL.WeldSize == "1/4\" Weld" || ObjBEL.WeldSize == "Less Than 1/4\" Weld")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 18;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 16.5;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 15.5;
                        }
                    }
                    else if (ObjBEL.WeldSize == "Greater 1/4\" Weld")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 13.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 13;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 12.5;
                        }
                    }
                }
                else if ((BoreDiameter >= 3.25) && (BoreDiameter <= 4.00))
                {
                    if (ObjBEL.WeldSize == "1/4\" Weld" || ObjBEL.WeldSize == "Less Than 1/4\" Weld")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 15.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 14.5;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 13.5;
                        }
                    }
                    else if (ObjBEL.WeldSize == "Greater 1/4\" Weld")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 12.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 12;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 11.5;
                        }
                    }
                }
                else if ((BoreDiameter >= 4.25) && (BoreDiameter <= 5.00))
                {
                    if (ObjBEL.WeldSize == "1/4\" Weld" || ObjBEL.WeldSize == "Less Than 1/4\" Weld")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 13.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 12.5;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 11.5;
                        }
                    }
                    else if (ObjBEL.WeldSize == "Greater 1/4\" Weld")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 11.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 11;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 10.5;
                        }
                    }
                }
                else if ((BoreDiameter >= 5.50) && (BoreDiameter <= 6.00))
                {
                    if (ObjBEL.WeldSize == "1/4\" Weld" || ObjBEL.WeldSize == "Less Than 1/4\" Weld")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 11.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 10.5;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 9.5;
                        }
                    }
                    else if (ObjBEL.WeldSize == "Greater 1/4\" Weld")
                    {
                        if (MUlboreLength <= 50)
                        {
                            GetStandardRunTime = 10.5;
                        }
                        else if (MUlboreLength > 50 && MUlboreLength <= 100)
                        {
                            GetStandardRunTime = 10;
                        }
                        else if (MUlboreLength > 100)
                        {
                            GetStandardRunTime = 9.5;
                        }
                    }
                }
            }
            else
            {
                switch (ObjBEL.OpNo)
                {
                    case "OP_030_1":
                    case "OP_043_1":
                    case "OP_044_1":

                        if (MUlboreLength <= 60)
                        {
                            if (ObjBEL.PortType == "One Port")
                            {
                                GetStandardRunTime = 68;
                            }
                            else if (ObjBEL.PortType == "Two Port")
                            {
                                GetStandardRunTime = 40;
                            }
                        }
                        else if ((MUlboreLength > 60) && (MUlboreLength < 120))
                        {
                            if (ObjBEL.PortType == "One Port")
                            {
                                GetStandardRunTime = 54;
                            }
                            else if (ObjBEL.PortType == "Two Port")
                            {
                                GetStandardRunTime = 34;
                            }
                        }
                        else if (MUlboreLength >= 120)
                        {
                            if (ObjBEL.PortType == "One Port")
                            {
                                GetStandardRunTime = 44;
                            }
                            else if (ObjBEL.PortType == "Two Port")
                            {
                                GetStandardRunTime = 30;
                            }
                        }

                        break;
                    case "OP_031_1":
                        if (MUlboreLength <= 60)
                        {
                            GetStandardRunTime = 68;

                        }
                        else if ((MUlboreLength > 60) && (MUlboreLength < 120))
                        {

                            GetStandardRunTime = 54;

                        }
                        else if (MUlboreLength >= 120)
                        {

                            GetStandardRunTime = 44;
                        }
                        break;
                    default:
                        break;
                }

            }
            return GetStandardRunTime.ToString();
        }
        public string GetStandardRunTimeForOP_70(string PartWeigth, double PinHoleSize, double HoleDepth)
        {
            string StandardRunTime = string.Empty;
            double DrillingTime;
            double Time=0;
            double LoadUnload=0;
            double Secs=0;
            if (PinHoleSize >= 0 && PinHoleSize <= 0.75)
            {
                Secs = 10;
            }
            else if (PinHoleSize >= 0.76 && PinHoleSize <= 1.25)
            {
                Secs = 17;
            }
            else if (PinHoleSize >= 1.26 && PinHoleSize <= 1.75)
            {
                Secs = 24;
            }
            switch (PartWeigth)
            {
                case "0-10lbs":
                    LoadUnload = 0.334;
                   
                    break;
                case "11-15lbs":
                    LoadUnload = 0.44;
                    break;
                case "16-20lbs":
                    LoadUnload = 0.5;
                    break;
                case "21-40lbs":
                    LoadUnload = 0.8;
                    break;
            }
            DrillingTime = Math.Round((Secs) * ((HoleDepth) / 60),2);
            if (DrillingTime > 0.3)
            {
                Time = 0;
            }
            else
            {
                Time = 0.25;
            }
            StandardRunTime = Math.Round(60 / (LoadUnload + DrillingTime + Time)).ToString();
            return StandardRunTime;
        }
        public DataTable GetWorkcenterDetails(string OP_NO)
        {
            return ObjDAL.SetWorkCenter(OP_NO);
        }
        public DataTable GetOp_sheet(string TableName)
        {
            return ObjDAL.GetOpSheet(TableName);
        }
        public double GetBestCam(double Difference)
        {
            DataTable objDataTable = new DataTable();
            objDataTable = ObjDAL.GetRiseAndFall();
            List<string> Objlist = new List<string>();
            foreach (DataRow data in objDataTable.Rows)
            {
                Objlist.Add(data.ItemArray[0].ToString());
            }
            List<double> ObjListOfRiseAndFall = new List<double>();
            ObjListOfRiseAndFall = Objlist.ConvertAll(item => double.Parse(item));
            Dictionary<double, double> ObjListDifferences = new Dictionary<double, double>();
            for (int i = 0; i < ObjListOfRiseAndFall.Count; i++)
            {
                ObjListDifferences.Add(ObjListOfRiseAndFall[i], Math.Round(Math.Abs(ObjListOfRiseAndFall[i] - Difference), 4));
            }
            double value = ObjListDifferences.Values.Min();
            double keys = (from entry in ObjListDifferences
                           where entry.Value == value
                           select entry.Key).Single();
            double bestCam = ObjDAL.GetBestCam(keys);
            return bestCam;
        }
        public DataTable PortlocatorLoad(string ColumName)
        {
            return ObjDAL.PortLocatorLoad(ColumName);
        }
        public DataTable PortlocatorLoad(string ColumName, string PortSize)
        {
            return ObjDAL.PortLocatorLoad(ColumName, PortSize);
        }
        public DataTable PortlocatorLoad(string ColumName, string PortSize, string OrificeSize)
        {
            return ObjDAL.PortLocatorLoad(ColumName, PortSize, OrificeSize);
        }
        public string GetPortLocator(string Portsize, string OrificeSize, string OffSet)
        {
            string PortLocator = string.Empty;

            PortLocator = ObjDAL.GetPortLocator(Portsize, OrificeSize, OffSet);
            return PortLocator;

        }
        public DataTable WPDSFormLoad(string ColumnName)
        {
            return ObjDAL.GetWPDSFormLoad(ColumnName);
        }
        public DataTable WPDSFormLoad(string ColumnName, string PortType)
        {
            return ObjDAL.GetWPDSFormLoad(ColumnName, PortType);
        }
        public DataTable WPDSFormLoad(string ColumnName, string PortType, string Orientation)
        {
            return ObjDAL.GetWPDSFormLoad(ColumnName, PortType, Orientation);
        }
        public DataTable WPDSFormLoad(string ColumnName, string PortType, string Orientation, string Style)
        {
            return ObjDAL.GetWPDSFormLoad(ColumnName,PortType,Orientation,Style);
        }
        public DataTable WPDSFormLoad(string ColumnName, string PortType, string Orientation, string Style, string ThreadSize)
        {
            return ObjDAL.GetWPDSFormLoad(ColumnName, PortType, Orientation, Style, ThreadSize);
        }
        public string GetPartNUmber(string ColumnName, string PortType, string Orientation, string Style, string ThreadSize, string MinimunTubeOD)
        {
            return ObjDAL.GetWPDSPartCode(ColumnName, PortType, Orientation, Style, ThreadSize, MinimunTubeOD);
        }
        public string GetWPDS(string PartNumber, string TubeType,string TubeODMin)
        {
            return ObjDAL.GetWPDS(PartNumber, TubeType,TubeODMin);
        }
        public string ReadData(string Design, string CylinderHead, string BaseEnd, string TubeMaterial, string Rephasing)
        {
            return ObjDAL.ReadData(Design, CylinderHead, BaseEnd, TubeMaterial, Rephasing);
        }
        public DataTable WallThickness(string BoreDia)
        {
            return ObjDAL.WallThickness(BoreDia);
        }
    }
}


