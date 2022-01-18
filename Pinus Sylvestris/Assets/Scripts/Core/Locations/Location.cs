using UnityEngine;
using UnityEngine.Serialization;

namespace Sylvestris.Core.Locations
{
    [System.Serializable]
    public class Location : MonoBehaviour
    {
        public LocationType type;
        public Transform Position => transform;
    }
}