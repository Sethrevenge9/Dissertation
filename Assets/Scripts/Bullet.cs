using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        public float bulletspeed, lifeTime;
        public Rigidbody theRigidBody;
        public int damage;
        public bool damagePlayer;
    
        Player DamagePlayer;

        Player playerHealth;


        void Awake()
        {

        }



        void Update()
        {
            
            theRigidBody.linearVelocity = transform.forward * bulletspeed;

            lifeTime -= Time.deltaTime;

            if(lifeTime <0)
            {
                Destroy(gameObject);
            }
        }


        void OnCollisionEnter(Collision other)
        {
            if(gameObject.tag == "Player" && damagePlayer)
            {

    

            }
            
            Destroy(gameObject);
        }

    }
}