using System.Collections.Generic;
using UnityEngine;

namespace PinusSylvestris.Core
{
    public class ChangeMaterial : MonoBehaviour
    {
        public List<Material> materials = new List<Material>();

        public void NextMaterial()
        {
            GetComponent<MeshRenderer>().material = materials[1];
        }

        public void PreviousMaterial()
        {
            GetComponent<MeshRenderer>().material = materials[0];
        }
    }
}