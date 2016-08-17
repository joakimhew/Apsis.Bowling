using System;

namespace Apsis.Bowling.Service
{
    public class GameHandler : IGameHandler
    {

        #region Fields

        private int _currentScore;
        private const int StrikeBonus = 10;

        #endregion


        #region Constructors

        public GameHandler(IGame game)
        {
            Game = game;
        }

        #endregion 

        #region Properties

        public IGame Game { get; set; }

        #endregion

        #region Methods

        public void CalculateFrameScore()
        {
            _currentScore = 0;

            for (int i = 0; i < Game.Frames.Length; i++)
            {
                var frame = Game[i];
                var isLastFrame = i == Game.NumberOfRounds - 1;
                var isPenultimate = i == (Game.Frames.Length - 2);

                if (frame == null)
                    continue;

                //todo: Check if last frame is valid
                if (isLastFrame)
                {
                    CalculateLastFrameScore(i);
                    continue;
                }

                if(!IsValidFrame(frame.First, frame.Second))
                    continue;;

                switch (Game[i].FrameType)
                {
                    case FrameType.Open:
                        CalculateOpenFrameScore(i);
                        break;

                    case FrameType.Spare:
                        CalculateSpareFrameScore(i);
                        break;

                    case FrameType.Strike:
                        CalculateStrikeFrameScore(i, isPenultimate);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _currentScore = frame.FrameScore;

            }

        }

        private bool IsValidFrame(int firstBall, int secondBall)
        {
            return firstBall + secondBall <= 10;
        }

        public void CalculateStrikeFrameScore(int frameIndex, bool isPenultimate)
        {
            var f1 = Game[frameIndex];
            var f2 = Game[frameIndex + 1];
            var f3 = Game[frameIndex + 2];

            if (f2 == null)
                return;

            var isNextFrameStrike = f2.FrameType == FrameType.Strike;

            if (isPenultimate)
            {
                f1.FrameScore = _currentScore;
                f1.FrameScore += StrikeBonus + (f2.First + f2.Second);
            }

            if (isNextFrameStrike)
            {
                if (f3 == null)
                    return;

                f1.FrameScore = _currentScore;
                f1.FrameScore += StrikeBonus + (f2.First + f3.First);
            }

            else
            {
                f1.FrameScore = _currentScore;
                f1.FrameScore += StrikeBonus + (f2.First + f2.Second);
            }
        }

        public void CalculateSpareFrameScore(int frameIndex)
        {
            var f1 = Game[frameIndex];
            var f2 = Game[frameIndex + 1];

            if (f1 == null || f2 == null)
                return;

            f1.FrameScore = _currentScore;
            f1.FrameScore += (f1.First + f1.Second) + f2.First;
        }

        public void CalculateOpenFrameScore(int frameIndex)
        {
            var f1 = Game[frameIndex];

            if (f1 == null)
                return;

            f1.FrameScore = _currentScore;
            f1.FrameScore += (f1.First + f1.Second);
        }

        public void CalculateLastFrameScore(int frameIndex)
        {
            var f1 = Game[frameIndex];

            if (f1 == null)
                return;

            f1.FrameScore = _currentScore;
            f1.FrameScore += (f1.First + f1.Second + f1.Third);
        }

        #endregion
    }
}