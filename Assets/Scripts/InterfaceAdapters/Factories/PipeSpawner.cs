using FloppyBird.InterfaceAdapters.GameObjects;
using UnityEngine;

namespace FloppyBird.InterfaceAdapters.Factories
{
    public class PipeSpawner : IPipeSpawner
    {
        private readonly Object _pipePrefab;
        private readonly ISpawner _spawner;

        public PipeSpawner(Object pipePrefab, ISpawner spawner)
        {
            _pipePrefab = pipePrefab;
            _spawner = spawner;
        }

        public void SpawnPipe(float positionX, float positionY, float heightOffset)
        {
            var lowestPoint = positionY - heightOffset;
            var highestPoint = positionY + heightOffset;

            var height = Random.Range(lowestPoint, highestPoint);

            _spawner.Spawn(_pipePrefab, positionX, height);
        }
    }
}
