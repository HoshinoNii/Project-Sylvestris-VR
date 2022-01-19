using UnityEngine;

namespace Sylvestris.Core.Camera
{
    public class CameraZoom : MonoBehaviour
    {
        private void Update()
        {
            const float fovMin = 10.0f;
            const float fovMax = 60.0f;

            if (Input.GetAxis("Mouse ScrollWheel") > 0) // Scroll forward
                UnityEngine.Camera.main.fieldOfView--;

            if (Input.GetAxis("Mouse ScrollWheel") < 0) // Scroll back
                UnityEngine.Camera.main.fieldOfView++;

            UnityEngine.Camera.main.fieldOfView = Mathf.Clamp(UnityEngine.Camera.main.fieldOfView, fovMin, fovMax);

            //if (Input.GetMouseButton(1))
            //{
            //	transform.Translate(Vector3.right * -Input.GetAxis("Mouse X") * panSpeed);
            //	transform.Translate(transform.up * -Input.GetAxis("Mouse Y") * panSpeed, Space.World);
            //}
        }
    }
}