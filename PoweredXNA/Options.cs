using Microsoft.Xna.Framework;
using PoweredXNA.Display;
using PoweredXNA.Extend;

namespace PoweredXNA
{
    public class OptionsPreset
    {
        public Resolution ScreenResolution;
        public bool Fullscreen;
        public bool LoadAllResourcesAtStart;
        public string WindowTitle;
        public bool AllowScreenResizing;

        public OptionsPreset()
        {
            ScreenResolution = null;
            Fullscreen = false;
            LoadAllResourcesAtStart = true;
            WindowTitle = "PoweredXNA Project";
            AllowScreenResizing = false;
        }
    }

    public static class Options
    {
        internal static OptionsPreset Preset;

        private static int _brightness;
        public static int Brightness
        {
            get { return BrightnessLevel.Get(); }
            set { BrightnessLevel.Set(value); }
        }

        public static Resolution Screen
        {
            get { return new Resolution(Globals.GraphicsDeviceManager.PreferredBackBufferWidth, Globals.GraphicsDeviceManager.PreferredBackBufferHeight); }
            set
            {
                Globals.GraphicsDeviceManager.PreferredBackBufferWidth = value.Width;
                Globals.GraphicsDeviceManager.PreferredBackBufferHeight = value.Height;
                Globals.GraphicsDeviceManager.ApplyChanges();
            }
        }
        public static bool FullScreen
        {
            get { return Globals.GraphicsDeviceManager.IsFullScreen; }
            set
            {
                Globals.GraphicsDeviceManager.IsFullScreen = value;
                Globals.GraphicsDeviceManager.ApplyChanges();
            }
        }

        public static string ImagesFolder = "images";
        public static string MusicsFolder = "musics";
        public static string SpriteFontsFolder = "spritefonts";
        public static string ContentRootDirectory = "Content";
    }
}
