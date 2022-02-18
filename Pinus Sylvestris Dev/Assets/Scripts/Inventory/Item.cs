using Data;
using UnityEngine;

namespace Inventory {
    public class Item : MonoBehaviour {
        public int numberOfUse = 1;
        public IngredientType itemType;

        [HideInInspector] public GameObject UI_Item;
    }
}