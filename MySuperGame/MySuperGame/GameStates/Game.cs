using Microsoft.Xna.Framework;
using PoweredXNA;
using PoweredXNA.Entities;

namespace MySuperGame.GameStates
{
    class Game : GameState
    {
        private Entity loul;
        public override void Initialize(GameTime gameTime)
        {
            loul = new Entity(new Pos(), new Pos(16, 9).ToVector2(), 0.01f);
            loul.LoadContent("loul");
            loul.Rotation = 0f;
        }

        public override void Update(GameTime gameTime)
        {
            loul.Rotation += 0.01f;
            if (loul.IsClicked())
                loul.Pos = new Pos();
        }
    }
}
