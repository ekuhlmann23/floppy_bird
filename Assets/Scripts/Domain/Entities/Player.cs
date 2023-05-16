using System.Collections.Generic;
using System.Linq;

namespace FloppyBird.Domain.Entities
{
    public class Player
    {
        // Data (including relations to other domain objects)
        // Usamos una lista privada por encapsulamiento.
        private List<HighScoreEntity> _highScores = new();

        public string Name { get; private set; }
        public IEnumerable<HighScoreEntity> HighScores => _highScores.AsReadOnly();
        // Equivalent to:
        // public IEnumerable<HighScoreEntity> HighScores { return _highScores.AsReadOnly(); }

        public Player(string name)
        {
            Name = name;
        }

        // Behavior (qué puede hacer esta entidad / reglas de negocio)
        public void AddScore(HighScoreEntity score)
        {
            _highScores.Add(score);
        }
    }
}
