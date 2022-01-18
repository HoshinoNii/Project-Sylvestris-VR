using System.Collections;
using UnityEngine;

namespace PinusSylvestris.Core
{
    public class SceneChanger : MonoBehaviour
    {
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

        public void ChangeSphere(Transform nextSphere)
        {
            // Start fading process
            StartCoroutine(FadeCamera(nextSphere));
        }

        private IEnumerator FadeCamera(Transform nextSphere)
        {
            // Ensure there is a fader object
            if (fader != null)
            {
                // Fade the quad object in and delay for 0.75 seconds
                StartCoroutine(Utils.Fade(0.75f, fader.GetComponent<Renderer>().material, false));
                yield return new WaitForSeconds(0.75f);

                // Change camera position
                Camera.main.transform.parent.position = nextSphere.position;

                // Fade out the quad object
                StartCoroutine(Utils.Fade(0.75f, fader.GetComponent<Renderer>().material, true));
                yield return new WaitForSeconds(0.75f);
            }
            else
            {
                // No fader, so just swap the camera position
                Camera.main.transform.parent.position = nextSphere.position;
            }
        }

        // private IEnumerator FadeIn(float time, Material material)
        // {
        //     // Fade to black
        //     while (material.color.a < 1.0f)
        //     {
        //         material.color = new Color(material.color.r, material.color.g, material.color.b,
        //             material.color.a + Time.deltaTime / time);
        //         yield return null;
        //     }
        // }
        //
        // private IEnumerator FadeOut(float time, Material material)
        // {
        //     // Fade to transparent
        //     while (material.color.a > 0.0f)
        //     {
        //         material.color = new Color(material.color.r, material.color.g, material.color.b,
        //             material.color.a - Time.deltaTime / time);
        //         yield return null;
        //     }
        // }
        //
        // private static IEnumerator Fade(float time, Material material, bool fadeOut)
        // {
        //     // Fade to transparent
        //     while (fadeOut ? material.color.a > 0.0f : material.color.a < 1.0f)
        //     {
        //         material.color = new Color(material.color.r, material.color.g, material.color.b,
        //             material.color.a - Time.deltaTime / time);
        //         yield return null;
        //     }
        // }
    }
}