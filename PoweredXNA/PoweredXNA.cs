namespace PoweredXNA
{
    public static class Library
    {
        public static void Start(GameState instance, OptionsPreset preset = null)
        {
            Rand.Init();
            if (preset != null)
                Options.Preset = preset;
            else
                Options.Preset = new OptionsPreset();
            GameState.PushInstance(instance);
#if WINDOWS || XBOX
            Game game = new Game();
            game.Run();
#else
            throw new System.NotImplementedException();
#endif
        }
    }
}
