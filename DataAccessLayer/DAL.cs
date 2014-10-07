using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using IFLBaseDataLayer;
using IFLCommonLayer;
using System.Data;
using System.Windows.Forms;
using CMSTooling;


namespace DataAccessLayer
{
    public class DAL
    {

        string _strQuery;
        private IFLConnectionClass _CMSConnectionObject;
        private string _strErrorMessage;

        DataRow dRow;

        public IFLConnectionClass CMSConnectionObject
        {
            get { return _CMSConnectionObject; }
            set { _CMSConnectionObject = value; }
        }
        public Boolean GetConnection()
        {

            bool GetConnection = false;
            try
            {
                String strXMLFilePath = System.Environment.CurrentDirectory + "\\CMSToolingConnection.xml";
                DataSet oDataSet = new DataSet();
                oDataSet.ReadXml(strXMLFilePath);
                if (oDataSet.Tables.Count > 0)
                {
                    String strServer = oDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                    String strDataBase = oDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                    CMSConnectionObject = IFLBaseDataLayer.IFLConnectionClass.GetConnectionObject(strServer, strDataBase, "System.Data.SqlClient", "sa", "12345678", "");
                    GetConnection = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occured while connecting to server", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button3);
            }
            return GetConnection;
        }


        public DataTable SetWorkCenter(string OP_NO)
        {
            _strQuery = "select * from WorkCenter where OPNumber='" + OP_NO + "'";
            DataTable ObjData = new DataTable();
            GetConnection();
            ObjData = CMSConnectionObject.GetTable(_strQuery);
            if (ObjData.Rows.Count == 0)
            {
                ObjData = null;
                _strErrorMessage = "Data not retrieved from WorkCenter table";
            }
            return ObjData;

        }
        public DataTable GetOpSheet(string TableName)
        {
            _strQuery = "select SerialNumber,Description from TUBE_" + TableName;
            DataTable ObjData = new DataTable();
            GetConnection();
            ObjData = CMSConnectionObject.GetTable(_strQuery);
            if (ObjData.Rows.Count == 0)
            {
                ObjData = null;
                _strErrorMessage = "Data not retrieved from"+TableName+" table";
            }
            return ObjData;
        }
        public DataTable GetRiseAndFall()
        {
            _strQuery = "select RiseAndFall from CAM_OP_030_1";
            DataTable ObjData = new DataTable();
            GetConnection();
            ObjData = CMSConnectionObject.GetTable(_strQuery);
            if (ObjData.Rows.Count == 0)
            {
               ObjData = null;
               _strErrorMessage = "Data not retrieved from CAM_OP_030_1 table";
            }
            return ObjData;
        }
        public double GetBestCam(double RiseFall)
        {
            _strQuery = "select Tool from CAM_OP_030_1 where RiseAndFall=" + RiseFall;
            GetConnection();
            double Cam=Convert.ToDouble(CMSConnectionObject.GetValue(_strQuery));
            if (Cam == 0)
            {
                _strErrorMessage = "Data not retrieved from CAM_OP_030_1 table";
            }
            return Cam;
        }
        public DataTable PortLocatorLoad(string Columname)
        {
            _strQuery = "select distinct " + Columname + " from PortLocators";
            GetConnection();
            DataTable ObjDataTable = new DataTable();
            ObjDataTable = CMSConnectionObject.GetTable(_strQuery);
            if (ObjDataTable.Rows.Count == 0)
            {
                ObjDataTable = null;
                _strErrorMessage = "Data not retrieved from PortLocators table";
            }
            return ObjDataTable;
        }
        public DataTable PortLocatorLoad(string Columname, string PortSize)
        {
            _strQuery = "select distinct " + Columname + " from PortLocators where PortSize='" + PortSize+"'";
            GetConnection();
            DataTable ObjDataTable = new DataTable();
            ObjDataTable = CMSConnectionObject.GetTable(_strQuery);
            if (ObjDataTable.Rows.Count == 0)
            {
                ObjDataTable = null;
                _strErrorMessage = "Data not retrieved from PortLocators table";
            }
            return ObjDataTable;
        }
        public DataTable PortLocatorLoad(string Columname, string PortSize,string OrificeSize)
        {
            _strQuery = "select distinct " + Columname + " from PortLocators where PortSize='" + PortSize + "' and OrificeSize=" + OrificeSize;
            GetConnection();
            DataTable ObjDataTable = new DataTable();
            ObjDataTable = CMSConnectionObject.GetTable(_strQuery);
            if (ObjDataTable.Rows.Count == 0)
            {
                ObjDataTable = null;
                _strErrorMessage = "Data not retrieved from PortLocators table";
            }
            return ObjDataTable;
        }
        public string GetPortLocator(string PortSize, string OrificeSize, string Offset)
        {
            _strQuery = "select PortLocatorCode from PortLocators where PortSize='" + PortSize + "' and OrificeSize=" + OrificeSize + " and OffSet=" + Offset + "";
            GetConnection();
            string portLocator = string.Empty;
            portLocator = CMSConnectionObject.GetValue(_strQuery).ToString();
            if (portLocator == null)
            {
                portLocator = null; 
                _strErrorMessage = "Data not retrieved from PortLocators table";
            }
            return portLocator;
        }

        public DataRow GetToolingData(BEL objBEL)
        {
            String opNo = objBEL.OpNo;
            string BoreDiameter = objBEL.BoreDiameter;
            _strQuery = "Select WorkInstruction,Program,Tool from " + opNo + "Tooling where BoreDia='" + BoreDiameter + "'";

            GetConnection();
            dRow = CMSConnectionObject.GetDataRow(_strQuery);

            return dRow;
        }
        public DataRow GetToolData(BEL objBEL)
        {
            String opNo = objBEL.OpNo;
            string BoreDiameter = objBEL.BoreDiameter;
            _strQuery = "Select WorkInstruction,Program,Tool from " + opNo + " where BoreDia='" + BoreDiameter + "'";

            GetConnection();
            dRow = CMSConnectionObject.GetDataRow(_strQuery);

            return dRow;
        }

        public DataRow getDoubleWorkInstructionTooling(BEL objBEL)
        {
            String opNo = objBEL.OpNo;

            _strQuery = "Select WorkInstruction1,WorkInstruction2 from  DoubleWorkInstructionTooling where OP_No='" + opNo + "'";

            GetConnection();
            dRow = CMSConnectionObject.GetDataRow(_strQuery);

            return dRow;
        }

        public object GetStandardRunTimeForAll(BEL objBEL)
        {
            string BoreDiameter = objBEL.BoreDiameter;
            string tubeLength = objBEL.TubeLength;
            string op_No = objBEL.OpNo;
            _strQuery = "Select [BoreDia_" + BoreDiameter + "] from " + op_No + " where TubeLength='" + tubeLength + "'";
            GetConnection();
            object runTime = CMSConnectionObject.GetValue(_strQuery);
            return runTime;
        }

        public DataTable GetWPDSFormLoad(string ColumnName)
        {
            _strQuery = "select distinct " + ColumnName + " from PortsAndWPDSDetails";
            DataTable ObjDataTable = new DataTable();
            GetConnection();
            ObjDataTable = CMSConnectionObject.GetTable(_strQuery);
            if (ObjDataTable.Rows.Count == 0)
            {
                ObjDataTable = null;
                _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table";
            }
            return ObjDataTable;
        }
        public DataTable GetWPDSFormLoad(string ColumnName, string PortType)
        {
            _strQuery = "select distinct " + ColumnName + " from  PortsAndWPDSDetails where PortType='" + PortType + "'";
            DataTable ObjDataTable = new DataTable();
            GetConnection();
            ObjDataTable = CMSConnectionObject.GetTable(_strQuery);
            if (ObjDataTable.Rows.Count == 0)
            {
                ObjDataTable = null;
                _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table";
            }
            return ObjDataTable;
        }
        public DataTable GetWPDSFormLoad(string ColumnName, string PortType, string Orientation)
        {
            _strQuery = "select distinct " + ColumnName + " from  PortsAndWPDSDetails where PortType='" + PortType + "' and PortOrientation='" + Orientation + "' ";
            DataTable ObjDataTable = new DataTable();
            GetConnection();
            ObjDataTable = CMSConnectionObject.GetTable(_strQuery);
            if (ObjDataTable.Rows.Count == 0)
            {
                ObjDataTable = null;
                _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table";
            }
            return ObjDataTable;
        }
        public DataTable GetWPDSFormLoad(string ColumnName, string PortType, string Orientation,string Style)
        {
            _strQuery = "select distinct " + ColumnName + " from  PortsAndWPDSDetails where PortType='" + PortType + "' and PortOrientation='" + Orientation + "' and PORT_BASE='" + Style + "' ";
            DataTable ObjDataTable = new DataTable();
            GetConnection();
            ObjDataTable = CMSConnectionObject.GetTable(_strQuery);
            if (ObjDataTable.Rows.Count == 0)
            {
                ObjDataTable = null;
                _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table";
            }
            return ObjDataTable;
        }
        public DataTable GetWPDSFormLoad(string ColumnName, string PortType, string Orientation, string Style,string ThreadSize)
        {
            _strQuery = "select distinct " + ColumnName + " from  PortsAndWPDSDetails where PortType='" + PortType + "' and PortOrientation='" + Orientation + "' and PORT_BASE='" + Style + "' and PortThread='"+ThreadSize+"' ";
            DataTable ObjDataTable = new DataTable();
            GetConnection();
            ObjDataTable = CMSConnectionObject.GetTable(_strQuery);
            if (ObjDataTable.Rows.Count == 0)
            {
                ObjDataTable = null;
                _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table";
            }
            return ObjDataTable;
        }
        public string  GetWPDSPartCode(string ColumnName, string PortType, string Orientation, string Style, string ThreadSize,string MinimunTubeOD)
        {
            _strQuery = "select distinct " + ColumnName + " from  PortsAndWPDSDetails where PortType='" + PortType + "' and PortOrientation='" + Orientation + "' and PORT_BASE='" + Style + "' and PortThread='" + ThreadSize + "' and MinimumTubeOD="+ MinimunTubeOD+" ";
            string PartCode = string.Empty;
            GetConnection();
            PartCode = CMSConnectionObject.GetValue(_strQuery).ToString();
            if (PartCode==null)
            {
                PartCode = null;
                _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table";
            }
            return PartCode;
        }
        public string GetWPDS(string partNumber, string TubeType,string TubeODMin)
        {
            _strQuery = "select " + TubeType + " from PortsAndWPDSDetails where MinimumTubeOD='"+TubeODMin+"' and PortCode='" + partNumber + "'";
            string WPDS = string.Empty;
            GetConnection();
            WPDS = CMSConnectionObject.GetValue(_strQuery).ToString();
            if (WPDS == null)
            {
                WPDS = null;
                _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table";
            }
            return WPDS;
        }

        public string ReadData(string DesignValue, string cylinderHeadValue, string BaseEndPieceValue, string TubeMateialValue, string Rephasingvalue)
        {
            _strQuery = "select flowpath from sequenceRules where design= '" + DesignValue + "' and CylinderHead='" + cylinderHeadValue + "' and oneortwopiecebaseend='" + BaseEndPieceValue + "' and TubeMaterial='" + TubeMateialValue + "' and checkBallRephasing='" + Rephasingvalue + "'";
            string FlowPath = string.Empty;
            GetConnection();
            FlowPath = CMSConnectionObject.GetValue(_strQuery).ToString();
            if (FlowPath == null)
            {
                FlowPath = null;
                _strErrorMessage = "Data not retrieved from Sequence Rules table";
            }
            return FlowPath;
        }
        public DataTable WallThickness(string BoreDia)
        {
            _strQuery = "select WallThickness from WallThickness where BoreDia='" + BoreDia+"'";
            DataTable ObjDataTable = new DataTable();
            GetConnection();
            ObjDataTable = CMSConnectionObject.GetTable(_strQuery);
            if (ObjDataTable.Rows.Count == 0)
            {
                ObjDataTable = null;
                _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table";
            }
            return ObjDataTable;
        }
    }
}
