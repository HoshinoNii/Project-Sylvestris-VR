﻿using System.Collections.Generic;
using UnityEngine;

namespace Core.Audio.SubClass {
	[System.Serializable]
	public class AudioTrack {
		public AudioSource source;
		public List<AudioObject> audio = new List<AudioObject>();
	}
}