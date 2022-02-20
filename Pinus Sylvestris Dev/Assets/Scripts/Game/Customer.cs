using Data;
using TMPro;
using UnityEngine;

namespace Game {
    
    [System.Serializable]
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
            this._pointsOnComplete = pointOnComplete;
            this._lowPointTime = lowPointTime;
            this._lowPointOnComplete = lowPointOnComplete;
            this.name = name;
            this.coffeeImage = coffeeImage;
        }

        //Process the time
        public void ProcessTime(float value) {
            
            // if timeLeft <= 0 return
            if (timeLeft <= 0) return;
            
            timeLeft -= value;

            // if the time left has reached to the low time counter, set the score to the low point score.
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
            Debug.Log($"Added Points {_pointsOnComplete}");
            CustomerManager.Instance.AddPoints(_pointsOnComplete);
            CustomerManager.Instance.RemoveCustomer(this);
        }
    }
}