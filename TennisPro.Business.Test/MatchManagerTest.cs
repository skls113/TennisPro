using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisPro.Business.Exceptions;

namespace TennisPro.Business.Test
{
    [TestClass]
    public class MatchManagerTest
    {
        [TestMethod]
        public void TotalSets3CountTest()
        {
            var manager = new MatchManager("Player1", "Player3", 3);
            manager.PlayMatch();
            Assert.IsTrue(manager.Match.Sets.Count <= 3);
        }

        [TestMethod]
        public void TotalSets5CountTest()
        {
            var manager = new MatchManager("Player1", "Player3", 5);
            manager.PlayMatch();
            Assert.IsTrue(manager.Match.Sets.Count <= 5);
        }

        [TestMethod]
        public void WinningSets3PerPlayerCountTest()
        {
            var manager = new MatchManager("Player1", "Player2", 3);
            manager.PlayMatch();
            var match = manager.Match;

            if (match.Winner.Name == "Player1")
            {
                Assert.IsTrue(match.Sets.Count(x => x.Winner.Equals(match.FirstPlayer)) == 2);
                Assert.IsTrue(match.Sets.Count(x => x.Winner.Equals(match.SecondPlayer)) <=1);
            }
            else
            {
                Assert.IsTrue(match.Sets.Count(x => x.Winner.Equals(match.SecondPlayer)) == 2);
                Assert.IsTrue(match.Sets.Count(x => x.Winner.Equals(match.FirstPlayer)) <= 1);
            }
        }

        [TestMethod]
        public void WinningSets5PerPlayerCountTest()
        {
            var manager = new MatchManager("Player1", "Player2", 5);
            manager.PlayMatch();
            var match = manager.Match;

            if (match.Winner.Name == "Player1")
            {
                Assert.IsTrue(match.Sets.Count(x => x.Winner.Equals(match.FirstPlayer)) == 3);
                Assert.IsTrue(match.Sets.Count(x => x.Winner.Equals(match.SecondPlayer)) <= 2);
            }
            else
            {
                Assert.IsTrue(match.Sets.Count(x => x.Winner.Equals(match.SecondPlayer)) == 3);
                Assert.IsTrue(match.Sets.Count(x => x.Winner.Equals(match.FirstPlayer)) <= 2);
            }
        }

        [TestMethod, ExpectedException(typeof(InvalidPlayerNameException))]
        public void FirstPlayerEmptyNameExceptionTest()
        {
            var manager = new MatchManager("", "232", 3);
        }


        [TestMethod, ExpectedException(typeof(InvalidPlayerNameException))]
        public void SecondPlayerEmptyNameExceptionTest()
        {
            var manager = new MatchManager("", "232", 3);
        }

        [TestMethod, ExpectedException(typeof(InvalidPlayerNameException))]
        public void EqualNamesExceptionTest()
        {
            var manager = new MatchManager("Jordi", "JORDI", 3);
        }

        [TestMethod, ExpectedException(typeof(InvalidMaxSetsToPlayException))]
        public void Play4SetsExceptionTest()
        {
            var manager = new MatchManager("Player1", "Player2", 4);
        }
    }
}
