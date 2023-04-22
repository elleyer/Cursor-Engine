using System;
using System.Drawing;

namespace CursorEngine.Core.Trails
{
    public class TrailParticle : IDrawable
    {
        public int ParticleId;
        
        //replace fixedDelta with something other? (Should always last the same time, even if low performance).
        public TrailParticle(IntPtr ptr, Point pos, int lifetime, float fixedDelta)
        {
            Lifetime = lifetime;
            ResourcePointer = ptr;
            Position = pos;
            
            CalculateTickLifeTime(fixedDelta);
        }

        //Lifetime in milliseconds.
        public int Lifetime;

        public Point Position;
        
        public float CurrentInternalTick { get; private set; }
        public float TickLifetime { get; private set; }

        public void IncrementTick()
        {
            CurrentInternalTick++;
        }

        private void CalculateTickLifeTime(float dt)
        {
            TickLifetime = Lifetime / dt;
        }

        public IntPtr ResourcePointer;
    }
}