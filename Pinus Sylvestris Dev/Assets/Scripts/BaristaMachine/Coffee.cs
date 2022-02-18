using System;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace BaristaMachine {
    public class Coffee : MonoBehaviour {
        [SerializeField] private List<CoffeeStruct> coffeeModels = new List<CoffeeStruct>();
        public CoffeeType type;


        private void Awake() {
            DisableAllCoffeePrefabs();
        }

        private CoffeeStruct GetCoffeePrefab(CoffeeType coffeeType) {
            return coffeeModels.Find(x => x.CoffeeType == coffeeType);
        }

        private void DisableAllCoffeePrefabs() {
            foreach (CoffeeStruct coffee in coffeeModels) {
                coffee.CoffeeGameObject.SetActive(false);
            }
        }

        public void Config(CoffeeType coffeeType) {
            CoffeeStruct coffeeData = GetCoffeePrefab(coffeeType);
            type = coffeeData.CoffeeType;
            coffeeData.CoffeeGameObject.SetActive(true);
        }
    }
}