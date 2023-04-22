using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using CurEditor.Core;
using CurEditor.Core.Cursor;
using CurEditor.IO;
using Gma.System.MouseKeyHook;

namespace CurEditor
{
    public sealed partial class Form1 : Form
    {
        private CursorHandler _cursorHandler;

        public Form1()
        {
            InitializeComponent();
            
            //For debug proposes.
            DebugExtensions.CreateDebugConsole();

            if (!SettingsContainer.SaveExists) return;
            
            var settings = SettingsContainer.Get();
            Init(settings);
        }

        private void Init(Settings settings)
        {
            UseScaling.Checked = settings.UseScaling;
            UseScalingInterpolation.Checked = settings.UseScalingInterpolation;
            UseRotation.Checked = settings.UseRotation;

            MinScaleSlider.Value = (int) (settings.MinCursorScale * 10);
            RotationSlider.Value = settings.RotationAngle;
            InterpolationSlider.Value = (int) (settings.InterpolationTime / 100f);
            
            var inButtons = InterpolationIn.Controls.OfType<RadioButton>().ToArray();
            inButtons[(int)settings.EasingIn].Checked = true;
            
            var outButtons = InterpolationOut.Controls.OfType<RadioButton>().ToArray();
            outButtons[(int)settings.EasingOut].Checked = true;
            
            _cursorHandler = new CursorHandler(settings);
        }

        private void SaveAllOnClick(object sender, EventArgs e)
        {
            var inButtons = InterpolationIn.Controls.OfType<RadioButton>().ToArray();
            Console.WriteLine(inButtons.Length);
            var inIndex = Array.IndexOf(inButtons, inButtons.Single(x => x.Checked));
            
            var outButtons = InterpolationOut.Controls.OfType<RadioButton>().ToArray();
            var outIndex = Array.IndexOf(outButtons, outButtons.Single(x => x.Checked));
            
            SettingsContainer.Update(UseScaling.Checked, UseScalingInterpolation.Checked, 
                UseRotation.Checked, MinScaleSlider.Value, InterpolationSlider.Value, 
                RotationSlider.Value, (EasingType)inIndex, (EasingType)outIndex);

            var settings = SettingsContainer.Get();
            
            if (_cursorHandler == null)
                _cursorHandler = new CursorHandler(settings);
            else
                _cursorHandler.UpdateSettings(settings);
        }

        private void SelectFolderOnClick(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();
                
                using (var fm = new FileManager())
                {
                    var containers = fm.GetContainers(dialog.SelectedPath);
                    var count = containers.Count;

                    for (var i = 0; i < count; i++)
                    {
                        CursorTreeView.Nodes.Add(containers[i].GetName());

                        var files = containers[i].GetFiles();

                        foreach (var file in files)
                        {
                            CursorTreeView.Nodes[i].Nodes.Add(file);   
                        }
                    }
                }
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            //_cursorHandler.SetDefault();
        }
    }
}