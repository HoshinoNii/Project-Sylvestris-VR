using UnityEngine;

namespace Sylvestris.Core.Inputs
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