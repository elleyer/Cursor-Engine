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

        public void Dispose()
        {
        }
    }
}