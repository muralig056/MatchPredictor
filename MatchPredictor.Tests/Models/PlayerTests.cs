using MatchPredictor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MatchPredictor.Tests.Models
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Player_ForGivenProbability_CalculatesCummulativeSum()
        {
            var probability = new int[] { 10, 20, 20, 5, 15, 5, 10, 15 };
            var target = new Player(1, "TestPLayer", probability);

            Assert.IsNotNull(target.Cummulative);
            Assert.AreEqual(100, target.Cummulative.Max());
            Assert.AreEqual(probability.Length, target.Cummulative.Length);
        }
        [TestMethod]
        public void GetBallResult_ForThePlayer_ReturnsUpdatesBallsPlayedCorrectly()
        {
            var target = new Player(1, "TestPLayer", new int[] { 10, 20, 20, 5, 15, 5, 10, 15 });

            var runs = target.GetBallResult();
            Assert.AreEqual(1, target.BallsPlayed);
        }

        [TestMethod]
        public void GetWeightedRandomNumber_GivenRandomNumber_ReturnsRunsBasedOnProbability()
        {
            var probability = new int[] { 10, 20, 20, 5, 15, 5, 10, 15 };
            var target = new Player(1, "TestPLayer", probability);

            int runs = target.GetWeightedRandomNumber(60);

            Assert.AreEqual(4, runs);
        }

        [TestMethod]
        public void GetBallResult_100Balls_PlayerScoreEqualsTotalScore()
        {
            List<int> runsFor100Balls = new List<int>();
            var player = new Player(1, "Test player", new int[] { 5, 30, 25, 10, 15, 1, 9, 5 });
            for (var i = 0; i < 100; i++)
            {
                runsFor100Balls.Add(player.GetBallResult());
            }

            var runsPossibilities = player.RunPossibilities;

            var runsProbability = new List<int>();
            for (var i = 0; i < runsPossibilities.Length; i++)
            {
                var sampleDistribution = GetSampleDistribution(runsFor100Balls, runsPossibilities[i]);
                runsProbability.Add(sampleDistribution);
            }

            int totalRuns = 0;
            for (var i = 0; i < runsFor100Balls.Count; i++)
                totalRuns += runsFor100Balls[i] != -1 ? runsFor100Balls[i] : 0;
            Assert.AreEqual(player.Score, totalRuns);
        }

        private int GetSampleDistribution(List<int> runsFor100Balls, int probableRun)
        {
            var noOfOccurences = 0;
            for (var i = 0; i < runsFor100Balls.Count; i++)
            {
                if (runsFor100Balls[i] == probableRun)
                    noOfOccurences++;
            }
            return noOfOccurences;
        }
    }
}
