using System;
using EasingSharp;
using WinApi;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using WinApi.User32;
using WinApi.Windows;

namespace CurEditor
{
    public sealed partial class Form1 : Form
    {
        private IKeyboardMouseEvents _globalHook;

        private Point _lastClickPoint;

        private Size _startSize;

        private bool _isLeftHeld;
        
        public Form1()
        {
            InitializeComponent();

            _startSize = Cursor.Size;

            Subscribe();
        }

        private void Subscribe()
        {
            _globalHook = Hook.GlobalEvents();

            _globalHook.MouseDownExt += ResizeOnDown;
            _globalHook.MouseUpExt += ResizeOnUp;;
            _globalHook.MouseClick += OnClick;
        }
        
        private void OnClick(object sender, MouseEventArgs e)
        {
            _isLeftHeld = true;
            
            _lastClickPoint = e.Location;
        }

        private void ResizeOnDown(object sender, MouseEventExtArgs e)
        {
            SetSystemCursorsScale(0.7f);
            var thread = new Thread(ResizeDown);
            thread.Start();
        }

        private void ResizeOnUp(object sender, MouseEventExtArgs e)
        {
            _isLeftHeld = false;
            SetSystemCursorsScale(1.0f);
            
            var thread = new Thread(ResizeUp);
            thread.Start();
        }

        private void ResizeDown()
        {
            //Easing.Run();
        }

        private void ResizeUp()
        {
            //SetSystemCursorsSize(32);
            
            
            /*for (var i = 16; i < _startSize.Height; i+=2)
            {
                SetSystemCursorsSize(i);
                Thread.Sleep(1000 / 500);
            }*/
        }

        private void Rotate()
        {
            while (_isLeftHeld)
            {
                
            }
        }

        [DllImport("user32.dll")]
        private static extern bool SetSystemCursor(IntPtr hcur, uint id);

        [DllImport("user32.dll")]
        private static extern bool DestroyIcon(IntPtr hIcon);

        enum CursorShift
        {
            Centered,
            LowerRight,
        }

        private void SetSystemCursorsScale(float deltaScale)
        {
            ResizeCursor(Cursors.AppStarting, deltaScale, CursorShift.LowerRight);
            ResizeCursor(Cursors.Arrow, deltaScale, CursorShift.LowerRight);
            ResizeCursor(Cursors.Cross, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.Hand, deltaScale, CursorShift.LowerRight);
            ResizeCursor(Cursors.Help, deltaScale, CursorShift.LowerRight);
            ResizeCursor(Cursors.HSplit, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.IBeam, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.No, deltaScale, CursorShift.LowerRight);
            ResizeCursor(Cursors.NoMove2D, deltaScale, CursorShift.LowerRight);
            ResizeCursor(Cursors.NoMoveHoriz, deltaScale, CursorShift.LowerRight);
            ResizeCursor(Cursors.NoMoveVert, deltaScale, CursorShift.LowerRight);
            ResizeCursor(Cursors.PanEast, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.PanNE, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.PanNorth, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.PanNW, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.PanSE, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.PanSouth, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.PanSW, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.PanWest, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.SizeAll, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.SizeNESW, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.SizeNS, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.SizeNWSE, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.SizeWE, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.UpArrow, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.VSplit, deltaScale, CursorShift.Centered);
            ResizeCursor(Cursors.WaitCursor, deltaScale, CursorShift.LowerRight);
        }
        
        private void ResizeCursor(Cursor cursor, float deltaScale, CursorShift cursorShift)
        {
            var cursorImage = GetSystemCursorBitmap(cursor);
            
            var rescaledCursor = ReScaleBitmap(cursorImage, deltaScale);

            //var rotatedCursor = RotateCursorBitmap(cursorImage, 
                //GetAngleByPoints(_lastClickPoint.X, _lastClickPoint.Y)) as Bitmap;
            
            SetCursor(rescaledCursor, GetResourceId(cursor));
        }
        
        private static Bitmap ReScaleBitmap(Image bitmap, float deltaScale)
        {
            var destImage = new Bitmap(bitmap.Width, bitmap.Height);
            
            var gfx = Graphics.FromImage(destImage);
            
            gfx.ScaleTransform(deltaScale, deltaScale);

            gfx.CompositingMode = CompositingMode.SourceCopy;
            gfx.CompositingQuality = CompositingQuality.HighQuality;
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.SmoothingMode = SmoothingMode.HighQuality;
            gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
            
            gfx.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);

            return destImage;
        }

        private static float GetAngleByPoints(float x, float y)
        {
            return 45;
        }
        
        private float Lerp(float firstFloat, float secondFloat, float by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }

        private static Bitmap GetSystemCursorBitmap(Cursor cursor)
        {
            var bitmap = new Bitmap(
                cursor.Size.Width, cursor.Size.Height);

            var graphics = Graphics.FromImage(bitmap);

            cursor.Draw(graphics,
                new Rectangle(new Point(0, 0), cursor.Size));

            return bitmap;
        }

        private static Image RotateCursorBitmap(Image bitmap, float angle)
        {
            var returnBitmap = new Bitmap(bitmap.Height, bitmap.Width);

            var gfx = Graphics.FromImage(returnBitmap);

            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            
            gfx.TranslateTransform((float)bitmap.Width / 2, (float)bitmap.Height / 2);
            gfx.RotateTransform(angle);
            
            gfx.TranslateTransform(-(float)bitmap.Height / 2, -(float)bitmap.Width / 2);
            gfx.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);

            return returnBitmap;
        }

        private static uint GetResourceId(Cursor cursor)
        {
            var fi = typeof(Cursor).GetField(
                "resourceId", BindingFlags.NonPublic | BindingFlags.Instance);

            if (fi == null) return 0;
            
            var obj = fi.GetValue(cursor);
            return Convert.ToUInt32((int) obj);

        }

        private static void SetCursor(Bitmap bitmap, uint whichCursor)
        {
            var ptr = bitmap.GetHicon();
            SetSystemCursor(ptr, whichCursor);
            DestroyIcon(ptr);
            bitmap.Dispose();
        }
    }
}