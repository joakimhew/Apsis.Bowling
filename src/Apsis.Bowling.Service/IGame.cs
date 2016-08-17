namespace Apsis.Bowling.Service
{
    public interface IGame
    {
        Frame this[int index] { get; set; }

        Frame[] Frames { get; set; }
        int NumberOfRounds { get; set; }
        int Score { get; }
    }
}