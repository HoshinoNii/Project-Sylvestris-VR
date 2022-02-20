using System;
using Core.Audio;
using UnityEngine;
using AudioType = Core.Audio.Enums.AudioType;

namespace Inventory {
    public class CollectItem : MonoBehaviour {
        //public Color mouseOverColor = Color.blue;
        //private Color originalColor;
        //public GameObject Outline;

        public float pickupCooldown;
        private float _currentCooldown;
        public bool canTake;

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

        private void OnMouseDown() {
            if (!canTake) return;
            _currentCooldown = pickupCooldown;
            Inventory.Instance.AddItem(GetComponent<Item>());
            SfxManager.Play(AudioType.SfxPickup);
        }
    }
}