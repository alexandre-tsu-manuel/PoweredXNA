namespace PoweredXNA.Extend
{
    public class Resolution
    {
        public int Width;
        public int Height;
        public Resolution(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Apply()
        {
            Options.Screen = this;
        }
    }
}
