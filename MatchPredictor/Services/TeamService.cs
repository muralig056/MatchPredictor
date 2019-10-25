using MatchPredictor.Models;
using System.Collections.Generic;

namespace MatchPredictor.Services
{
    public class TeamService
    {
        public List<Team> SetupTeams()
        {
            var teams = new List<Team>();
            teams.Add(new Team(CreatePlayers(), "Remus"));
            teams.Add(new Team(new List<Player>(), "Niburu"));
            return teams;
        }

        private List<Player> CreatePlayers()
        {
            var players = new List<Player>();
            players.Add(new Player(1, "Pravin", new int[] { 5, 30, 25, 10, 15, 1, 9, 5 }));
            players.Add(new Player(2, "Irfan", new int[] { 10, 40, 20, 5, 10, 1, 4, 10 }));
            players.Add(new Player(3, "Jalindar", new int[] { 20, 30, 15, 5, 5, 1, 4, 20 }));
            players.Add(new Player(4, "Vaishali", new int[] { 30, 25, 5, 0, 5, 1, 4, 30 }));

            return players;
        }
    }
}
