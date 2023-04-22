using CursorEngine.Core;
using Newtonsoft.Json;

namespace CursorEngine.IO
{
    public class Settings
    {
        [JsonProperty("Folder")]
        public object Folder { get; set; }

        [JsonProperty("UseScaling")]
        public bool UseScaling { get; set; }

        [JsonProperty("UseScalingInterpolation")]
        public bool UseScalingInterpolation { get; set; }

        [JsonProperty("UseRotation")]
        public bool UseRotation { get; set; }

        [JsonProperty("MinCursorScale")]
        public float MinCursorScale { get; set; }

        
        /// <summary>
        /// Interpolation time in ms.
        /// </summary>
        [JsonProperty("InterpolationSpeed")]
        public int InterpolationTime { get; set; }

        [JsonProperty("RotationAngle")]
        public int RotationAngle { get; set; }

        [JsonProperty("EasingIn")]
        public EasingType EasingIn { get; set; }

        [JsonProperty("EasingOut")]
        public EasingType EasingOut { get; set; }
    }
}
