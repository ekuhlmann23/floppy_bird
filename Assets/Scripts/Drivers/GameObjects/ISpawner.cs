using UnityEngine;

namespace FloppyBird.Drivers.GameObjects
{
    public interface ISpawner
    {
        public void Spawn(Object obj, float x, float y);
    }
}
