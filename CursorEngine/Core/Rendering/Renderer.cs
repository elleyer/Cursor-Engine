using System;

namespace CursorEngine.Core.Rendering
{
    public abstract class Renderer<T> : IRenderer where T : IDrawable
    {
        public IDrawableProvider<T> Provider;
        
        public Renderer(IDrawableProvider<T> provider)
        {
            SetProvider(provider);
        }

        public void SetProvider(IDrawableProvider<T> provider)
        {
            Provider = provider;
        }
        
        public abstract void Render(IntPtr hdc, IntPtr hwnd);
    }
}