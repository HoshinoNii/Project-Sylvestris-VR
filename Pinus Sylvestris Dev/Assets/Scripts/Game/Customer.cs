using Data;
using TMPro;
using UnityEngine;

namespace Game {
    
    public class Customer {
        [SerializeField] public CoffeeType coffee;
        [SerializeField] public float timeLeft;
        [SerializeField] private float _lowPointTime;
        [SerializeField] private int _pointsOnComplete;
        [SerializeField] private int _lowPointOnComplete;
        public string name;
        public Sprite coffeeImage;

        public Customer(CoffeeType coffee, float time, float lowPointTime, int pointOnComplete, int lowPointOnComplete, string name, Sprite coffeeImage) {
            this.coffee = coffee;
            this.timeLeft = time;
            this._lowPointTime = lowPointTime;
            this._lowPointOnComplete = lowPointOnComplete;
            this.name = name;
            this.coffeeImage = coffeeImage;
        }

        public void ProcessTime(float value) {
            
            if (timeLeft <= 0) return;
            
            timeLeft -= value;

            if (timeLeft < _lowPointTime) {
                _pointsOnComplete = _lowPointOnComplete;
            }
            if (timeLeft <= 0) {
                TimeOut();
            }
        }

        private void TimeOut() {
            // We can handle any TimeOutHere
            CustomerManager.Instance.RemoveCustomer(this);
        }

        public void Complete() {
            CustomerManager.Instance.AddPoints(_pointsOnComplete);
            CustomerManager.Instance.RemoveCustomer(this);
        }
    }
}