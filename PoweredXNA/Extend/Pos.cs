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

        /// <summary>
        /// Permet de décaler la position de l'objet pour donner une impression de rotation depuis le centre de l'entity plutôt que depuis le coin supérieur gauche
        /// </summary>
        /// <param name="rotation">Attribut rotation de l'entity</param>
        /// <returns></returns>
        public Pos ApplyRotationShift(float rotation)
        {
            return this;
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle(I, J, 0, 0);
        }

        public Rectangle ToRectangle(int w, int h)
        {
            return new Rectangle(I, J, w, h);
        }

        public static Pos FromRectangle(Rectangle r)
        {
            return new Pos(r.X, r.Y);
        }

        public Point ToPoint()
        {
            return new Point(this.I, this.J);
        }

        public static Pos FromPoint(Point p)
        {
            return new Pos(p.X, p.Y);
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
        public static Pos operator +(Pos p1, Point p2) { return new Pos(p1.X + p2.X, p1.Y + p2.Y); }
        public static Pos operator +(Point p2, Pos p1) { return p1 + p2; }
        public static Rectangle operator +(Pos p, Rectangle r) { return new Rectangle(p.I + r.X, p.J + r.Y, r.Width, r.Height); }
        public static Rectangle operator +(Rectangle r, Pos p) { return p + r; }
        public static Pos operator -(Pos p1, Pos p2) { return new Pos(p1.X - p2.X, p1.Y - p2.Y); }
        public static Pos operator -(Pos p, Vector2 v) { return new Pos(p.X - v.X, p.Y - v.Y); }
        public static Pos operator -(Vector2 v, Pos p) { return p - v; }
        public static Pos operator -(Pos p1, Point p2) { return new Pos(p1.X - p2.X, p1.Y - p2.Y); }
        public static Pos operator -(Point p2, Pos p1) { return p1 - p2; }
        public static Rectangle operator -(Pos p, Rectangle r) { return new Rectangle(p.I - r.X, p.J - r.Y, r.Width, r.Height); }
        public static Rectangle operator -(Rectangle r, Pos p) { return p - r; }
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
