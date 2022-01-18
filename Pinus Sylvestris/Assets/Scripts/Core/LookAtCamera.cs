using UnityEngine;

namespace PinusSylvestris.Core
{
	public class LookAtCamera : MonoBehaviour {
		public Camera mainCamera;

		void Update() {
			this.transform.LookAt(mainCamera.transform);
		}
	}
}