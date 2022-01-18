using UnityEngine;

namespace PinusSylvestris.Core
{
    public class LookAtCamera : MonoBehaviour
    {
        public Camera mainCamera;

        private void Update()
        {
            transform.LookAt(mainCamera.transform);
        }
    }
}