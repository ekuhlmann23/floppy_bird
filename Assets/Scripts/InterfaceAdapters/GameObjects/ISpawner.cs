using UnityEngine;

namespace FloppyBird.InterfaceAdapters.GameObjects
{
    public interface ISpawner
    {
        public void Spawn(Object obj, float x, float y);
    }
}
