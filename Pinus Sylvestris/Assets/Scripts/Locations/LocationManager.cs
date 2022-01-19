using System.Collections.Generic;
using Sylvestris.Core.SceneControl;
using UnityEngine;

namespace Sylvestris.Core.Locations {
	public class LocationManager : MonoBehaviour {
		[SerializeField] private List<Location> locations = new List<Location>();
		public static LocationManager Instance { get; private set; }

		private void Awake() {
			if (Instance == null)
				Instance = this;
			else
				Destroy(gameObject);
		}

		private Location GetLocation(LocationType type) {
			return locations.Find(x => x.type == type);
		}

		private Location GetLocation(int index) {
			return locations[index];
		}

		// Use this to change location based on index
		public void GotoLocation(int index) {
			ChangeLocation.ChangeSphere(GetLocation(index).Position);
		}

		// Use this to change location based on index
		public void GotoLocation(LocationType type) {
			ChangeLocation.ChangeSphere(GetLocation(type).Position);
		}
	}
}