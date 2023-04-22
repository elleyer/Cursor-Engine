using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using CursorEngine.Core.Rendering;

namespace CursorEngine.Core
{
    public class Engine
    {
        private bool _fpsLock = true;
        private int _limitFps = 45;
        
        private ulong ticksSinceStart;

        private Point cursorPosition;

        private List<IUpdatable> _updatables;
        private List<IRenderer> _renderers;

        private IntPtr _layeredWindow;

        private int _screenResX;
        private int _screenResY;

        public Engine()
        {
            _updatables = new List<IUpdatable>();
            _renderers = new List<IRenderer>();
        }

        public void Start()
        {
            _screenResX = WindowsApi.GetSystemMetrics(WindowsApi.SM_CXSCREEN);
            _screenResY = WindowsApi.GetSystemMetrics(WindowsApi.SM_CYSCREEN);

            DebugExtensions.CreateDebugConsole();
            
            _layeredWindow = CreateLayeredWindow();
            SetLayeredWindowAttributes(_layeredWindow);

            //Load config and read values here.
            DebugExtensions.PushMessage($"{_screenResX}x{_screenResY}");
            DebugExtensions.PushMessage(Stopwatch.IsHighResolution.ToString());
            var updateThread = new Thread(ProcessLoop);
            updateThread.Start();
        }

        public void AddUpdatable(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void AddRenderer(IRenderer renderer)
        {
            _renderers.Add(renderer);
        }
        
        private void ProcessLoop()
        {
            var sw = new Stopwatch();
            sw.Start();

            var dt = 1000 / (double)_limitFps;

            ProcessTick(sw, dt, out var _);
            
            var timer = new MultimediaTimer();
            timer.Interval = TimeSpan.FromMilliseconds(dt);
            
            timer.Elapsed += (sender, args) =>
            {
                ProcessTick(sw, dt, out var newDt);
                DebugExtensions.SetTitle(
                    $"[Tick: {ticksSinceStart}] {_screenResX} x {_screenResY}@ {1000 / newDt:F}fps[{newDt:F1}ms]");
                timer.Interval = TimeSpan.FromMilliseconds(newDt);
                timer.Start();
            };
            
            timer.Start();
            Console.Read();
        }


        private void ProcessTick(Stopwatch sw, double prevDt, out double newDt)
        {
            var frameStartTime = sw.Elapsed.TotalMilliseconds;

            ProcessUpdate(prevDt);
            ProcessRender();
            
            ticksSinceStart++;
            var dt = sw.Elapsed.TotalMilliseconds - frameStartTime;
            newDt = dt;

            if (!_fpsLock)
                return;
            
            var nextFrameStartTime = frameStartTime + 1000 / (float)_limitFps;
            var now = sw.Elapsed.TotalMilliseconds;
                
            var timeUntilNext = nextFrameStartTime - now;

            if (timeUntilNext > 0)
            {
                dt = timeUntilNext;
            }

            newDt = dt;
        }
        
        private void ProcessUpdate(double dt)
        {
            foreach (var upd in _updatables)
            {
                upd.Update(dt);
            }
        }

        //Clear entire screen here,
        //then render anything at the current frame,
        //then release DC, because we should get it each time we need to render something,
        //and repeat on each tick.
        private void ProcessRender()
        {
            //Get DC for our layered window
            var hdc = WindowsApi.GetDeviceContext(_layeredWindow);

            //Create memory DC.
            var memDc = WindowsApi.CreateCompatibleDC(hdc);

            //Create hdc compatible Bitmap.
            var bitmap = WindowsApi.CreateCompatibleBitmap(hdc, _screenResX, _screenResY);
            var oldBitmap = WindowsApi.SelectObject(memDc, bitmap);

            //Will be required later for blending, etc.
            /*var blend = new WindowsApi.BlendFunc
            {
                BlendOp = 0,
                BlendFlags = 0,
                SourceConstantAlpha = 0,
                AlphaFormat = 0
            };
            
            var pt = Point.Empty;
            var sz = new Size(600, 600);
            var pt2 = Point.Empty;

            
            WindowsApi.UpdateLayeredWindow(_layeredWindow, hdc, ref pt, ref sz, memDc, ref pt2, 0, ref blend,
                2);*/

            foreach (var renderer in _renderers)
            {
                renderer.Render(hdc, memDc);
            }

            WindowsApi.BitBlt(hdc, 0, 0, _screenResX, _screenResY, memDc, 0, 0,
                WindowsApi.SRC_COPY);

            WindowsApi.SelectObject(memDc, oldBitmap);
            WindowsApi.DeleteObject(bitmap);
            WindowsApi.DeleteDC(memDc);
            WindowsApi.ReleaseDC(_layeredWindow, hdc);
        }

        private IntPtr CreateNoRedirectionBitmapWindow()
        {
            //var style = WindowsApi.WS_VISIBLE | 0x00000000 | 0x00C00000 | 0x00080000 | 0x00040000 | 0x00010000 | 0x00020000;

            //Calculate relative pos to our resolution and window position.
            var w = WindowsApi.CreateWindowEx(WindowsApi.WS_EX_NOREDIRECTIONBITMAP,
                "STATIC", "", WindowsApi.WS_VISIBLE,
                0, 0, _screenResX, _screenResY, IntPtr.Zero, IntPtr.Zero,
                IntPtr.Zero, IntPtr.Zero);
            return w;
        }

        private IntPtr CreateLayeredWindow()
        {
            var style = WindowsApi.WS_VISIBLE | WindowsApi.WS_CHILD;

            //Calculate relative pos to our resolution and window position.
            return WindowsApi.CreateWindowEx(WindowsApi.WS_EX_LAYERED
                                             | WindowsApi.WS_EX_TOPMOST | WindowsApi.WS_EX_TRANSPARENT,
                "STATIC", "", style,
                0, 0, _screenResX, _screenResY, IntPtr.Zero, IntPtr.Zero,
                IntPtr.Zero, IntPtr.Zero);
        }

        private void SetLayeredWindowAttributes(IntPtr ptr)
        {
            WindowsApi.SetWindowLongPtr(ptr, WindowsApi.GWL_EXSTYLE,
                WindowsApi.GetWindowLongPtr(ptr, WindowsApi.GWL_EXSTYLE)
                | (int)WindowsApi.WS_EX_LAYERED
                | (int)WindowsApi.WS_EX_TRANSPARENT
                | (int)WindowsApi.WS_EX_NOACTIVATE
                | (int)WindowsApi.WS_EX_TOPMOST);
            var cKey = (uint)ColorTranslator.ToWin32(Color.FromArgb(0, 0, 0, 0));
            WindowsApi.SetLayeredWindowAttributes(ptr, cKey, 0, WindowsApi.LWA_COLORKEY);
            WindowsApi.SetWindowLongPtr(ptr, WindowsApi.GWL_STYLE, (int)WindowsApi.WS_VISIBLE);
        }
    }
}