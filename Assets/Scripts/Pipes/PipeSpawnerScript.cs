using System.Collections;
using UnityEngine;

namespace FloppyBird.Pipes
{
    public class PipeSpawnerScript : MonoBehaviour
    {
        public GameObject pipePrefab;
        public float spawnRateInSeconds = 3;
        public float heightOffset;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        // Update is called once per frame

        IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                SpawnPipe();
                yield return new WaitForSeconds(spawnRateInSeconds);
            }
        }

        private void SpawnPipe()
        {
            float lowestHeight = transform.position.y - heightOffset;
            float highestHeight = transform.position.y + heightOffset;

            float height = Random.Range(lowestHeight, highestHeight);

            Vector3 spawnPosition = new(transform.position.x, height, 0);

            Instantiate(pipePrefab, spawnPosition, transform.rotation);
        }
    }
}
