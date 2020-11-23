using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CurEditor.IO;
using Gma.System.MouseKeyHook;

namespace CurEditor.Core.Cursor
{
    public class CursorHandler : IDisposable
    {
        private IKeyboardMouseEvents _globalHook;

        private Settings _settings;
        
        private bool _isLeftHeld;

        public CursorHandler(Settings settings)
        {
            _settings = settings;
            
            Subscribe();
        }

        [DllImport("user32.dll")]
        private static extern bool SetSystemCursor(IntPtr hcur, uint id);

        [DllImport("user32.dll")]
        private static extern bool DestroyIcon(IntPtr hIcon);
        
        public void UpdateSettings(Settings settings)
        {
            _settings = settings;
        }

        private void Subscribe()
        {
            _globalHook = Hook.GlobalEvents();

            _globalHook.MouseDownExt += OnMouseDown;
            _globalHook.MouseUpExt += OnMouseUp;
        }

        private void Unsubscribe()
        {
            _globalHook.MouseDownExt -= OnMouseDown;
            _globalHook.MouseUpExt -= OnMouseUp;
        }
        
        private void OnMouseDown(object sender, MouseEventExtArgs e)
        {
            _isLeftHeld = true;
            
            ScaleCursors(EasingType.OutCubic, _settings.MinCursorScale/10f);
        }

        private void OnMouseUp(object sender, MouseEventExtArgs e)
        {
            _isLeftHeld = false;
            
            ScaleCursors(EasingType.OutExpo, 1f);
        }

        private void ScaleCursors(EasingType easingType, float scaleTo)
        {
            //ResizeCursor(Cursors.Arrow, scaleTo, CursorShift.LowerRight);
            
            var cursorImage = Utils.GetSystemCursorBitmap(Cursors.Arrow);

            var rescaledCursor = Utils.ReScaleBitmap(easingType, cursorImage, scaleTo);

            //var rotatedCursor = RotateCursorBitmap(cursorImage, 
            //GetAngleByPoints(_lastClickPoint.X, _lastClickPoint.Y)) as Bitmap;

            SetCursor(rescaledCursor, Utils.GetCursorResourceId(Cursors.Arrow));
        }

        enum CursorShift
        {
            Centered,
            LowerRight,
        }

        private static void SetCursor(Bitmap bitmap, uint whichCursor)
        {
            var ptr = bitmap.GetHicon();
            SetSystemCursor(ptr, whichCursor);
            DestroyIcon(ptr);
            bitmap.Dispose();
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}