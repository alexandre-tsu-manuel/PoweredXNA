using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PoweredXNA;
using PoweredXNA.Entities;
using PoweredXNA.GameStates;

namespace MySuperGame.GameStates
{
    class Game : GameState
    {
        //private Entity play, quit;
        private Entity min, hours;
        public override void Initialize(GameTime gameTime)
        {
            /*Cursor.SetCursor("cursors", "1", "2");
            Entity bg = new Entity(); bg.LoadContent("bg");

            play = new Entity(new Pos(90, 200));
            play.LoadContent("void");
            play.Rect.Height = 50;
            play.Rect.Width = 115;

            quit = new Entity(new Pos(90, 300));
            quit.LoadContent("void");
            quit.Rect.Height = 50;
            quit.Rect.Width = 155;*/

            min = new Entity(new Pos(934, 142));
            min.LoadContent("minutes");
            min.RotationSpeed = -MathHelper.Pi / 1800;
            min.Rotation = -MathHelper.Pi / 30 * 35;

            hours = new Entity(new Pos(934, 251));
            hours.LoadContent("hours");
            hours.RotationSpeed = min.RotationSpeed / 60;
            hours.Rotation = -MathHelper.Pi / 6 * (5 + 35/60);
        }

        public override void Update(GameTime gameTime)
        {
            if (Events.IsPushed(Keys.Escape))
                this.State = State.Exit;
            /*if (quit.IsClicked())
                this.State = State.Exit;*/
        }

        public override void Draw(GameTime gameTime)
        {
            /*PoweredXNA.old.Text.Write("menu", "Jouer", new Pos(100, 200).ToVector2(), Color.White);
            PoweredXNA.old.Text.Write("menu", "Quitter", new Pos(100, 300).ToVector2(), Color.White);*/
        }
    }
}
