using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

namespace Assets.Scripts
{

    public class RandomMovement : MonoBehaviour 
    {

        [Header("AI variables")]
        NavMeshAgent agent;

        public Player player;

        FieldOfView fieldofview;

        public float range; 
        public GameObject bullet;
        public Transform firepoint;
        public bool CanAttack = true;
        public float fireRate;

        public float fireCount;

        public Transform centrePoint; 

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            CanAttack = true;
        }

        
        void Update()
        {
            

            if(agent.remainingDistance <= agent.stoppingDistance) 
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point)) 
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); 
                    agent.SetDestination(point);
                }
            }

            fieldofview = GetComponent<FieldOfView>();

            if (fieldofview.canSeePlayer == true)
            {
            agent.SetDestination(player.transform.position);
            }

            fireCount -= Time.deltaTime;

        //  fieldofview = this.transform.parent.GetComponent<FieldOfView>();

            if (fieldofview.canSeePlayer == true)
            {
                if(CanAttack)
                {

                    if(fireCount <0 )
                    {
                    fireCount = fireRate;

                    Instantiate(bullet, firepoint.position, firepoint.rotation);


                    }
                }
            }
        }
        bool RandomPoint(Vector3 center, float range, out Vector3 result)
        {

            Vector3 randomPoint = center + Random.insideUnitSphere * range; 
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
            { 
                //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
                //or add a for loop like in the documentation
                result = hit.position;
                return true;
            }

            result = Vector3.zero;
            return false;
        }




        
    }
}