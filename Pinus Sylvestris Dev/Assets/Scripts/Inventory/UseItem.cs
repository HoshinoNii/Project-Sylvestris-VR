using UnityEngine;

namespace Inventory {
    public class UseItem : MonoBehaviour {
        [HideInInspector] public Item item;

        // Start is called before the first frame update
        private void Start() { }

        public void Use() {
            Inventory.Instance.UseItem(item);
        }
    }
}