using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CursorEngine.Core.Cursor;

namespace CursorEngine.IO
{
    public class FileManager : IDisposable
    {
        public List<CursorContainer> GetContainers(string path)
        {
            var contList = new List<CursorContainer>();
            
            var directories = Directory.GetDirectories(path);
            var countOfD = directories.Length;

            for (var i = 0; i < countOfD; i++)
            {
                var files = Directory.GetFiles(directories[i]);
                var filesList = new List<string>();
                
                var countOfFiles = files.Length;

                for (var j = 0; j < countOfFiles; j++)
                {
                    filesList.Add(Path.GetFileName(files[j]));
                }
                
                var directoryInfo = new DirectoryInfo(directories[i]).Name;
                
                contList.Add(new CursorContainer(directoryInfo, filesList));
            }

            return contList;
        }

        public Cursor GetCursor(string path)
        {
            return new Cursor("123");
        }

        public void Dispose(){}
    }
}