using System;
using UnityEngine;

namespace Sylvestris.Core.Camera
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private float fovMin = 10.0f;
        [SerializeField] private float fovMax = 60.0f;

        private UnityEngine.Camera Camera => UnityEngine.Camera.main;


        private void Start()
        {
            if (!Camera)
            {
                Debug.LogError($"{nameof(Camera)} is null!!");
            }
        }

        private void Update()
        {
            if(Camera == null) return;
            
            if (Input.GetAxis("Mouse ScrollWheel") > 0) // Scroll forward
                Camera.fieldOfView-- ;

            if (Input.GetAxis("Mouse ScrollWheel") < 0) // Scroll back
                Camera.fieldOfView++;

            Camera.fieldOfView = Mathf.Clamp(Camera.fieldOfView, fovMin, fovMax);
        }
    }
}