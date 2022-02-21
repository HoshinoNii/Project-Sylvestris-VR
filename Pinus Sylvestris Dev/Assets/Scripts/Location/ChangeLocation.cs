using System.Collections;
using UnityEngine;

namespace Location {
    public class ChangeLocation : MonoBehaviour {
        public static ChangeLocation Instance { get; private set; }

        [SerializeField] private Animator animator;
        private int FadeInTrigger => Animator.StringToHash("FadeIn");
        private int FadeOutTrigger => Animator.StringToHash("FadeOut");


        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public static void ChangeSphere(Transform nextSphere)
        {
            // Start fading process
            Instance.StartCoroutine(Instance.FadeCamera(nextSphere));
        }

        private IEnumerator FadeCamera(Transform nextSphere)
        {
            animator.SetTrigger(FadeOutTrigger);
            animator.ResetTrigger(FadeInTrigger);

            yield return new WaitForSecondsRealtime(1.5f);

            animator.SetTrigger(FadeInTrigger);
            animator.ResetTrigger(FadeOutTrigger);
            yield return null;

            if (Camera.main is null) yield break;

            Camera main = UnityEngine.Camera.main;
            main.transform.parent.position = nextSphere.position;
            main.fieldOfView = 60.0f;
        }
    }
}