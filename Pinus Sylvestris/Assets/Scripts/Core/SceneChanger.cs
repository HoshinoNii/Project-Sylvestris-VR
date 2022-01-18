using System.Collections;
using UnityEngine;

namespace PinusSylvestris.Core
{
	public class SceneChanger: MonoBehaviour {
		// This object should be called 'Fader' and placed over the camera
		GameObject fader;

		// This ensures that we don't mash to change spheres
		bool changing = false;

		void Awake() {
			// Find the fader object
			fader = GameObject.Find("Fader");

			// Check if we found something
			if(fader == null)
				Debug.LogWarning("No Fader object found on camera");
		}

		public void ChangeSphere(Transform nextSphere) {
			// Start fading process
			StartCoroutine(FadeCamera(nextSphere));
		}

		IEnumerator FadeCamera(Transform nextSphere) {
			// Ensure there is a fader object
			if(fader != null) {
				// Fade the quad object in and delay for 0.75 seconds
				StartCoroutine(FadeIn(0.75f, fader.GetComponent<Renderer>().material));
				yield return new WaitForSeconds(0.75f);

				// Change camera position
				Camera.main.transform.parent.position = nextSphere.position;

				// Fade out the quad object
				StartCoroutine(FadeOut(0.75f, fader.GetComponent<Renderer>().material));
				yield return new WaitForSeconds(0.75f);
			} else {
				// No fader, so just swap the camera position
				Camera.main.transform.parent.position = nextSphere.position;
			}
		}

		IEnumerator FadeIn(float time, Material material) {
			// Fade to black
			while(material.color.a < 1.0f) {
				material.color = new Color(material.color.r, material.color.g, material.color.b, material.color.a + (Time.deltaTime / time));
				yield return null;
			}
		}

		IEnumerator FadeOut(float time, Material material) {
			// Fade to transparent
			while(material.color.a > 0.0f) {
				material.color = new Color(material.color.r, material.color.g, material.color.b, material.color.a - (Time.deltaTime / time));
				yield return null;
			}
		}
	}
}