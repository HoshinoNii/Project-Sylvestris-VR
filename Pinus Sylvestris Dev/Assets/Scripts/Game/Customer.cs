using Data;
using UnityEngine;

namespace Game {
    
    [System.Serializable]
    public class Customer {
        [SerializeField] public CoffeeType coffee;
        [SerializeField] public float timeLeft;
        [SerializeField] private float _lowPointTime;
        [SerializeField] private int _pointsOnComplete;
        [SerializeField] private int _lowPointOnComplete;

        public Customer(CoffeeType coffee, float time, float lowPointTime, int pointOnComplete, int LowPointOnComplete) {
            this.coffee = coffee;
            this.timeLeft = time;
            this._lowPointTime = lowPointTime;
            this._lowPointOnComplete = LowPointOnComplete;
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