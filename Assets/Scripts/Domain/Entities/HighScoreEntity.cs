namespace FloppyBird.Domain.Entities
{
    public class HighScoreEntity
    {
        public int Id { get; private set; }
        public int Score { get; private set; }
        public string PlayerName { get; private set; }

        public HighScoreEntity(int id, int score, string playerName)
        {
            Id = id;
            Score = score;
            PlayerName = playerName;
        }
    }
}
