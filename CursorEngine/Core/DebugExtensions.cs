using System;
using System.Runtime.InteropServices;

namespace CursorEngine.Core
{
    public class DebugExtensions
    {
        [DllImport("Kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("Kernel32.dll")]
        private static extern bool FreeConsole();

        public static void CreateDebugConsole()
        {
            AllocConsole();
        }

        public static void SetTitle(string msg)
        {
            Console.Title = msg;
        }
        
        public static void PushError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteMessage(message);
        }

        public static void PushWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteMessage(message);
        }

        public static void PushMessage(string message)
        {
            WriteMessage(message);
        }

        private static void WriteMessage(string message)
        {
            Console.WriteLine($@"[{DateTime.Now}]> {message}");
            Console.ResetColor();
        }
    }
}