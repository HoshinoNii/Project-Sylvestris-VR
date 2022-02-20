using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UI;
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
        
        
        public List<Customer> currentCustomers = new List<Customer>();

        private void Awake() {
            Instance = this;
        }

        private void CreateCustomer(CoffeeType coffee) {
            //We dont need to have more than 5 Customers
            if (currentCustomers.Count >= maxCustomers) return; 
            Customer customer = new Customer(coffee, timeOutDuration, lowScoreDuration, pointsOnComplete,
                lowPointsOnComplete, RandomNames.PickRandomName(), CoffeeThumbmailSprites.Instance.images[(int)coffee]);
            currentCustomers.Add(customer);
        }

        private void Update() {
            if (LevelManager.Instance.State == LevelState.PreGame || LevelManager.Instance.State == LevelState.GameOver) return;
            
            foreach (Customer customer in currentCustomers.ToArray()) {
                customer.ProcessTime(Time.deltaTime);
            }
            if (_currentTime <= 0) {
                CreateCustomer(coffeeTypes[Random.Range(0, coffeeTypes.Length)]);
                _currentTime = timeBeforeNewCustomer;
            } else {
                _currentTime -= Time.deltaTime;
            }
        }

        public void AddPoints(int i) {
            LevelManager.Instance.currentPoints += i;
        }

        public void RemoveCustomer(Customer customer) {
            if (!currentCustomers.Contains(customer)) return;
            currentCustomers.Remove(customer);
            
        }

        public void ServeCustomer(CoffeeType coffeeType) {
            List<Customer> customers = currentCustomers.FindAll(x => x.coffee == coffeeType);
            List<Customer> orderedCustomers = customers.OrderBy(x => x.timeLeft).ToList();
            if (orderedCustomers.Count > 0) {
                orderedCustomers[0].Complete();
            }
        } 
    }
}