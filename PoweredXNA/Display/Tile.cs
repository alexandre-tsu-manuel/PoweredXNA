using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PoweredXNA.Backend;
using PoweredXNA.Extend;

namespace PoweredXNA.Display
{
    internal static class Tile
    {
        /// <summary>
        /// Dessine une tile
        /// </summary>
        /// <param name="path">Chemin de l'image à afficher</param>
        /// <param name="pos">Position à laquelle dessiner la tile</param>
        /// <param name="rotation">Rotation à appliquer à la Tile en radians</param>
        /// <param name="scale">Zoom à effectuer sur la Tile. 1 Par défaut.</param>
        public static void Draw(string path, Rectangle pos, float rotation = 0, float scale = 1, float opacity = 1, SpriteEffects flip = SpriteEffects.None)
        {
            if (path != null && path != "")
                if (rotation == 0)
                    Globals.SpriteBatch.Draw
                        (
                            Resources.Image(path),
                            new Vector2(pos.X, pos.Y),
                            null,
                            Color.White * opacity,
                            0,
                            Vector2.Zero,
                            scale,
                            flip,
                            0
                        );
                else
                    Globals.SpriteBatch.Draw
                        (
                            Resources.Image(path),
                            new Vector2(pos.Center.X, pos.Center.Y),
                            null,
                            Color.White * opacity,
                            -rotation,
                            new Vector2(pos.Width / 2, pos.Height / 2),
                            scale,
                            flip,
                            0
                        );
        }
    }
}
