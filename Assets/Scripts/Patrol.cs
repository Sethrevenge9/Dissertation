using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{

    public class PatrolEnemyAI : MonoBehaviour
    {

        [Header("AI variables")]
        NavMeshAgent agent;
        public Transform[] waypoint;
        int waypointIndex;
        Vector3 target;

        public Player player;

        FieldOfView fieldofview;


        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            UpdateDestination();
        }

        void Update()
        {

            fieldofview = GetComponent<FieldOfView>();

            if (fieldofview.canSeePlayer == true)
            {
            agent.SetDestination(player.transform.position);
            }
            else if (fieldofview.canSeePlayer == false)
            {
                UpdateDestination();

                if (Vector3.Distance(transform.position, target) < 1)
                    {
                        IterateWaypointIndex();
                        UpdateDestination();
                    }
            }
        }

        void UpdateDestination()
        {

            target = waypoint[waypointIndex].position;
            agent.SetDestination(target);

        }

        void IterateWaypointIndex() 
        {

            waypointIndex++;
            if(waypointIndex== waypoint.Length)
            {
                    waypointIndex = 0;
            }

        }
    }
}