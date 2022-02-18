using System;
using System.Collections.Generic;
using Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game {
    public class CustomerManager : MonoBehaviour {

        private CoffeeType[] coffeeTypes = new CoffeeType[3]
            { CoffeeType.CafeLatte, CoffeeType.WhiteChocolateMocha, CoffeeType.Cappuccino };
        public static CustomerManager Instance { get; private set; }
        public float timeOutDuration;
        public float lowScoreDuration;
        public float timeBeforeNewCustomer;
        private float _currentTime;
        public int pointsOnComplete;
        public int lowPointsOnComplete;
        public int maxCustomers;
        
        
        private List<Customer> _currentCustomers = new List<Customer>();

        private void Awake() {
            Instance = this;
        }

        private void CreateCustomer(CoffeeType coffee) {
            //We dont need to have more than 5 Customers
            if (_currentCustomers.Count > maxCustomers) return; 
            Customer customer = new Customer(coffee, timeOutDuration, lowScoreDuration, pointsOnComplete,
                lowPointsOnComplete);
            _currentCustomers.Add(customer);
        }

        private void Update() {
            if (_currentTime <= 0) {
                CreateCustomer(coffeeTypes[Random.Range(0, coffeeTypes.Length)]);
                _currentTime = timeBeforeNewCustomer;
            }
        }

        public void AddPoints(int i) {
            LevelManager.Instance.currentPoints = i;
        }

        public void RemoveCustomer(Customer customer) {
            if (!_currentCustomers.Contains(customer)) return;
            _currentCustomers.Remove(customer);
        }
    }
}