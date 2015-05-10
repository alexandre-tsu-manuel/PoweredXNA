using PoweredXNA;
using PoweredXNA.Extend;
using MySuperGame.GameStates;

namespace MySuperGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            OptionsPreset preset = new OptionsPreset();
            preset.ScreenResolution = new Resolution(1920, 1080);
            preset.Fullscreen = false;
            preset.LoadAllResourcesAtStart = true;
            preset.WindowTitle = "PoweredXNA Project";
            preset.AllowScreenResizing = true;

            Library.Start(new Game(), preset);
        }
    }
}

