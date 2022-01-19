using System;
using UnityEngine;

namespace Sylvestris.Core.Locations {
	[Serializable]
	public class Location : MonoBehaviour {
		public LocationType type;
		public Transform Position => transform;
	}
}