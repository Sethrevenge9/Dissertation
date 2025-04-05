using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class footsteps : MonoBehaviour
    {
        public AudioSource footstepsSound, sprintSound, crouchSound;




        void Update()
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    footstepsSound.enabled = false;
                    sprintSound.enabled = true;
                    crouchSound.enabled = false;
                }

                else if (Input.GetKey(KeyCode.C))
                {
                    footstepsSound.enabled = false;
                    sprintSound.enabled = false;
                    crouchSound.enabled = true;

                }

                else
                {
                    footstepsSound.enabled = true;
                    sprintSound.enabled = false;
                    crouchSound.enabled = false;
                }
            }
            else
            {
                footstepsSound.enabled = false;
                sprintSound.enabled = false;
                crouchSound.enabled = false;
            }


        }

        public void MakeAnInterestingSound(float range)
        {
            var sound = new Sound(transform.position, range, Sound.SoundType.Interesting); 
            
            Sounds.MakeSound(sound);
        }


    }

}