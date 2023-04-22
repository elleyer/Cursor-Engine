using System;

namespace CursorEngine.Core.Rendering
{
    public interface IRenderer
    {
        void Render(IntPtr hdc, IntPtr memDc);
    }
}