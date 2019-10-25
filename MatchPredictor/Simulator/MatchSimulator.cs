using System;
using System.Linq;

namespace MatchPredictor.Simulator
{
    public class MatchSimulator
    {
        private MatchStats _matchStat;

        public MatchSimulator(MatchStats matchStats)
        {
            _matchStat = matchStats;
        }

        public void StartMatch()
        {
            var matchStat = _matchStat;
            while (matchStat.RequiredRuns > 0 && matchStat.Balls < matchStat.TotalBalls
                && matchStat.Wickets < matchStat.Team.Players.Count - 1
                && matchStat.Team.Players.Where(a => !a.IsOut).Count() >= 2)
            {
                var playerId = matchStat.Team.CurrentPlayers[0].PlayerId;
                var runs = matchStat.Team.GetBallResult();
                matchStat.UpdateRuns(playerId, runs);
                PrintBallUpdates(matchStat);
            }
            Console.WriteLine();
            EndGame();
        }

        private void PrintBallUpdates(MatchStats matchStat)
        {
            var print = (matchStat.Balls / 6) + "." + (matchStat.Balls % 6) + "  " + matchStat.CurrentPlayer.Name;
            print += (matchStat.CurrentRuns != -1) ? " scores " + matchStat.CurrentRuns + " runs " : " is out!";

            if (matchStat.Balls % 6 == 0)
            {
                var remainingBalls = matchStat.TotalBalls - matchStat.Balls;
                string requiredRuns = matchStat.RequiredRuns != 0 ? matchStat.RequiredRuns.ToString() : " - ";
                if (remainingBalls != 0)
                {
                    print += "\n\n" + remainingBalls / 6 + " overs left. " + requiredRuns + " to win.";
                }
            }

            Console.WriteLine(print);
        }

        private void EndGame()
        {
            var matchStat = _matchStat;

            var winningTeam = _matchStat.RequiredRuns > 0 ? _matchStat.BowlingTeam : _matchStat.BattingTeam;
            var winsBy = (_matchStat.RequiredRuns > 0) ?
                          _matchStat.RequiredRuns + " runs." :
                         (_matchStat.Team.Players.Count - _matchStat.Wickets - 1) + " wickets and " + (_matchStat.TotalBalls - _matchStat.Balls) + " balls remaining";
            var print = winningTeam.Name + " won by " + winsBy;

            Console.WriteLine(print);
            PrintPlayers();
        }

        private void PrintPlayers()
        {
            string print = string.Empty;
            var players = _matchStat.BattingTeam.Players;
            Console.WriteLine();
            Console.WriteLine("----------Score card----------");
            foreach (var player in players)
            {
                if (player.IsOut || player.IsPlaying)
                {
                    print = player.Name + " - " + player.Score;
                    print += player.IsPlaying && !player.IsOut ? " * " : " ";
                    print += "( " + player.BallsPlayed + " balls)";
                    Console.WriteLine(print);
                }
            }
        }
    }
}
