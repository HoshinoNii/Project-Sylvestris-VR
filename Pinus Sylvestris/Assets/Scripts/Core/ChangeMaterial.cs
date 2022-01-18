using System.Collections.Generic;
using UnityEngine;

namespace PinusSylvestris.Core
{
	public class ChangeMaterial: MonoBehaviour {
		public List<Material> materials = new List<Material>();

		public void NextMaterial() {
			this.GetComponent<MeshRenderer>().material = materials[1];
		}

		public void PreviousMaterial() {
			this.GetComponent<MeshRenderer>().material = materials[0];
		}
	}
}