using System.Collections;
using FloppyBird.Drivers.GameObjects;
using FloppyBird.Factories;
using UnityEngine;

namespace FloppyBird.Presenters
{
    public class PipeSpawnerPresenter : MonoBehaviour, ISpawner
    {
        public Object pipePrefab;
        public float spawnRateInSeconds = 3;
        public float heightOffset;

        private IPipeSpawner _pipeSpawner;

        // Start is called before the first frame update
        private void Start()
        {
            _pipeSpawner = new PipeSpawner(pipePrefab, spawner: this);
            StartCoroutine(SpawnCoroutine());
        }

        // Update is called once per frame

        IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                var position = transform.position;
                _pipeSpawner.SpawnPipe(position.x, position.y, heightOffset);
                yield return new WaitForSeconds(spawnRateInSeconds);
            }
        }

        public void Spawn(Object obj, float x, float y)
        {
            Instantiate(obj, new Vector3(x, y), transform.rotation);
        }
    }
}
