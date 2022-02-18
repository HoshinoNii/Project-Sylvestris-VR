using System.Collections.Generic;
using UnityEngine;

namespace Location {
    public class LocationManager : MonoBehaviour
    {
        public static LocationManager Instance { get; private set; }
        [SerializeField] private List<Location> locations = new List<Location>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public static Location GetLocation(LocationType type)
        {
            return Instance.locations.Find(x => x.type == type);
        }
        
        public static Location GetLocation(int index)
        {
            return Instance.locations[index];
        }

        // Use this to change location based on index
        public void GotoLocation(int index)
        {
            ChangeLocation.ChangeSphere(GetLocation(index).Position);
        }
        
        // Use this to change location based on index
        public void GotoLocation(LocationType type)
        {
            ChangeLocation.ChangeSphere(GetLocation(type).Position);
        }
    }
}