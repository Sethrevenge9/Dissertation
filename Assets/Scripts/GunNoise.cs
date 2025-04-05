using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{


    public class gunNoise : MonoBehaviour
    {
        public AudioSource gunSound;

        void Update()
        {
            if(Input.GetKey(KeyCode.Mouse0)){
                {
                    gunSound.enabled = true;
                }

            }
            else
            {
                gunSound.enabled = false;
            }
        }
    }
}


