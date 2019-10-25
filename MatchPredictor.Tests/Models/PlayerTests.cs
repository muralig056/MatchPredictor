using MatchPredictor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void UpdatePlayers_ScoredOddRuns_StrikeChangedTest()
        {
            var probability = new int[] { 10, 20, 20, 5, 15, 5, 10, 15 };
            var target = new Player(1, "TestPLayer", probability);


            int runs = target.GetWeightedRandomNumber(60);

            Assert.AreEqual(4, runs);
        }
    }
}
