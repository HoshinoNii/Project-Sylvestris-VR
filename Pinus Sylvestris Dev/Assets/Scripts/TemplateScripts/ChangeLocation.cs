using System.Collections;
using UnityEngine;

namespace TemplateScripts {
    public class ChangeLocation : MonoBehaviour {
        public Animator animator;

        public void ChangeSphere(Transform nextSphere) {
            // Start fading process
            StartCoroutine(FadeCamera(nextSphere));
        }

        private IEnumerator FadeCamera(Transform nextSphere) {
            animator.SetTrigger("FadeOut");
            animator.ResetTrigger("FadeIn");
            yield return new WaitForSeconds(2.0f);

            animator.SetTrigger("FadeIn");
            animator.ResetTrigger("FadeOut");
            yield return null;

            Camera.main.transform.parent.position = nextSphere.position;
            Camera.main.fieldOfView = 60.0f;
        }
    }
}