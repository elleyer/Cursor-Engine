using System.Collections.Generic;

namespace CursorEngine.Core.Cursor
{
    public class CursorContainer
    {
        private readonly string _directoryName;

        private readonly List<string> _files;

        public CursorContainer(string dName, List<string> files)
        {
            _directoryName = dName;
            _files = files;
        }

        public string GetName() => _directoryName;

        public IEnumerable<string> GetFiles() => _files;
    }

    public enum FileExtensions
    {
        Cur = 0,
        Ani = 1
    }
}