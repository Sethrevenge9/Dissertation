using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class Guns : MonoBehaviour
    {

        [Header ("Gun Attributes)") ]
        public float damage = 10f;
        public float fireRate = 5f;
        public float range = 100f;
        public int ammo;
        public int maxAmmo = 20;
        public float reloadTime = 1f;

        [SerializeField] private float soundRange = 25f;
        
        [SerializeField] private Sound.SoundType soundType = Sound.SoundType.Dangerous;

        private bool isReloading = false;

        [Header ("Game Objects")]
        public Camera cam;
        public ParticleSystem muzzleFlash;
        public GameObject Player;
        UIManager uiManager;

        private float nextTimeToFire = 0f;

        void Start()
        {
            ammo = maxAmmo;   
    //        uiManager = GameObject.Find("GameUI").GetComponent<UIManager>();
        }

        void Update()
        {
            if(isReloading)
            {
                return;
            }
        
            if(ammo <= 0)
            {
                StartReload();
            }
            else if(Input.GetButtonDown("Reload") && ammo < maxAmmo)
            {
                StartReload();
            }

            if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time +1f/fireRate;
                Shoot();
            }

    //        uiManager.UpdateAmmo(ammo, maxAmmo);

        }   



        void Shoot()
        {
            muzzleFlash.Play();
            RaycastHit hit;
            ammo--;


            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
                if(enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }

            var sound = new Sound(transform.position, soundRange, soundType);

            Sounds.MakeSound(sound);



        }

        public void StartReload()
        {
            if(!isReloading && this.gameObject.activeSelf)
            {
                StartCoroutine(Reload());
            }
        }

        IEnumerator Reload()
        {
            isReloading = true;
            yield return new WaitForSeconds(reloadTime);

            ammo = maxAmmo;
            isReloading = false;
        }

        private void OnDisable() => isReloading = false; 
        

        
    }
}