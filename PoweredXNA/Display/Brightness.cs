using Microsoft.Xna.Framework;
using PoweredXNA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoweredXNA.Display
{
    internal static class BrightnessLevel
    {
        private static Entity _layer;
        private static int _level;
        internal static void Set(int brightness)
        {
            brightness = (int) MathHelper.Clamp(brightness, -100, 100);
        }

        internal static int Get() { return _level; }

        internal static void ApplyOnScreen(GameTime gameTime)
        {
            if (_layer != null)
                _layer.Draw(gameTime);
        }
    }
}
