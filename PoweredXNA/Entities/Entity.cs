using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PoweredXNA.Backend;
using PoweredXNA.Display;
using System.Diagnostics;

namespace PoweredXNA.Entities
{
    public enum Center { None, All }

    public enum Align
    {
        TopLeft, Top, TopRight,
        Left, Center, Right,
        BottomLeft, Bottom, BottomRight
    }

    public class Entity
    {
        public int ZIndex
        {
            get { return _zIndex; }
            set
            {
                _zIndex = value;
                ZIndexChanged = true;
            }
        }
        private int _zIndex;
        internal bool ZIndexChanged = false;

        /// <summary>
        /// Visibilité de l'entity
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
        private bool _visible;

        /// <summary>
        /// Vecteur vitesse de l'entity
        /// </summary>
        public float Opacity
        {
            get { return _opacity; }
            set { _opacity = MathHelper.Clamp(value, 0, 1); }
        }
        private float _opacity;

        /// <summary>
        /// Position de l'entity
        /// </summary>
        public Pos Pos
        {
            get { return _pos; }
            set
            {
                _pos = value;
                Rect.X = (int)_pos.X;
                Rect.Y = (int)_pos.Y;
            }
        }
        private Pos _pos;

        /// <summary>
        /// Delta de position à l'affichage
        /// </summary>
        public Pos Delta;

        /// <summary>
        /// Vecteur vitesse de l'entity
        /// </summary>
        public Vector2 Movement;

        /// <summary>
        /// Direction de l'entity
        /// Lorsque la direction est modifiée, elle est automatiquement normalisée.
        /// </summary>
        public Vector2 Direction
        {
            get { return Vector2.Normalize(Movement); }
            set { Movement = Vector2.Normalize(value) * this.Speed; }
        }

        /// <summary>
        /// Vitesse de déplacement de l'entity en pixels par seconde
        /// </summary>
        public float Speed
        {
            get { return Movement.Length(); }
            set { Movement = this.Direction * value; }
        }

        /// <summary>
        /// Vitesse de rotation par seconde de l'entity
        /// </summary>
        public float RotationSpeed;

        /// <summary>
        /// Rotation de l'entity au moment du Draw
        /// </summary>
        public float Rotation
        {
            get { return _rotation; }
            set
            {
                _rotation = value;
                while (_rotation > MathHelper.Pi)
                    _rotation -= MathHelper.Pi * 2;
                while (_rotation < MathHelper.Pi)
                    _rotation += MathHelper.Pi * 2;
                double OA = System.Math.Sqrt(Rect.Width * Rect.Width + Rect.Height * Rect.Height) / 2;
                double alpha0 = System.Math.Atan((double)Rect.Height / Rect.Width);
                double alpha = _rotation - alpha0;
                //_rotationDelta.X = (float)((-System.Math.Cos(alpha) + 1) * OA - OA + Rect.Width / 2);
                //_rotationDelta.Y = (float)(System.Math.Sin(alpha) * OA + OA);
            }
        }
        private float _rotation;
        
        private Pos _rotationDelta;

        /// <summary>
        /// Zoom de l'entity au moment du Draw
        /// </summary>
        public float Scale;

        public SpriteEffects Flip;

        /// <summary>
        /// Hitbox de l'entity
        /// </summary>
        public Rectangle Rect;

        /// <summary>
        /// ID de l'image du button normal
        /// </summary>
        public string KeyTextureNormal
        {
            get { return _keyTextureNormal; }
            set { _keyTextureNormal = value; }
        }
        private string _keyTextureNormal;

        /// <summary>
        /// ID de l'image du button survolé
        /// </summary>
        public string KeyTextureOver
        {
            get { return _keyTextureOver == "" ? _keyTextureNormal : _keyTextureOver; }
            set { _keyTextureOver = value; }
        }
        private string _keyTextureOver;

