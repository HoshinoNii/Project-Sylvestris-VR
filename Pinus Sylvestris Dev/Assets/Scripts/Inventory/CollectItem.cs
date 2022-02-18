using UnityEngine;

namespace Inventory {
    public class CollectItem : MonoBehaviour {
        //public Color mouseOverColor = Color.blue;
        //private Color originalColor;
        //public GameObject Outline;

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

        private void OnMouseDown() {
            Inventory.Instance.AddItem(GetComponent<Item>());
            if (audio) audio.PlayOneShot(clip);
            this.gameObject.SetActive(false);
        }
    }
}