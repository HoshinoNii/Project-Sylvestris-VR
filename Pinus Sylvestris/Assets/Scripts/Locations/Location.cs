using System;
using UnityEngine;

namespace Sylvestris.Locations {
	[Serializable]
	public class Location : MonoBehaviour {
		public LocationType type;
		public Transform Position => transform;
	}
}