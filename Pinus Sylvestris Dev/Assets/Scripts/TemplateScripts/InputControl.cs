using UnityEngine;

namespace TemplateScripts {
    public class InputControl : MonoBehaviour {
        private void Update() {
            if (Input.GetButtonDown("Fire1")) {
                Debug.Log("Y and B button pressed");
            }

            if (Input.GetButtonDown("Jump")) {
                Debug.Log("OK button pressed");
            }

            if (Input.GetButtonDown("Submit")) {
                Debug.Log("Y button pressed");
            }

            if (Input.GetButtonDown("Cancel")) {
                Debug.Log("X button pressed");
            }
        }
    }
}