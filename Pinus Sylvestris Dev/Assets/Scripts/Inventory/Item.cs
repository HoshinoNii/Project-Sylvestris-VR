using UnityEngine;

namespace Inventory {
    public class Item : MonoBehaviour {
        public int numberOfUse = 1;
        public ItemType itemType;
        
        public GameObject UI_Item;
    }
}