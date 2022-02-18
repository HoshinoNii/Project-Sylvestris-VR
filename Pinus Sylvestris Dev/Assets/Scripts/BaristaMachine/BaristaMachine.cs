using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;

namespace BaristaMachine {
    public class BaristaMachine : MonoBehaviour {
        public static BaristaMachine Instance { get; private set; }

        [SerializeField] private Transform coffeeSpawnPoint;
        [SerializeField] private GameObject coffeePrefab;
        [SerializeField] private List<Recipe> recipes = new List<Recipe>();
        [SerializeField] private List<IngredientType> currentIngredients = new List<IngredientType>();


        private void Awake() {
            Instance = this;
        }

        public static CoffeeType GetRecipe(List<IngredientType> ingredientTypes) {
            foreach (Recipe recipe in Instance.recipes) {
                bool sequenceEqual = recipe.ingredients.SequenceEqual(ingredientTypes);
                if (sequenceEqual) {
                    return recipe.coffeeType;
                }
            }

            return CoffeeType.Coffee; // Return Questionable coffee
        }

        public static void PrepareCoffee() {
            Instance.CreateCoffee(GetRecipe(Instance.currentIngredients));
        }

        private void CreateCoffee(CoffeeType coffeeType) {
            GameObject coffee = Instantiate(coffeePrefab, coffeeSpawnPoint);
            Coffee coffeeRef = coffee.GetComponent<Coffee>();
            coffeeRef.Config(coffeeType);
        }
    }
}