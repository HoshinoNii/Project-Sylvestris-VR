using UnityEngine;
using AudioType = Core.Audio.Enums.AudioType;

namespace Core.Audio {
	public class UISoundEffects : MonoBehaviour {
		// This is to be used as a Singleton Hookup for sfxManager but for UI Buttons ONLY!
		[SerializeField] private SfxManager sfxManager;
		public static UISoundEffects Instance;

		// Start is called before the first frame update
		private void Start() {
			if (!Instance) {
				Instance = this;
				DontDestroyOnLoad(this);
			} else {
				Destroy(gameObject);
			}
		}

		public static void PlayButtonClick() {
			if (Instance.sfxManager) Instance.sfxManager.Play(AudioType.SfxUIButtonClick);
		}
	}
}