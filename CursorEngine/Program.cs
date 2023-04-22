using System;
using System.Windows.Forms;
using CursorEngine.Core;
using CursorEngine.Core.Rendering;
using CursorEngine.Core.Trails;

namespace CursorEngine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var engine = new Engine();
            engine.Start();

            var trailSystem = new TrailSystem();
            engine.AddUpdatable(trailSystem);
            var trailRenderer = new TrailRenderer(trailSystem);
            engine.AddRenderer(trailRenderer);
            
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
        }
    }
}