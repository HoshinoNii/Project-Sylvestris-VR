using System;
using System.Collections.Generic;
using Data;
using Inventory;
using UnityEngine;

namespace BaristaMachine {
    public class Coffee : MonoBehaviour {
        [SerializeField] private List<CoffeeStruct> coffeeModels = new List<CoffeeStruct>();
        public CoffeeType type;


        private void Awake() {
            DisableAllCoffeePrefabs();
        }

        // Load the prefab based on the coffee type
        private CoffeeStruct GetCoffeePrefab(CoffeeType coffeeType) {
            return coffeeModels.Find(x => x.coffeeType == coffeeType);
        }

        // Hide all the coffee
        private void DisableAllCoffeePrefabs() {
            foreach (CoffeeStruct coffee in coffeeModels) {
                coffee.coffeeGameObject.SetActive(false);
            }
        }

        // Initialize and configure.
        public void Config(CoffeeType coffeeType) {
            CoffeeStruct coffeeData = GetCoffeePrefab(coffeeType);
            GetComponent<CoffeeItem>().coffeeType = coffeeType;
            type = coffeeData.coffeeType;
            coffeeData.coffeeGameObject.SetActive(true);
        }
    }
}