using MatchPredictor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MatchPredictor.Tests.Models
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void Team_MoreThanOrEqualToTwoPlayers_OnlyTwoPlayersWillBePlaying()
        {
            var players = SetupPlayers();
            var target = new Team(players, "Test");

            Assert.IsTrue(target.Players[0].IsPlaying);
            Assert.IsTrue(target.Players[1].IsPlaying);

            Assert.IsFalse(target.Players[2].IsPlaying);
            Assert.IsFalse(target.Players[3].IsPlaying);

            Assert.AreEqual(2, target.CurrentPlayers.Count);
            Assert.AreEqual(players[0].Name, target.CurrentPlayers[0].Name);
        }
        [TestMethod]
        public void Team_LessThanTwoPlayers_CurrentPlayersWillNull()
        {
            var players = new List<Player>();
            players.Add(SetupPlayers().First());
            var target = new Team(players, "Test");

            Assert.IsNull(target.CurrentPlayers);
            Assert.IsFalse(target.Players[0].IsPlaying);
        }

        [TestMethod]
        public void RotateStrike_OnScoringOddRuns_StrikeChanged()
        {
            var players = SetupPlayers();
            var target = new Team(players, "Test");

            var currentPlayersBefore = target.CurrentPlayers[0].Name;
            target.RotateStrike();
            var currentPlayersAfter = target.CurrentPlayers[0].Name;

            Assert.AreNotEqual(currentPlayersBefore, currentPlayersAfter);
        }

        [TestMethod]
        public void UpdatePlayers_WhenOut_PlayerShouldBeRemoved()
        {
            var players = SetupPlayers();
            var target = new Team(players, "Test");

            target.UpdatePlayers(-1);

            Assert.IsTrue(target.Players[0].IsOut);
            Assert.IsTrue(target.Players[2].IsPlaying);
        }
        [TestMethod]
        public void UpdatePlayers_ScoredEvenRuns_StrikeNotChanged()
        {
            var players = SetupPlayers();
            var target = new Team(players, "Test");

            var currentPlayersBefore = target.CurrentPlayers[0].Name;
            target.UpdatePlayers(2);
            var currentPlayersAfter = target.CurrentPlayers[0].Name;

            Assert.AreEqual(currentPlayersBefore, currentPlayersAfter);
        }

        [TestMethod]
        public void UpdatePlayers_ScoredOddRuns_StrikeChanged()
        {
            var players = SetupPlayers();
            var target = new Team(players, "Test");


            var currentPlayersBefore = target.CurrentPlayers[0].Name;
            target.UpdatePlayers(3);
            var currentPlayersAfter = target.CurrentPlayers[0].Name;

            Assert.AreNotEqual(currentPlayersBefore, currentPlayersAfter);
        }

        

        private List<Player> SetupPlayers()
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
