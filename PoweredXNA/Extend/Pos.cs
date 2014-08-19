using Microsoft.Xna.Framework;

namespace PoweredXNA
{
    public class Pos
    {
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        private float _x;

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        private float _y;

        public int I
        {
            get { return (int)_x; }
            set { _x = value; }
        }

        public int J
        {
            get { return (int)_y; }
            set { _y = value; }
        }

        public Pos(double x, double y)
        {
            X = (float)x;
            Y = (float)y;
        }

        public Pos(double p)
        {
            X = Y = (float)p;
        }

        public Pos(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Pos(float p)
        {
            X = Y = p;
        }

        public Pos()
        {
            X = Y = 0;
        }

        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        public static Pos FromVector2(Vector2 v)
        {
            return new Pos(v.X, v.Y);
        }

        public static Pos operator +(Pos p1, Pos p2) { return new Pos(p1.X + p2.X, p1.Y + p2.Y); }
        public static Pos operator +(Pos p, Vector2 v) { return new Pos(p.X + v.X, p.Y + v.Y); }
        public static Pos operator +(Vector2 v, Pos p) { return p + v; }
        public static Pos operator -(Pos p1, Pos p2) { return new Pos(p1.X - p2.X, p1.Y - p2.Y); }
        public static Pos operator -(Pos p, Vector2 v) { return new Pos(p.X - v.X, p.Y - v.Y); }
        public static Pos operator -(Vector2 v, Pos p) { return p - v; }
        public static Pos operator *(Pos p, float x) { return new Pos(p.X * x, p.Y * x); }
        public static Pos operator *(float x, Pos p) { return p * x; }
        public static Pos operator /(Pos p, float x) { return new Pos(p.X / x, p.Y / x); }
        public static Pos operator /(float x, Pos p) { return x * p; }
        public static Pos operator %(Pos p, float x) { return new Pos(p.X % x, p.Y % x); }
        public static Pos operator %(float x, Pos p) { return p % x; }
        public static Pos operator *(Pos p, double x) { return new Pos(p.X * x, p.Y * x); }
        public static Pos operator *(double x, Pos p) { return p * x; }
        public static Pos operator /(Pos p, double x) { return new Pos(p.X / x, p.Y / x); }
        public static Pos operator /(double x, Pos p) { return x * p; }
        public static Pos operator %(Pos p, double x) { return new Pos(p.X % x, p.Y % x); }
        public static Pos operator %(double x, Pos p) { return p % x; }
    }
}