        /// <summary>
        /// ID de l'image du button appuyé
        /// </summary>
        public string KeyTexturePushed
        {
            get { return _keyTexturePushed == "" ? _keyTextureNormal : _keyTexturePushed; }
            set { _keyTexturePushed = value; }
        }
        private string _keyTexturePushed;

        public bool MouseIsOver
        {
            get { return _mouseIsOver; }
        }
        private bool _mouseIsOver;

        public Entity(bool visible = true) { this.Initialize(visible); }
        public Entity(Pos position, bool visible = true) { this.Initialize(position, visible); }
        public Entity(Pos position, Vector2 direction, float speed, bool visible = true) { this.Initialize(position, direction, speed, visible); }
        public Entity(Pos position, Vector2 movement, bool visible = true) { this.Initialize(position, movement, visible); }

        /// <summary>
        /// Initialise les variables de l'entity
        /// </summary>
        public void Initialize(bool visible = true)
        {
            this.Initialize(new Pos(), visible);
        }

        /// <summary>
        /// Initialise les variables de l'entity
        /// <param name="position">Position à laquelle sera placée l'entity</param>
        /// <param name="visible">Définit si l'entity est visible ou non</param>
        /// </summary>
        public void Initialize(Pos position, bool visible = true)
        {
            this.Initialize(position, new Vector2(), 0, visible);
        }

        /// <summary>
        /// Initialise les variables de l'entity
        /// <param name="direction">Direction de l'entity</param>
        /// <param name="speed">Vitesse de l'entity</param>
        /// <param name="visible">Définit si l'entity est visible ou non</param>
        /// </summary>
        public void Initialize(Pos position, Vector2 direction, float speed, bool visible = true)
        {
            this.Initialize(position, direction * speed, visible);
        }

        /// <summary>
        /// Initialise les variables de l'entity
        /// <param name="position">Position à laquelle sera placée l'entity</param>
        /// <param name="movement">Vecteur mouvement de l'entity</param>
        /// <param name="visible">Définit si l'entity est visible ou non</param>
        /// </summary>
        public void Initialize(Pos position, Vector2 movement, bool visible = true)
        {
            Pos = position;
            Movement = movement;
            Visible = visible;
            Delta = new Pos();
            _rotation = 0;
            Scale = 1;
            Opacity = 1;
            GameState.AddEntityOnTop(this);
            _rotationDelta = new Pos();
            _mouseIsOver = false;
        }

        /// <summary>
        /// Charge l'image voulue grâce au ContentManager donné en plaçant son centre sur sa position
        /// </summary>
        /// <param name="keyNormal">Clé de l'image</param>
        /// <param name="center">Permet de centrer l'image par rapport à se position</param>
        public void LoadContent(string key, Center center = Center.None)
        {
            this.LoadContent(key, "", "", center);
        }

        /// <summary>
        /// Charge l'image voulue grâce au ContentManager donné en plaçant son centre sur sa position
        /// </summary>
        /// <param name="folder">Dossier dans lequel se trouvent les trois images</param>
        /// <param name="keyNormal">Clé de l'image</param>
        /// <param name="center">Permet de centrer l'image par rapport à se position</param>
        public void LoadContent(string folder, string key, Center center = Center.None)
        {
            this.LoadContent(folder + "/" + key, "", "", center);
        }

        /// <summary>
        /// Charge l'image voulue grâce au ContentManager donné en plaçant son centre sur sa position
        /// </summary>
        /// <param name="folder">Dossier dans lequel se trouvent les trois images</param>
        /// <param name="keyNormal">Clé de l'image normale</param>
        /// <param name="keyOver">Clé de l'image de l'entité survolée</param>
        /// <param name="keyPushed">Clé de l'image de l'entité appuyée</param>
        /// <param name="center">Permet de centrer l'image par rapport à se position</param>
        public void LoadContent(string folder, string keyNormal, string keyOver, string keyPushed, Center center = Center.None)
        {
            this.LoadContent(folder + "/" + keyNormal, folder + "/" + keyOver, folder + "/" + keyPushed, center);
        }

