namespace FloppyBird.State
{
    public interface IGameState
    {
        int Score { get; }
        void IncrementScore();
    }
}