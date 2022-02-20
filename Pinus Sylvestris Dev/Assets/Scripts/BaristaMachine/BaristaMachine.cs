using System;
using System.Collections.Generic;
using System.Linq;
using Core.Audio;
using Data;
using Inventory;
using UnityEngine;
using AudioType = Core.Audio.Enums.AudioType;

namespace BaristaMachine {
    public class BaristaMachine : UseItemOnThis {
        public static BaristaMachine Instance { get; private set; }

        [SerializeField] private Transform coffeeSpawnPoint;
        [SerializeField] private GameObject coffeePrefab;
        [SerializeField] private List<Recipe> recipes = new List<Recipe>();
        [SerializeField] private List<IngredientType> currentIngredients = new List<IngredientType>();
        public List<string> Ingredients {
            get {
                return currentIngredients.Select(currentIngredient => currentIngredient.ToString()).ToList();
            }
        }


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

        private static void PrepareCoffee() {
            Instance.CreateCoffee(GetRecipe(Instance.currentIngredients));
        }

        private void CreateCoffee(CoffeeType coffeeType) {
            GameObject coffee = Instantiate(coffeePrefab, coffeeSpawnPoint.position, Quaternion.identity);
            Coffee coffeeRef = coffee.GetComponent<Coffee>();
            coffeeRef.Config(coffeeType);
            currentIngredients.Clear();
        }

        public override void FirstUnlockInstance() {
            AddIngredient();
        }

        public override void SubsequentActivation_IfAny() {
            AddIngredient();
        }

        private void AddIngredient() {
            if (currentIngredients.Count > 4) return;
            SfxManager.Play(AudioType.SfxInteractWithBarista);
            Ingredient item = Inventory.Inventory.Instance.SelectedItem.GetComponent<Ingredient>();
            if (!item) return;
            currentIngredients.Add(item.ingredientType);
            SetItemAsUsed();

            if (currentIngredients.Count >= 4) {
                PrepareCoffee();
            }
        }
    }
}
