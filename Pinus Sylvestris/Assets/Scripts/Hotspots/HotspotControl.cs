using System.Collections;
using UnityEngine;

namespace Sylvestris.Hotspots {
	public class HotspotControl : MonoBehaviour {
		private Animator Animator => GetComponent<Animator>();
		private int FadeInTrigger => Animator.StringToHash("FadeIn");
		private int FadeOutTrigger => Animator.StringToHash("FadeOut");


		private void OnEnable() {
			StartCoroutine(Fade(false)); //FADE OUT
		}


		public void FadeIn() {
			StartCoroutine(Fade(true));
		}

		public void FadeOut() {
			StartCoroutine(Fade(false));
		}

		private IEnumerator Fade(bool fadeIn) {
			if (fadeIn) {
				Animator.SetTrigger(FadeInTrigger);
				Animator.ResetTrigger(FadeOutTrigger);
			} else {
				Animator.SetTrigger(FadeOutTrigger);
				Animator.ResetTrigger(FadeInTrigger);
				yield return new WaitForSeconds(.3f);
			}
		}

		private void SetState(bool state) {
			gameObject.SetActive(state);
		}
	}
}