        /// <summary>
        /// Charge l'image voulue grâce au ContentManager donné en plaçant son centre sur sa position
        /// </summary>
        /// <param name="keyNormal">Clé de l'image normale</param>
        /// <param name="keyOver">Clé de l'image de l'entité survolée</param>
        /// <param name="keyPushed">Clé de l'image de l'entité appuyée</param>
        /// <param name="center">Permet de centrer l'image par rapport à se position</param>
        public void LoadContent(string keyNormal, string keyOver, string keyPushed, Center center = Center.None)
        {
            KeyTextureNormal = keyNormal;
            KeyTextureOver = keyOver;
            KeyTexturePushed = keyPushed;
            Texture2D buff = Resources.Image(KeyTextureNormal);
            Rect = Pos.ToRectangle(buff.Width, buff.Height);
            if (center != Center.None)
                Pos = new Pos
                    (
                        center == Center.All ? Pos.X - Rect.Width / 2 : Pos.X,
                        center == Center.All ? Pos.Y - Rect.Height / 2 : Pos.Y
                    );
        }

        /// <summary>
        /// Met à jour l'entity en fonction de son vecteur position et de son vecteur vitesse
        /// </summary>
        /// <param name="gameTime">Le GameTime associé à la frame</param>
        public void Update(GameTime gameTime)
        {
            if (Movement != Vector2.Zero)
                Pos += Movement * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000;
            if (RotationSpeed != 0)
                Rotation += RotationSpeed * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000;
            _mouseIsOver = this.CalculateMouse();
        }

        public bool IntersectsWith(Entity entity)
        {
            return Rect.Intersects(entity.Rect);
        }

        /// <summary>
        /// Calcule si la souris survole un pixel non transparent de l'entity
        /// </summary>
        private bool CalculateMouse()
        {
            if (Visible)
            {
                // Taking 1 pixel
                // Color[] pixelColours = new Color[1];
                // MyTexture.GetData<Color>(pixelColours, ?, 1); // Voir doc pour le ?
                //if (Rotation == 0)
                    return PositionIsOver(Events.GetMousePos());
                /*else
                {
                    Pos target = Events.GetMousePos();
                    /*  A------B
                        |      |
                        D------C
                    *//*
                    Pos A = Pos;
                    Pos B = new Pos(Pos.I + Rect.Width, Pos.J);
                    Pos C = new Pos(Pos.I + Rect.Width, Pos.J + Rect.Height);
                    Pos D = new Pos(Pos.I, Pos.J + Rect.Height);
                }*/
            }
            return false;
        }

        /// <summary>
        /// Détermine si le pixel visé survole un pixel non transparent de l'Entity
        /// </summary>
        /// <param name="target">Le pixel visé</param>
        private bool PositionIsOver(Pos target)
        {
            return target.I >= Pos.I
                && target.I <= Pos.I + Rect.Width
                && target.J >= Pos.J
                && target.J <= Pos.J + Rect.Height;
        }

        /// <summary>
        /// Indique si l'entity est cliquée
        /// </summary>
        public bool IsClicked()
        {
            return Events.LeftIsReleased() && MouseIsOver;
        }

        /// <summary>
        /// Dessine le sprite en utilisant ses attributs et le spritebatch donné
        /// </summary>
        public void Draw(GameTime gameTime)
        {
            if (this.Visible)
                if (MouseIsOver)
                    if (Events.LeftIsDown())
                        Tile.Draw(KeyTexturePushed, Rect + Delta + _rotationDelta, Rotation, Scale, Opacity, Flip);
                    else
                        Tile.Draw(KeyTextureOver, Rect + Delta + _rotationDelta, Rotation, Scale, Opacity, Flip);
                else
                    Tile.Draw(KeyTextureNormal, Rect + Delta + _rotationDelta, Rotation, Scale, Opacity, Flip);
        }
    }
}

