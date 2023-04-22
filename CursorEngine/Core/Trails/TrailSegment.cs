using System.Drawing;

namespace CursorEngine.Core.Trails
{
    public class TrailSegment : IDrawable
    {
        //replace fixedDelta with something other? (Should always last the same time, even if low performance).
        public TrailSegment(/*IntPtr ptr,*/Point pos, double lifetime)
        {
            InitialLifetime = lifetime;
            Lifetime = lifetime;
            //ResourcePointer = ptr;
            Position = pos;
        }
        
        public Point Position;
        
        public double InitialLifetime { get; private set; }
        public double Lifetime { get; set; }

        //public IntPtr ResourcePointer;
    }
}