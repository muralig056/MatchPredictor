using MatchPredictor.Models;
using System.Collections.Generic;

namespace MatchPredictor.Simulator
{
    public class MatchStats
    {
        #region Properties
        private Team _team;
        private Team _battingTeam;
        private Team _bowlingTeam;
        private int _requiredRuns;
        private int _totalBalls;
        private int _target;
        private int _balls;
        private int _score;
        private int _wickets;
        private Player _currentPlayer;
        private int _currentRuns;

        public Team Team { get { return _team; } set { value = _team; } }
        public Team BattingTeam { get { return _battingTeam; } set { value = _battingTeam; } }
        public Team BowlingTeam { get { return _bowlingTeam; } set { value = _bowlingTeam; } }
        public int RequiredRuns { get { return _requiredRuns; } set { value = _requiredRuns; } }
        public int TotalBalls { get { return _totalBalls; } set { value = _totalBalls; } }
        public int Target { get { return _target; } set { value = _target; } }
        public int Balls { get { return _balls; } set { value = _balls; } }
        public int Score { get { return _score; } set { value = _score; } }
        public int Wickets { get { return _wickets; } set { value = _wickets; } }
        public Player CurrentPlayer { get { return _currentPlayer; } set { value = _currentPlayer; } }
        public int CurrentRuns { get { return _currentRuns; } set { value = _currentRuns; } }
        #endregion
        public MatchStats(List<Team> teams, int target, int totalBalls)
        {
            _team = teams[0];
            _requiredRuns = target;
            _totalBalls = totalBalls;
            _target = target;

            _balls = 0;
            _score = 0;
            _wickets = 0;

            _currentPlayer = null;
            _currentRuns = 0;

            _battingTeam = teams[0];
            _bowlingTeam = teams[1];
        }

        public void UpdateRuns(int currentPlayerId, int runs)
        {
            if (runs == -1)
            {
                _wickets++;
            }
            else
            {
                _score += runs;
                _requiredRuns -= runs;
            }
            _balls++;
            _currentPlayer = _team.Players[currentPlayerId - 1];
            _currentRuns = runs;
            if (_balls % 6 == 0)
            {
                _battingTeam.RotateStrike();
            }
        }
    }
}
