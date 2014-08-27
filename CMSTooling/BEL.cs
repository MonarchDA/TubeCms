using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSTooling
{
    public class BEL
    {
        private string _Design;

        public string Design
        {
            get { return _Design; }
            set { _Design = value; }
        }
        private string _CylinderHead;

        public string CylinderHead
        {
            get { return _CylinderHead; }
            set { _CylinderHead = value; }
        }
        private string _TubeMaterial;

        public string TubeMaterial
        {
            get { return _TubeMaterial; }
            set { _TubeMaterial = value; }
        }
        private string _BaseEnd;

        public string BaseEnd
        {
            get { return _BaseEnd; }
            set { _BaseEnd = value; }
        }
        private string _Rephasing;

        public string Rephasing
        {
            get { return _Rephasing; }
            set { _Rephasing = value; }
        }
        private string _WeldType;

        public string WeldType
        {
            get { return _WeldType; }
            set { _WeldType = value; }
        }
        private string _PortOrientation;

        public string PortOrientation
        {
            get { return _PortOrientation; }
            set { _PortOrientation = value; }
        }
        private string _PortAngle;

        public string PortAngle
        {
            get { return _PortAngle; }
            set { _PortAngle = value; }
        }
        private string _MainOrificeSize;

        public string MainOrificeSize
        {
            get { return _MainOrificeSize; }
            set { _MainOrificeSize = value; }
        }
        private string _FabricationDrillingHole;

        public string FabricationDrillingHole
        {
            get { return _FabricationDrillingHole; }
            set { _FabricationDrillingHole = value; }
        }
        
            private string _BoreDiameter;

            public string BoreDiameter
            {
                get { return _BoreDiameter; }
                set { _BoreDiameter = value; }
            }

            private string _RephasingAt;
            public string RephasingAt
            {
                get { return _RephasingAt; }
                set { _RephasingAt = value; }
            }




            private string _OpNo;

            public string OpNo
            {
                get { return _OpNo; }
                set { _OpNo = value; }
            }
            private string _TubeLength;

            public string TubeLength
            {
                get { return _TubeLength; }
                set { _TubeLength = value; }
            }
            private string _PortType;

            public string PortType
            {
                get { return _PortType; }
                set { _PortType = value; }
            }
            private string _StandardRunTime;

            public string StandardRunTime
            {
                get { return _StandardRunTime; }
                set { _StandardRunTime = value; }
            }

            private string _MainCAM;

            public string MainCAM
            {
                get { return _MainCAM; }
                set { _MainCAM = value; }
            }
            private string _MainPortLocator;

            public string MainPortLocator
            {
                get { return _MainPortLocator; }
                set { _MainPortLocator = value; }
            }
            private string _MainWPDS;

            public string MainWPDS
            {
                get { return _MainWPDS; }
                set { _MainWPDS = value; }
            }
            private string _WallThickness;

            public string WallThickness
            {
                get { return _WallThickness; }
                set { _WallThickness = value; }
            }
            private string _TubeEndconfiguration;

            public string TubeEndconfiguration
            {
                get { return _TubeEndconfiguration; }
                set { _TubeEndconfiguration = value; }
            }
        //============
            private string _Ports;
            public string Ports
            {
                get { return _Ports; }
                set { _Ports = value; }
            }
            //============

            private string _WeldSize;

            public string WeldSize
            {
                get { return _WeldSize; }
                set { _WeldSize = value; }
            }
            private string _PartWeight;

            public string PartWeight
            {
                get { return _PartWeight; }
                set { _PartWeight = value; }
            }
            private double _PinHoleSize;

            public double PinHoleSize
            {
                get { return _PinHoleSize; }
                set { _PinHoleSize = value; }
            }
            private double _HoleDepth;

            public double HoleDepth
            {
                get { return _HoleDepth; }
                set { _HoleDepth = value; }
            }
            private int _FlowPathNumber;

            public int FlowPathNumber
            {
                get { return _FlowPathNumber; }
                set { _FlowPathNumber = value; }
            }

        #region CAMForm Properties ..........
            private double _TubeOD;

            public double TubeOD
            {
                get { return _TubeOD; }
                set { _TubeOD = value; }
            }
            private double _PortOD;

            public double PortOD
            {
                get { return _PortOD; }
                set { _PortOD = value; }
            }
            private double _Cam;

            public double Cam
            {
                get { return _Cam; }
                set { _Cam = value; }
            }
           
        #endregion.................

          
        #region PortLocatorForm Properties........
            private string _PortSize;

            public string PortSize
            {
                get { return _PortSize; }
                set { _PortSize = value; }
            }
            private string _OrificeSize;

            public string OrificeSize
            {
                get { return _OrificeSize; }
                set { _OrificeSize = value; }
            }
            private string _OffSet;

            public string OffSet
            {
                get { return _OffSet; }
                set { _OffSet = value; }
            }

           
        #endregion.................
      
        #region WPDSForm Properties ..........
            private string _PortTypeWpds;

            public string PortTypeWpds
            {
                get { return _PortTypeWpds; }
                set { _PortTypeWpds = value; }
            }
            private string _Orientation;

            public string Orientation
            {
                get { return _Orientation; }
                set { _Orientation = value; }
            }
            private string _Style;

            public string Style
            {
                get { return _Style; }
                set { _Style = value; }
            }
            private string _ThreadSize;

            public string ThreadSize
            {
                get { return _ThreadSize; }
                set { _ThreadSize = value; }
            }
            private string _TubeODMin;

            public string TubeODMin
            {
                get { return _TubeODMin; }
                set { _TubeODMin = value; }
            }
           
            private string _PartCode;

            public string PartCode
            {
                get { return _PartCode; }
                set { _PartCode = value; }
            }
            private string _TubeType;

            public string TubeType
            {
                get { return _TubeType; }
                set { _TubeType = value; }
            }
        #endregion.................

    }
           
}


