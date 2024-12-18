﻿using System.Collections;
using Core.Utils;
using UnityEngine;

namespace Location {
    public class SceneChanger : MonoBehaviour{
        private static SceneChanger instance;
        public static SceneChanger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<SceneChanger>();
                }
                return instance;
            }
        }
        
        // This ensures that we don't mash to change spheres
        private bool changing = false;

        // This object should be called 'Fader' and placed over the camera
        private GameObject fader;

        private void Awake()
        {
            // Find the fader object
            fader = GameObject.Find("Fader");

            // Check if we found something
            if (fader == null)
                Debug.LogWarning("No Fader object found on camera");
        }

        public static void ChangeSphere(Transform nextSphere)
        {
            // Start fading process
            Instance.StartCoroutine(Instance.FadeCamera(nextSphere));
        }

        private IEnumerator FadeCamera(Transform nextSphere)
        {
            // Ensure there is a fader object
            if (fader != null)
            {
                // Fade the quad object in and delay for 0.75 seconds
                StartCoroutine(Utils.Fade(0.75f, fader.GetComponent<Renderer>().material, false));
                yield return new WaitForSecondsRealtime(0.75f);

                // Change camera position
                Camera.main.transform.parent.position = nextSphere.position;

                // Fade out the quad object
                StartCoroutine(Utils.Fade(0.75f, fader.GetComponent<Renderer>().material, true));
                yield return new WaitForSecondsRealtime(0.75f);
            }
            else
            {
                // No fader, so just swap the camera position
                Camera.main.transform.parent.position = nextSphere.position;
            }
        }
    }
}