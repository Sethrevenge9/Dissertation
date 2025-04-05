
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //For use of Navmesh agent

namespace Assets.Scripts
{

    public class SoundManager : MonoBehaviour, IHear
    {
        [SerializeField] private NavMeshAgent agent = null;

        [SerializeField, Tooltip("How far away, in meters, the agent will run from danger.")] 

        public AudioSource Danger;

        public AudioSource Intrest;

        private float displacementFromDanger = 10f;

        void Awake() 
        {
    
        }

        public void RespondToSound(Sound sound)
        {

        
            if (sound.soundType == Sound.SoundType.Interesting)
            {   MoveTo(sound.pos);
                Intrest.enabled = true;
            }
            else if (sound.soundType == Sound.SoundType.Dangerous) //Must have this case so that it doesn't run away from the default sound type
            {
                Vector3 dir = (sound.pos - transform.position).normalized;
                MoveTo(transform.position - (dir * displacementFromDanger));
                Danger.enabled = true;
            }
            //else will do nothing in the case of Sounds with Default sound type
        }

        private void MoveTo(Vector3 pos) 
        {
            agent.SetDestination(pos);
            agent.isStopped = false;
        }
    }
}