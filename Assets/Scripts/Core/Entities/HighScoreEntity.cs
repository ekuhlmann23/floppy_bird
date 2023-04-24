namespace FloppyBird.Core.Entities
{
    public class HighScoreEntity
    {
        public int Score { get; private set; }
        public string Player { get; private set; }

        public HighScoreEntity(int score, string player)
        {
            Score = score;
            Player = player;
        }
    }
}