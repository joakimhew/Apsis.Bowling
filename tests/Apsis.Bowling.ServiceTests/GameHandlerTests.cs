using Apsis.Bowling.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Apsis.Bowling.ServiceTests
{
    [TestClass]
    public class GameHandlerTests
    {

        private readonly IGameHandler _gameHandler;

        public GameHandlerTests()
        {
            IGame game = new Game(10);
            _gameHandler = new GameHandler(game);
        }

        [TestMethod]
        public void CanSumBallsInFrame()
        {

            _gameHandler.Game[0] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[1] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[2] = new Frame { First = 3, Second = 2, IsFinished = true };

            _gameHandler.CalculateFrameScore();

            var expected = 43;
            var actual = _gameHandler.Game.Score;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFrameScoresSet()
        {

            _gameHandler.Game[0] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[1] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[2] = new Frame { First = 3, Second = 2, IsFinished = true };

            _gameHandler.CalculateFrameScore();

            var expectedFirstFrameScore = 23;
            var actualFirstFrameScore = _gameHandler.Game[0].FrameScore;

            var expectedSecondaryFrameScore = 38;
            var actualSecondaryFrameScore = _gameHandler.Game[1].FrameScore;

            var expectedThirdFrameScore = 43;
            var actualThirdFrameScore = _gameHandler.Game[2].FrameScore;

            Assert.AreEqual(expectedFirstFrameScore, actualFirstFrameScore);
            Assert.AreEqual(expectedSecondaryFrameScore, actualSecondaryFrameScore);
            Assert.AreEqual(expectedThirdFrameScore, actualThirdFrameScore);
        }

        [TestMethod]
        public void CanScorePerfectGame()
        {
            _gameHandler.Game[0] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[1] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[2] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[3] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[4] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[5] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[6] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[7] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[8] = new Frame { First = 10, IsFinished = true };
            _gameHandler.Game[9] = new Frame { First = 10, Second = 10, Third = 10, IsFinished = true };

            _gameHandler.CalculateFrameScore();

            var expectedScore = 300;
            var actualScore = _gameHandler.Game.Score;

            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void IsNullFrameRetrievedWhenGameIndexerIsUsed()
        {
            var actual = _gameHandler.Game[0];

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void IsFrameCorrectlySetWhenUsingGameIndexer()
        {
            _gameHandler.Game[0] = new Frame {First = 10};

            var expected = 10;
            var actual = _gameHandler.Game[0].First;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFramTypeStrikeWhenFirstBallIsTen()
        {
            _gameHandler.Game[0] = new Frame {First = 10};

            var expectedFrameType = FrameType.Strike;
            var actualFrameType = _gameHandler.Game[0].FrameType;

            Assert.AreEqual(expectedFrameType, actualFrameType);
        }

        [TestMethod]
        public void IsFrameTypeSpareWhenFirstAndSecondBallIsTen()
        {
            _gameHandler.Game[0] = new Frame {First = 5, Second = 5};

            var expectedFrameType = FrameType.Spare;
            var actualFrameType = _gameHandler.Game[0].FrameType;

            Assert.AreEqual(expectedFrameType, actualFrameType);
        }

        [TestMethod]
        public void IsFrameTypeOpenWhenFirstAndSecondBallIsNotTen()
        {
            _gameHandler.Game[0] = new Frame {First = 3, Second = 2};

            var expectedFrameType = FrameType.Open;
            var actualFrameType = _gameHandler.Game[0].FrameType;

            Assert.AreEqual(expectedFrameType, actualFrameType);
        }

        [TestMethod]
        public void IsFramescoreIgnoredWhenScoreIsInvalid()
        {
            _gameHandler.Game[0] = new Frame {First = 9, Second = 9};
            _gameHandler.Game[1] = new Frame {First = 4, Second = 2};

            _gameHandler.CalculateFrameScore();


            var expectedFramescore = 0;
            var actualFramescore = _gameHandler.Game[0].FrameScore;


            Assert.AreEqual(expectedFramescore, actualFramescore);
        }
    }
}