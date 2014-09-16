using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace CMSTooling
{
    class clsImageCapture
    {
        [DllImport("gdi32")]
        public static extern int CreateDC(string lpDriverName, string lpDeviceName, string lpOutput, string lpInitData);
          [DllImport("gdi32")]
        public static extern int CreateCompatibleDC(int hDc);
          [DllImport("gdi32")]
        public static extern int CreateCompatibleBitmap(int hDC, int nWidth, int nHeight);
          [DllImport("gdi32")]
        public static extern int GetDeviceCaps(int hdc, int nIndex);
          [DllImport("gdi32")]
        public static extern int SelectObject(int hDC, int hObject);
          [DllImport("gdi32")]
        public static extern int BitBlt(int srchDC, int srcX, int srcY, int srcW, int srcH, int desthDC, int destX, int destY, int op);
          [DllImport("gdi32")]
        public static extern int DeleteDC(int hDC);
          [DllImport("gdi32")]
        public static extern int DeleteObject(int hObj);
        const int SRCCOPY = 0xcc0020;
        public Bitmap Background;
        public int fw, fh;
        public static object[] img_arry;
        public int intI;
        public bool blnTab;
        public static object[] tab_imgaarry;
        public static TreeNode node;
        public static PictureBox pic;

        public void CaptureScreen()
        {
            try
            {
                int hsdc, hmdc;
                int hbmp, hbmpold;
                int r;
                hsdc = CreateDC("DISPLAY", "", "", "");
                hmdc = CreateCompatibleDC(hsdc);
                fw = GetDeviceCaps(hsdc, 8);
                fh = GetDeviceCaps(hsdc, 10);
                hbmp = CreateCompatibleBitmap(hsdc, fw, fh);
                hbmpold = SelectObject(hmdc, hbmp);
                r = BitBlt(hmdc, 0, 0, fw, fh, hsdc, 0, 0, 13369376);
                hbmp = SelectObject(hmdc, hbmpold);
                r = DeleteDC(hsdc);
                r = DeleteDC(hmdc);
                Background = Image.FromHbitmap(new IntPtr(hbmp));
                DeleteObject(hbmp);


            }
            catch (Exception)
            {


            }
        }
        public void StoreImages()
        {
            try
            {
                CaptureScreen();
                pic = new PictureBox();
                pic.Image = Background;
                img_arry[intI] = pic.Image;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //private bool getTreeViewInfo_Tabs(string strScreenName)
        //{
        //    int k = 0;
        //    return;
        //}
    }
}
