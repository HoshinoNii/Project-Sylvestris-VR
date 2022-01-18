using UnityEngine;

namespace PinusSylvestris.Core
{
    public class HotspotControl : MonoBehaviour
    {
        public void OnEnable()
        {
            gameObject.SetActive(true);
        }

        public void OnDisable()
        {
            gameObject.SetActive(false);
        }
    }
}