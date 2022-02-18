using UnityEngine;

namespace TemplateScripts {
    public class CameraZoom : MonoBehaviour {
        private void Update() {
            float fovMin = 10.0f;
            float fovMax = 60.0f;

            if (Input.GetAxis("Mouse ScrollWheel") > 0) { // Scroll forward
                Camera.main.fieldOfView--;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0) { // Scroll back
                Camera.main.fieldOfView++;
            }

            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, fovMin, fovMax);

            //if (Input.GetMouseButton(1))
            //{
            //	transform.Translate(Vector3.right * -Input.GetAxis("Mouse X") * panSpeed);
            //	transform.Translate(transform.up * -Input.GetAxis("Mouse Y") * panSpeed, Space.World);
            //}
        }
    }
}