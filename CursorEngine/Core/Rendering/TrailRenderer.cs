using System;
using System.Drawing;
using CursorEngine.Core.Trails;

namespace CursorEngine.Core.Rendering
{
    public class TrailRenderer : Renderer<TrailSegment>
    {
        //private IntPtr _pen;
        public TrailRenderer(IDrawableProvider<TrailSegment> provider) : base(provider)
        {
        }
        
        public override void Render(IntPtr hdc, IntPtr memDc)
        {
            var objects = Provider.GetDrawables();
            var originColor = Color.Gold;

            TrailSegment prevSegment = null;
            foreach (var drawable in objects)
            {
                if (prevSegment != null)
                {
                    var currentLifeState = drawable.Lifetime / drawable.InitialLifetime;
                    
                    var color = Color.FromArgb(
                        255/*(int) Math.Round(currentLifeState * 255)*/, 
                        originColor.R, originColor.G,
                        originColor.B);
                    
                    //Create and select pen
                    var pen = WindowsApi.CreatePen(WindowsApi.PS_SOLID, (int)(8 *(float)currentLifeState), 
                        (uint) ColorTranslator.ToWin32(color));
                    var oldPen = WindowsApi.SelectObject(memDc, pen);

                    //Draw line
                    WindowsApi.MoveToEx(memDc, prevSegment.Position.X, prevSegment.Position.Y, IntPtr.Zero);
                    WindowsApi.LineTo(memDc, drawable.Position.X, drawable.Position.Y);
                    
                    //Delete pen
                    WindowsApi.SelectObject(memDc, oldPen);
                    WindowsApi.DeleteObject(pen);
                }
                prevSegment = drawable;
            }
        }
    }
}