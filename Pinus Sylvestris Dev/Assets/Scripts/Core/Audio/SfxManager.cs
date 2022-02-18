using System.Collections.Generic;
using Core.Audio.SubClass;
using UnityEngine;
using AudioType = Core.Audio.Enums.AudioType;


namespace Core.Audio {
	public class SfxManager : MonoBehaviour {
		[SerializeField] private bool requireTeam;
		[SerializeField] private bool debug;
		[SerializeField] private List<SoundEffect> soundEffects = new List<SoundEffect>();
		[SerializeField] private AnimationCurve templateSource;
		public static SfxManager Instance { get; private set; }

		private void Awake() {
			Configure();
		}
		
		private void Configure() {
			Instance = this;
			foreach (SoundEffect s in soundEffects) {
				
				s.source = gameObject.AddComponent<AudioSource>();
				s.source.rolloffMode = AudioRolloffMode.Custom;
				s.source.maxDistance = 500;
				s.source.spatialBlend = 1; //set to 3D
				s.source.SetCustomCurve(AudioSourceCurveType.CustomRolloff, templateSource);
				
				s.source.clip = s.clip;
				s.source.volume = s.volume;
				s.source.pitch = s.pitch;
			}
		}
		
		public void Play(AudioType name) {
			SoundEffect s = soundEffects.Find(x => x.name == name);
			if (s == null)
				Debug.Log($"AudioType {name} not found inside SFX Manager");
			else
				s.source.Play();
		}
		

		private void Start() {
			if (!requireTeam) Configure();
		}
	}
}