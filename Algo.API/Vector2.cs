using System;

namespace Algo.API
{
    public struct Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2 Normalize()
        {
            float length = (float)Math.Sqrt(X * X + Y * Y);
            if (length == 0) return new Vector2(0, 0);
            return new Vector2(X / length, Y / length);
        }
    }
}
