using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursorEngine.Properties;
using CursorEngine.Core;
using Newtonsoft.Json;

namespace CursorEngine.IO
{
    internal class SettingsContainer
    {
        private const string FILENAME = "settings.json";

        public static void Update(bool useSc, bool useScIntp, 
            bool useRot, int minSc, int intrTime, int rotAngle, EasingType eTypeIn, EasingType eTypeOut)
        {
            var settings = new Settings
            {
                UseScaling = useSc,
                UseRotation = useRot,
                UseScalingInterpolation = useScIntp,
                
                MinCursorScale = minSc / 10f,
                InterpolationTime = intrTime * 100,
                RotationAngle = rotAngle,
                
                EasingIn = eTypeIn,
                EasingOut = eTypeOut
            };

            var converted = JsonConvert.SerializeObject(settings, Formatting.Indented);
            
            var path = string.Join("/", Application.StartupPath, FILENAME);

            File.WriteAllText(path, converted);
        }

        public static Settings Get()
        {
            var path = string.Join("/", Application.StartupPath, FILENAME);

            string data;
                
            using (var fs = new FileStream(path, FileMode.Open))
            {
                using (var reader = new StreamReader(fs))
                { 
                    data = reader.ReadToEnd();
                } 
            }

            var settings = JsonConvert.DeserializeObject<Settings>(data);
            
            return settings;
            
        }
        
        public static bool SaveExists => 
            File.Exists(string.Join("/", Application.StartupPath, FILENAME));
    }
}
