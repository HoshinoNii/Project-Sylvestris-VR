using System.Collections.Generic;
using Core.Audio.SubClass;
using UnityEngine;
using AudioType = Core.Audio.Enums.AudioType;


namespace Core.Audio {
	public class SfxManager : MonoBehaviour {
		[SerializeField] private List<SoundEffect> soundEffects = new List<SoundEffect>();
		private static SfxManager Instance { get; set; }

		private void Awake() {
			Configure();
		}
		
		private void Configure() {
			Instance = this;
			foreach (SoundEffect s in soundEffects) {
				s.source.clip = s.clip;
				s.source.volume = s.volume;
				s.source.pitch = s.pitch;
			}
		}
		
		public static void Play(AudioType name) {
			SoundEffect s = Instance.soundEffects.Find(x => x.name == name);
			if (s == null)
				Debug.Log($"AudioType {name} not found inside SFX Manager");
			else
				s.source.PlayOneShot(s.clip);
		}
		
	}
}