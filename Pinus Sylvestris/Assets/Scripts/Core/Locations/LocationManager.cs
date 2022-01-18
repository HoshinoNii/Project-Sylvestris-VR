using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sylvestris.Core.Locations {
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

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}