using UnityEngine;

namespace PinusSylvestris.Core
{
	public class HotspotControl : MonoBehaviour {
		public void OnEnable() {
			this.gameObject.SetActive(true);
		}

		public void OnDisable() {
			this.gameObject.SetActive(false);
		}
	}
}