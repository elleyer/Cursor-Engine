using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurEditor.IO;
using Gma.System.MouseKeyHook;

namespace CurEditor.Core.Cursor
{
    public class CursorHandler : IDisposable
    {
        [DllImport("user32.dll")]
        private static extern bool SetSystemCursor(IntPtr hcur, uint id);

        [DllImport("user32.dll")]
        private static extern bool DestroyIcon(IntPtr hIcon);

        private const double FRAMETIME = 1000/60d;
        
        private const int MAXSCALE = 1;
        
        private readonly IKeyboardMouseEvents _globalHook;

        private Bitmap[] _prerenderedData;

        private Bitmap _origin;

        private Action<double> _rescaleDelta;

        private int _lastPrerendered = 0;

        public CursorHandler(Settings settings)
        {
            _globalHook = Hook.GlobalEvents();
            
            _origin = Utils.GetSystemCursorBitmap(Cursors.Arrow);

            PreRenderCursors(settings.MinCursorScale / 10f,
                settings.InterpolationSpeed * 100);
            
            Subscribe();
        }

        public void UpdateSettings(Settings settings)
        {
            _prerenderedData = null;
            _lastPrerendered = 0;
            
            Unsubscribe();

            PreRenderCursors(settings.MinCursorScale / 10f,    
                settings.InterpolationSpeed * 100, true);
            
            Subscribe();
        }

        #region Events
        
        private void Subscribe() //rename
        {
            _globalHook.MouseDownExt += OnMouseDown;
            _globalHook.MouseUpExt += OnMouseUp;
        }

        private void Unsubscribe() //rename
        {
            _globalHook.MouseDownExt -= OnMouseDown;
            _globalHook.MouseUpExt -= OnMouseUp;
        }
        
        private async void OnMouseDown(object sender, MouseEventExtArgs e)
        {
            await Task.Run(() => RescaleDown(_prerenderedData).ConfigureAwait(false));
        }

        private async void OnMouseUp(object sender, MouseEventExtArgs e)
        {
            await Task.Run(() => RescaleUp(_prerenderedData).ConfigureAwait(false));
        }

        private void OnRenderingComplete()
        {
            Subscribe();
        }
        
        #endregion
        
        #region Rendering
        
        private void PreRenderCursors(float minScale, int time, bool isUpdate = false)
        {
            _prerenderedData = new Bitmap[(int) (time / FRAMETIME)];
            _prerenderedData[0] = _origin;

            Easing.Run(_rescaleDelta = PreRenderElement,
                Easing.Easings.Liner, MAXSCALE, minScale, time);
        }

        private void PreRenderElement(double delta)
        {
            _prerenderedData[_lastPrerendered] = Utils.ReScaleBitmap(EasingType.Linear, _prerenderedData[0], delta); //TODO: Easing type

            if (_lastPrerendered == _prerenderedData.Length)
                return;
            
            _lastPrerendered++;
        }
        
        #endregion

        #region Rescaling
        
        private async Task RescaleUp(IReadOnlyList<Bitmap> bitmaps) //TODO: Easing type
        {
            var size = _lastPrerendered;

            await Task.Run(() =>
            {
                for (var i = size - 1; i >= 0; i--)
                {
                    SetCursor(bitmaps[i].GetHicon(), 0);
                }
            });
        }

        private async Task RescaleDown(IReadOnlyList<Bitmap> bitmaps)
        {
            var size = _lastPrerendered;
            
            await Task.Run(() =>
            {
                for (var i = 0; i < size; i++)
                {
                    SetCursor(bitmaps[i].GetHicon(), 0);
                }
            });
        }
        
        #endregion

        private static void SetCursor(IntPtr hicon, uint whichCursor)
        {
            whichCursor = Utils.GetCursorResourceId(Cursors.Arrow);
            SetSystemCursor(hicon, whichCursor);
            DestroyIcon(hicon);
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}