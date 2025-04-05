using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyHealth : MonoBehaviour
    {
        [Header("Health variables")]
        public float enemyHealth;
        public float maxHealth;

        // Start is called before the first frame update
        void Start()
        {
            enemyHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            enemyHealth -= damage;

            if(enemyHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}