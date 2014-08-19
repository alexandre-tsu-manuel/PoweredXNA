using System;

namespace PoweredXNA
{
    public class Rand
    {
        private Random _random;
        private static Rand _rand;

        public Rand() { _random = new Random(); }
        public Rand(int seed) { _random = new Random(seed); }

        public bool NextBool() { return _random.Next(2) == 0; }
        public int NextInt(int max) { return _random.Next(max); }
        public int NextInt(int min, int max) { return _random.Next(min, max); }
        
        public double NextDouble(double max)
        {
            int intMax = (int)max;
            return _random.Next(intMax) + _random.NextDouble() * (max - intMax);
        }

        public double NextDouble(double min, double max)
        {
            double delta = max - min;
            int intDelta = (int)delta;
            
            return _random.Next(intDelta) + _random.NextDouble() * (delta - intDelta) + min;
        }

        public static void Init() { _rand = new Rand(); }
        public static void Init(int seed) { _rand = new Rand(seed); }

        public static bool Bool() { return _rand.NextBool(); }
        public static int Int(int max) { return _rand.NextInt(max); }
        public static int Int(int min, int max) { return _rand.NextInt(min, max); }
        public static double Double(double max) { return _rand.NextDouble(max); }
        public static double Double(double min, double max) { return _rand.NextDouble(min, max); }
    }
}
