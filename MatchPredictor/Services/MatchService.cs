using MatchPredictor.Models;
using MatchPredictor.Simulator;
using System.Collections.Generic;

namespace MatchPredictor.Services
{
    public static class MatchService
    {
        public static void InitiateMatch(List<Team> teams, int requiredScore, int overs)
        {
            var matchStat = new MatchStats(teams, requiredScore, overs * 6);
            var matchSimulator = new MatchSimulator(matchStat);
            matchSimulator.StartMatch();
        }
    }
}
