using System.Collections.Generic;

namespace CursorEngine.Core
{
    public interface IDrawableProvider<T> where T : IDrawable
    {
        List<T> GetDrawables();
    }
}