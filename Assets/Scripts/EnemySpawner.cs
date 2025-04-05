using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject theEnemy ;
        public float xPos;
        public float zPos;
        public int EnemyCount;

        private void Start()
        {
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            while (EnemyCount < 20)
            {
                xPos = Random.Range(0, 0);
                zPos = Random.Range(7, 18);
                Instantiate(theEnemy, new Vector3 (xPos, -4, zPos), Quaternion.identity);
                yield return new WaitForSeconds(1);
                EnemyCount += 1;
            }
        }
    }
}