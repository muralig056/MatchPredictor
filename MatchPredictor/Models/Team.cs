using System.Collections.Generic;
using System.Linq;

namespace MatchPredictor.Models
{
    public class Team
    {
        private List<Player> _players;
        private string _teamName;
        private List<Player> _currentPlayers;
        private int _ballsPlayed = 0;
        private int _wickets = 0;
        private int _score = 0;
        public Team(List<Player> players, string teamName)
        {
            _players = players;
            _teamName = teamName;
            if (_players != null && _players.Count >= 2)
            {
                _players[0].IsPlaying = true;
                _players[1].IsPlaying = true;
                _currentPlayers = new List<Player> { _players[0], _players[1] };
            }
        }
        #region Properties
        public List<Player> Players => _players;
        public string Name => _teamName;
        public int Score => _score;
        public List<Player> CurrentPlayers => _currentPlayers;
        #endregion
        #region Method members
        public int GetBallResult()
        {
            var runs = _currentPlayers[0].GetBallResult();
            UpdateRuns(runs);
            UpdatePlayers(runs);
            return runs;
        }
        public void RotateStrike()
        {
            var tempPlayer = _currentPlayers[0];
            _currentPlayers[0] = _currentPlayers[1];
            _currentPlayers[1] = tempPlayer;
        }
        private void UpdateRuns(int runs)
        {
            _ballsPlayed++;
            if (runs == -1)
                _wickets++;
            else
                _score += runs;
        }

        public void UpdatePlayers(int runs)
        {
            var players = _currentPlayers;
            if (runs == -1)
            {
                RemovePlayer(_players[0].PlayerId);
            }
            else if (runs % 2 != 0)
            {
                RotateStrike();
            }
        }

        private Player GetNewPlayer(List<Player> players)
        {
            var nextPlayer = players.Any(p => !p.IsOut && !p.IsPlaying) ? players.First(p => !p.IsOut && !p.IsPlaying) : players[0];
            nextPlayer.IsPlaying = true;
            return nextPlayer;
        }
        private void RemovePlayer(int playerId)
        {
            _players[playerId - 1].IsOut = true;
            _players[playerId - 1].IsPlaying = false;

            _currentPlayers[0] = GetNewPlayer(_players);
        }
        #endregion
    }
}
