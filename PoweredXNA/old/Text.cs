using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PoweredXNA.Backend;

namespace PoweredXNA.old
{
    public static class Text
    {
        public static void Write(string path, string text, Vector2 pos, Color color, float scale = 1)
        {
            Globals.SpriteBatch.DrawString(Resources.SpriteFont(path), text, pos, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
