using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CursorEngine.Core
{
    public static class WindowsApi
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);
        
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);
        
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);
        
        public static bool GetCursorPosition(out Point p) => GetCursorPos(out p);
        public static bool SetCursorPosition(int x, int y) => SetCursorPos(x, y);
        public static IntPtr GetDeviceContext(IntPtr handleRef) => GetDC(handleRef);

        [DllImport("user32.dll")]
        public static extern bool SetSystemCursor(IntPtr hcur, uint id);

        [DllImport("user32.dll")]
        public static extern bool DestroyIcon(IntPtr hIcon);
        
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        
        [DllImport("gdi32.dll")]
        public static extern int DeleteObject(IntPtr hObj);
        
        [DllImport("gdi32.dll")]
        public static extern int DeleteDC(IntPtr hdc);
        
        [DllImport("user32.dll")]
        public static extern IntPtr CreateWindowEx(
            uint dwExStyle,
            string lpClassName,
            string lpWindowName,
            uint dwStyle,
            int x,
            int y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam
        );
        
        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(
            IntPtr hwnd,
            uint crKey,
            byte bAlpha,
            uint dwFlags
        );
        
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, 
            IntPtr hdcSrc, ref Point pptSrc, int crKey, ref BlendFunc pblend, int dwFlags);
        
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, 
            int xSrc, int ySrc, int rop);
        
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, uint crColor);
        
        [DllImport("gdi32.dll")]
        public static extern bool MoveToEx(IntPtr hdc, int x, int y, IntPtr lpPoint);
        
        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        public static extern int SetWindowLongPtr(IntPtr hWnd, int nIndex, int dwNewLong);
        
        [DllImport("user32.dll", EntryPoint = "GetWindowLong", SetLastError = true)]
        public static extern int GetWindowLongPtr(IntPtr hWnd, int nIndex);

        [DllImport("gdi32.dll")]
        public static extern bool LineTo(IntPtr hdc, int x, int y);
        
        public const int PS_SOLID = 0;
        
        public const int SRC_COPY = 0xCC0020;
        
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        public const int SM_CXSCREEN = 0;
        public const int SM_CYSCREEN = 1;
        
        public static readonly int GWL_STYLE = -16;
        public static readonly int GWL_EXSTYLE = -20;
        
        //Window constants.
        public const uint WS_EX_LAYERED = 0x00080000;
        public const uint WS_EX_TRANSPARENT = 0x20;
        public const uint WS_EX_NOACTIVATE = 0x08000000;
        public const uint WS_EX_TOPMOST = 0x00000008;
        public const uint WS_EX_NOREDIRECTIONBITMAP = 0x0020000;
        public const uint WS_VISIBLE = 0x10000000;
        public const uint WS_CHILD = 0x4000000;
        public const uint WS_POPUP = 0x8000000;
        public const uint WS_MAXIMIZED = 0x0100000;
        public const uint WS_BORDER = 0x0080000;
        public const uint WS_CAPTION = 0x00C0000;

        public const uint LWA_ALPHA = 0x00000002;
        public const uint LWA_COLORKEY = 0x00000001;
        
        [StructLayout(LayoutKind.Sequential)]
        public struct BlendFunc
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;

            public BlendFunc(byte op, byte flags, byte alpha, byte format)
            {
                BlendOp = op;
                BlendFlags = flags;
                SourceConstantAlpha = alpha;
                AlphaFormat = format;
            }
        }
    }
}