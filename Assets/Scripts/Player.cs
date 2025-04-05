using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        public Camera playerCamera;
        public float walkSpeed = 6f;
        public float runSpeed = 12f;
        public float jumpPower = 7f;
        public float gravity = 10f;
        public float lookSpeed = 2f;
        public float lookXLimit = 45f;
        public float defaultHeight = 2f;
        public float crouchHeight = 1f;
        public float crouchSpeed = 3f;
        public float playerHealth;
        public float maxHealth = 100.0f;

        [SerializeField] private float soundRange = 25f;
        
        [SerializeField] private Sound.SoundType soundType = Sound.SoundType.Interesting;

        private Vector3 moveDirection = Vector3.zero;
        private float rotationX = 0;
        private CharacterController characterController;

        private bool canMove = true;

        void Start()
        {
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerHealth = maxHealth;
        }

        void Update()
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if(Input.GetKey(KeyCode.LeftShift))
            {

            var sound = new Sound(transform.position, soundRange, soundType);

            Sounds.MakeSound(sound);

            }


            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpPower;

            var sound = new Sound(transform.position, soundRange, soundType);

            Sounds.MakeSound(sound);
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.C) && canMove)
            {
                characterController.height = crouchHeight;
                walkSpeed = crouchSpeed;
                runSpeed = crouchSpeed;

            }
            else
            {
                characterController.height = defaultHeight;
                walkSpeed = 6f;
                runSpeed = 12f;
            }

            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
        }

        public void DamagePlayer(int damage)
        {
            playerHealth -= damage;


            if(playerHealth <= 0)
            {

                gameObject.SetActive(false);
            }


        }


    }
}