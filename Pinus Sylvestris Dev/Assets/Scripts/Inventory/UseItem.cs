using Data;
using UnityEngine;

namespace Inventory {
    public class UseItem : MonoBehaviour {

        public bool isIngredient;
        public IngredientType ingredientType;
        public CoffeeType coffeeType;
        [HideInInspector] public Item item;

        // Start is called before the first frame update
        private void Start() { }

        public void Use() {
            if (isIngredient) {
                Inventory.Instance.UseItem(item, ingredientType);
            } else {
                Inventory.Instance.UseItem(item, coffeeType);
            }
        }
    }
}