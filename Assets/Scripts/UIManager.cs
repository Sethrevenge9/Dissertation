using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        [Header("Text")]
        public TMP_Text ammoDisplay;
        public TMP_Text healthDisplay;
        [SerializeField] TMP_Text interactionText;

        [Header("Sprites")]
        public Sprite fullHealth;
        public Sprite highHealth;
        public Sprite halfHealth;
        public Sprite lowHealth;
        public Sprite emptyHealth;
        
        [Header("GameObjects")]
        public Image healthCounter;

        public static UIManager instance;

        private void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
        // healthCounter = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void UpdateAmmo(int ammo, int maxAmmo)
        {
            ammoDisplay.text = "" + ammo + "/" + maxAmmo;
        }


        public void updateHealth(float health)
        {
            healthDisplay.text ="" + health;
        }

        public void setHealthImage(float uiHealth)
        {
            if(uiHealth >= 80)
            {
                healthCounter.sprite = fullHealth;
            }
            else if(uiHealth >= 65)
            {
                healthCounter.sprite = highHealth;
            }
            else if(uiHealth >= 40)
            {
                healthCounter.sprite = halfHealth;
            }
            else if(uiHealth >= 1)
            {
                healthCounter.sprite = lowHealth;
            }
            else
            {
                healthCounter.sprite = emptyHealth;
            }
        }

        public void EnableInteractionText(string text)
        {
            interactionText.text = text;
            interactionText.gameObject.SetActive(true);
        }

        public void DisableInteractionText()
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}