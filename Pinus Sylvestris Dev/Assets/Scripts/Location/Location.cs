using UnityEngine;

namespace Location {
    //Store general location data
    [System.Serializable]
    public class Location : MonoBehaviour
    {
        public LocationType type;
        public Transform Position => transform;
    }
}
