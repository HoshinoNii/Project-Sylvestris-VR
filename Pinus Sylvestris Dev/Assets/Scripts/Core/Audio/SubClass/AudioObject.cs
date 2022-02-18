using UnityEngine;
using AudioType = Core.Audio.Enums.AudioType;

namespace Core.Audio.SubClass {
	[System.Serializable]
	public class AudioObject {
		public AudioType type;
		public AudioClip clip;
	}
}