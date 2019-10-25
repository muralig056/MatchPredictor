using System;

namespace MatchPredictor.Helpers
{
    public static class RandomNumber
    {
        public static int Random(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
