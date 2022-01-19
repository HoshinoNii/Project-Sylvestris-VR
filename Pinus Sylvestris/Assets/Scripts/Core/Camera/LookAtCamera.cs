using UnityEngine;

namespace Sylvestris.Core.Camera {
	public class LookAtCamera : MonoBehaviour {
		public UnityEngine.Camera mainCamera;

		private void Update() {
			transform.LookAt(mainCamera.transform);
		}
	}
}