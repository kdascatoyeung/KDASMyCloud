using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace KDTHK_DM_SP.utils
{
    public class RtfPrintUtil : RichTextBox
    {
        private const double anInch = 14.4;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARRANGE
        {
            public int cpMin;
            public int cpMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FORMATRANGE
        {
            public IntPtr hdc;
            public IntPtr hdcTarget;
            public RECT rc;
            public RECT rcPage;
            public CHARRANGE chrg;
        }

        private const int WM_USER = 0x0400;
        private const int EM_FORMATRANGE = WM_USER + 57;

        [DllImport("User32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, Int32 lParam);

        public int PrintImage(int nStartForm, Graphics g)
        {
            RECT rcToPrint = default(RECT);
            FORMATRANGE fr = default(FORMATRANGE);
            IntPtr iptHdc = IntPtr.Zero;
            IntPtr iptRes = IntPtr.Zero;
            IntPtr iptParam = IntPtr.Zero;

            rcToPrint.Top = 0;
            rcToPrint.Bottom = (int)Math.Ceiling((g.VisibleClipBounds.Height * anInch));
            rcToPrint.Left = 0;
            rcToPrint.Right = (int)Math.Ceiling((g.VisibleClipBounds.Width * anInch));

            iptHdc = g.GetHdc();

            fr.chrg.cpMin = nStartForm;
            fr.chrg.cpMax = -1;
            fr.hdc = fr.hdcTarget = iptHdc;

            fr.rc = rcToPrint;

            iptParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr));
            Marshal.StructureToPtr(fr, iptParam, false);

            iptRes = SendMessage(this.Handle, EM_FORMATRANGE, 1, iptParam.ToInt32());

            Marshal.FreeCoTaskMem(iptParam);

            g.ReleaseHdc(iptHdc);

            return iptRes.ToInt32();
        }
    }
}
