using System.Collections.Generic;

namespace CurEditor.Core.Cursor
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
        cur = 0,
        ani = 1
    }
}