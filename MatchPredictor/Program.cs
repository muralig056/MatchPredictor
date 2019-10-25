using MatchPredictor.Services;
using System;

namespace MatchPredictor
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new TeamService().SetupTeams();
            MatchService.InitiateMatch(teams, 40, 4);

            Console.ReadLine();
        }
    }
}
