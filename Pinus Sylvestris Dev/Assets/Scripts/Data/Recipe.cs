using UnityEngine;

namespace Data {
    [CreateAssetMenu(menuName = "Recipe")]
    public class Recipe : ScriptableObject {
        public CoffeeType coffeeType;
        public IngredientType[] ingredients;
    }
}