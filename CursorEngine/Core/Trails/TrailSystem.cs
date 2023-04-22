using System.Drawing;

namespace CursorEngine.Core
{
    public class TrailSystem : IUpdatable
    {
        public bool Enabled { get; set; }
        
        private Point _cursorPoint;
        
        private Bitmap _trailTexture;
        private Color _trailColor;
        
        private bool _useBlending;
        public bool UseBlending
        {
            get => _useBlending;
            set
            {
                _useBlending = value;
                BlendingStateChanged(value);
            }
        }

        private void BlendingStateChanged(bool value)
        {
        }

        private void EnabledStateChanged(bool value)
        {
            
        }

        public ETrailType TrailType { get; private set; }

        public void SetTexture(Bitmap texture)
        {
            _trailTexture = texture;
        }

        public void SetTrailType(ETrailType type)
        {
            TrailType = type;
        }

        public void Update(float deltaTime)
        {
            if (WindowsApi.GetCursorPosition(out _cursorPoint))
            {
                RenderTrailElement(_cursorPoint);
            }
        }

        private void RenderTrailElement(Point screenPos)
        {
        }
    }
}