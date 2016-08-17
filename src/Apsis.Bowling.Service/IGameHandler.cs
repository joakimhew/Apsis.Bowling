namespace Apsis.Bowling.Service
{
    public interface IGameHandler
    {
        IGame Game { get; set; }

        void CalculateFrameScore();
        void CalculateLastFrameScore(int frameIndex);
        void CalculateOpenFrameScore(int frameIndex);
        void CalculateSpareFrameScore(int frameIndex);
        void CalculateStrikeFrameScore(int frameIndex, bool isPenultimate);
    }
}