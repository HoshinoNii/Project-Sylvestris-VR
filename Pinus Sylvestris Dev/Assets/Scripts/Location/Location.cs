using UnityEngine;

namespace Location {
    [System.Serializable]
    public class Location : MonoBehaviour
    {
        public LocationType type;
        public Transform Position => transform;
    }
}
