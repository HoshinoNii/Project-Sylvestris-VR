using System;
using Core.Audio;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Inventory {
    public class CollectItem : MonoBehaviour, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
        //public Color mouseOverColor = Color.blue;
        //private Color originalColor;
        //public GameObject Outline;

        public float pickupCooldown;
        private float _currentCooldown;
        public bool canTake;
        public bool isIngredient;
        public bool hideOnCollect;

        public AudioSource audio;
        public AudioClip clip;

        private void Start() {
            //r = GetComponent<Renderer>();
            //originalColor = r.material.color;
        }

        private void OnMouseEnter() {
            //if (Outline) Outline.SetActive(true);
            //else r.material.color = mouseOverColor;
        }

        private void OnMouseExit() {
            //if (Outline) Outline.SetActive(false);
            //else r.material.color = originalColor;
        }

        private void Update() {
            if (_currentCooldown <= 0)
                canTake = true;
            else
                _currentCooldown -= Time.deltaTime;
        }

        public void OnPointerUp(PointerEventData eventData) {
            if (!canTake) return;
            canTake = false;
            _currentCooldown = pickupCooldown;
            if (isIngredient) {
                Ingredient ingredient = GetComponent<Ingredient>();
                Inventory.Instance.AddItem(GetComponent<Item>(), ingredient);
            } else {
                CoffeeItem coffee = GetComponent<CoffeeItem>();
                Inventory.Instance.AddItem(GetComponent<Item>(), coffee);
            }
            
            if (!hideOnCollect) return;
            
            gameObject.SetActive(false);
            // Hide it to prevent issues
            transform.position = new Vector3(9000, 9000, 9000);
        }

        public void OnPointerEnter(PointerEventData eventData) {
            GetComponent<Animator>()?.SetBool("Hovering", true);
        }

        public void OnPointerExit(PointerEventData eventData) {
            GetComponent<Animator>()?.SetBool("Hovering", false);
        }
    }
}