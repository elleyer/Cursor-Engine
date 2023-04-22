using System.Collections.Generic;
using System.Drawing;

namespace CursorEngine.Core.Trails
{
    public class TrailSystem : IUpdatable, IDrawableProvider<TrailSegment>
    {
        public List<TrailSegment> GetDrawables() => _trailParticles;

        private int _totalDrawn;

        public bool Enabled { get; set; }

        private Point _cursorPoint;
        private Bitmap sourceBitmap;

        //private Bitmap _trailTexture;
        //private Color _trailColor;

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

        public TrailSystem()
        {
            _trailParticles = new List<TrailSegment>();
        }

        private List<TrailSegment> _trailParticles;

        public ETrailType TrailType { get; private set; }

        public void SetTexture(Bitmap texture)
        {
            //_trailTexture = texture;
        }

        public void SetTrailType(ETrailType type)
        {
            TrailType = type;
        }

        public void Update(double deltaTime)
        {
            if (!WindowsApi.GetCursorPosition(out _cursorPoint))
                return;

            AddParticle(_cursorPoint);
            UpdateParticles(_trailParticles, deltaTime);
        }

        private void AddParticle(Point screenPos)
        {
            //todo: actual handle and lifetime from config.
            var particle = new TrailSegment(screenPos, 125);

            _trailParticles.Add(particle);
            _totalDrawn++;
        }

        private void UpdateParticles(List<TrailSegment> particles, double deltaTime)
        {
            for (var i = particles.Count - 1; i >= 0; i--)
            {
                particles[i].Lifetime -= deltaTime;
                if (!(particles[i].Lifetime < 0))
                    continue;
                
                particles.RemoveAt(i);
            }
        }
    }
}