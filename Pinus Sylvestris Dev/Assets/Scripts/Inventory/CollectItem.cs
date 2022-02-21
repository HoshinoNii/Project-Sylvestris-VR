using System;
using Core.Audio;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Inventory {
    public class CollectItem : MonoBehaviour, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
        public Renderer r;
        public Color originalColor;
        public Color mouseOverColor = Color.blue;
        private Color _originalColor;
        public GameObject outline;

        public float pickupCooldown;
        private float _currentCooldown;
        public bool canTake;
        public bool isIngredient;
        public bool hideOnCollect;

        public AudioSource audio;
        public AudioClip clip;

        private void Start() {
            r = GetComponentInChildren<Renderer>();
            originalColor = r.material.color;
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
            // Small delay to prevent spam
            if (!canTake) return;
            canTake = false;
            _currentCooldown = pickupCooldown;
            
            // If its an ingredient setup as a ingredient, else setup as a coffee
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

        // Anim control
        public void OnPointerEnter(PointerEventData eventData) {
            r.material.color = mouseOverColor;
            GetComponent<Animator>()?.SetBool("Hovering", true);
        }

        public void OnPointerExit(PointerEventData eventData) {
            r.material.color = originalColor;
            GetComponent<Animator>()?.SetBool("Hovering", false);
        }
    }
}