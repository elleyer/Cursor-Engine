using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursorEngine.IO;
using Gma.System.MouseKeyHook;

namespace CursorEngine.Core.Cursor
{
    public class CursorHandler : IDisposable
    {
        private const int MAXSCALE = 1;
        
        private readonly IKeyboardMouseEvents _globalHook;

        /// <summary>
        /// Prerendered cursors data.
        /// </summary>
        private Utils.BitmapWithOffset[] _prerenderedData;

        /// <summary>
        /// Original user's cursor.
        /// </summary>
        private Bitmap _origin;

        private Action<double> _rescaleDelta;

        private int _lastPrerendered = 0;

        /*public CursorHandler(Settings settings)
        {
            _globalHook = Hook.GlobalEvents();
            
            _origin = Utils.GetSystemCursorBitmap(Cursors.Arrow);

            PreRenderCursors(settings.MinCursorScale,
                settings.InterpolationTime);
            
            Subscribe();
        }

        public void UpdateSettings(Settings settings)
        {
            _prerenderedData = null;
            _lastPrerendered = 0;
            
            Unsubscribe();

            PreRenderCursors(settings.MinCursorScale,    
                settings.InterpolationTime, true);
            
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
            Debug.WriteLine($"Down {DateTime.Now}");
            await Task.Run(() => RescaleDown(_prerenderedData).ConfigureAwait(false));
        }

        private async void OnMouseUp(object sender, MouseEventExtArgs e)
        {
            Debug.WriteLine($"Up {DateTime.Now}");
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
            _prerenderedData = new Utils.BitmapWithOffset[(int) (time / FRAMETIME)];
            _prerenderedData[0].Bitmap = _origin;

            DebugExtensions.PushWarning("Prerendering elements.");
            Easing.Run(_rescaleDelta = PreRenderElement,
                Easing.Easings.Liner, MAXSCALE, minScale, time);
        }

        private void PreRenderElement(double delta)
        {
            _prerenderedData[_lastPrerendered] = Utils.ReScaleBitmap(EasingType.Linear, _prerenderedData[0].Bitmap, delta);
            //TODO: Easing type

            if (_lastPrerendered == _prerenderedData.Length)
                return;
            
            _lastPrerendered++;
        }
        
        #endregion

        #region Rescaling
        
        private async Task RescaleUp(IReadOnlyList<Utils.BitmapWithOffset> bitmaps) //TODO: Easing type
        {
            var size = _lastPrerendered;

            await Task.Run(() =>
            {
                for (var i = size - 1; i >= 0; i--)
                {
                    SetCursor(bitmaps[i].Bitmap.GetHicon(), 0);
                }
            }).ConfigureAwait(false);
        }

        private async Task RescaleDown(IReadOnlyList<Utils.BitmapWithOffset> bitmaps)
        {
            var size = _lastPrerendered;
            
            await Task.Run(() =>
            {
                for (var i = 0; i < size; i++)
                {
                    SetCursor(bitmaps[i].Bitmap.GetHicon(), 0);
                }
            }).ConfigureAwait(false);
        }
        
        #endregion

        private static void SetCursor(IntPtr hicon, uint curr)
        {
            curr = Utils.GetCursorResourceId(Cursors.Arrow);
            SetSystemCursor(hicon, curr);
            DestroyIcon(hicon);
        }*/

        public void Dispose()
        {
            //Unsubscribe();
        }
    }
}