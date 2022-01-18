using System.Collections;
using UnityEngine;

namespace PinusSylvestris.Core
{
    public class ChangeLocation : MonoBehaviour
    {
        public static ChangeLocation instance;

        [SerializeField] private Animator animator;
        private int FadeInTrigger => Animator.StringToHash("FadeIn");
        private int FadeOutTrigger => Animator.StringToHash("FadeOut");


        private void Awake()
        {
            if (!instance)
                instance = this;
            else
                Destroy(gameObject);
        }

        public static void ChangeSphere(Transform nextSphere)
        {
            // Start fading process
            instance.StartCoroutine(instance.FadeCamera(nextSphere));
        }

        private IEnumerator FadeCamera(Transform nextSphere)
        {
            animator.SetTrigger(FadeOutTrigger);
            animator.ResetTrigger(FadeInTrigger);

            yield return new WaitForSeconds(2.0f);

            animator.SetTrigger(FadeInTrigger);
            animator.ResetTrigger(FadeOutTrigger);
            yield return null;

            if (Camera.main is null) yield break;

            var main = Camera.main;
            main.transform.parent.position = nextSphere.position;
            main.fieldOfView = 60.0f;
        }
    }
}