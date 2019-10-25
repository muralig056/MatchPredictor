using MatchPredictor.Helpers;

namespace MatchPredictor.Models
{
    public class Player
    {
        #region Properties
        private int[] _cummulative;
        private int[] _scoringProbability;
        private int _id;
        private string _name;
        private int _score;
        private int _currentRuns;
        private int _ballsPlayed;
        public int PlayerId => _id;
        public string Name => _name;
        public int[] ScoringProbability => _scoringProbability;
        public int[] Cummulative => _cummulative;
        public int Score => _score;
        public int CurrentRuns => _currentRuns;
        public int BallsPlayed => _ballsPlayed;
        public bool IsOut { get; set; }
        public bool IsPlaying { get; set; }
        public int[] RunPossibilities => new int[] { 0, 1, 2, 3, 4, 5, 6, -1 };
        #endregion
        public Player(int id, string name, int[] probability)
        {
            _id = id;
            _name = name;
            _scoringProbability = probability;
            _cummulative = new int[8] { _scoringProbability[0], 0, 0, 0, 0, 0, 0, 0 };
            //Weighted random number generator using the sum of all weights
            for (var i = 1; i < _scoringProbability.Length; i++)
            {
                _cummulative[i] = _scoringProbability[i] + _cummulative[i - 1];
            }
        }
        #region Member methods
        public int GetBallResult()
        {
            var runs = GetRuns();
            UpdateRuns(runs);
            return runs;
        }
        private int GetRuns()
        {
            var random =  RandomNumber.Random(0, 100);
            return GetWeightedRandomNumber(random);
        }

        public int GetWeightedRandomNumber(int random)
        {
            var cummulative = _cummulative;
            int index = 0;
            for (int i = cummulative.Length - 1; i > 0; i--)
            {
                index = i;
                if (random < cummulative[i] && random >= cummulative[i - 1])
                    break;
            }
            return RunPossibilities[index]; ;
        }
        private void UpdateRuns(int runs)
        {
            if (runs == -1)
            {
                IsOut = true;
                IsPlaying = false;
            }
            else
            {
                _score += runs;
            }
            _currentRuns = runs;
            _ballsPlayed++;
        }
        #endregion
    }
}
