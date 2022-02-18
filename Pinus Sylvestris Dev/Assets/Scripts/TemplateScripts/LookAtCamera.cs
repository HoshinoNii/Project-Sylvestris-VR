using UnityEngine;

namespace TemplateScripts {
    public class LookAtCamera : MonoBehaviour {
        public Camera mainCamera;

        private void Update() {
            this.transform.LookAt(mainCamera.transform);
        }
    }
}