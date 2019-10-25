using System;
using System.Threading;

namespace MatchPredictor.Helpers
{
    public static class RandomNumber
    {
        public static int Random(int min, int max)
        {
            Thread.Sleep(1);
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
