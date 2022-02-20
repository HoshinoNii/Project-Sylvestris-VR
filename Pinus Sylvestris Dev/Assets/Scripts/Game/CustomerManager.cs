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
            
            // Start counting down.
            foreach (Customer customer in currentCustomers.ToArray()) {
                customer.ProcessTime(Time.deltaTime);
            }
            
            // If current time is less than 0 we add a new customer with a random coffee requirement
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

        // Remove once done
        public void RemoveCustomer(Customer customer) {
            if (!currentCustomers.Contains(customer)) return;
            currentCustomers.Remove(customer);
            
        }

        
        // This is called when the coffee is delivered to the tray
        public void ServeCustomer(CoffeeType coffeeType) {
            // Get all the customers that needs this coffee type
            List<Customer> customers = currentCustomers.FindAll(x => x.coffee == coffeeType);
            // Order them by the lowest time left
            List<Customer> orderedCustomers = customers.OrderBy(x => x.timeLeft).ToList();
            
            // if there are customers, complete the first in its list
            if (orderedCustomers.Count > 0) {
                orderedCustomers[0].Complete();
            }
        } 
    }
}