using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class EnemyMeleeAttack : MonoBehaviour
    {

        public GameObject bat;
        public bool CanAttack = true;
        public bool isAttacking = false;
        public float AttackCooldown = 1.0f;
        public int damage = 20;

        FieldOfView fieldofview;

        // Start is called before the first frame update
        void Start()
        {
            CanAttack = true;
        }

        // Update is called once per frame
        void Update()
        {
            fieldofview = this.transform.parent.GetComponent<FieldOfView>();

            if (fieldofview.canSeePlayer == true)
            {
                if(CanAttack)
                {
                    BatAttack();
                    StartCoroutine(ResetAttackCooldown());
                }
            }
        }

        public void BatAttack()
        {
            CanAttack = false;
            isAttacking = true;
            Animator anim = bat.GetComponent<Animator>();
            anim.SetTrigger("attack");
        }

        IEnumerator ResetAttackCooldown()
        {
            StartCoroutine(ResetAttack());
            yield return new WaitForSeconds(AttackCooldown);
            CanAttack = true;
        }

        IEnumerator ResetAttack()
        {
            yield return new WaitForSeconds(1.0f);
            isAttacking = false;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("hit");
            if (isAttacking)
            {
                Debug.Log(other.name);
                Player player = other.transform.GetComponent<Player>();
                if(player != null)
                {
                    player.DamagePlayer(damage);
                }
            }
        }
    }
}