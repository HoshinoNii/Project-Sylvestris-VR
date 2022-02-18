using Data;
using UnityEngine;

namespace Game {
    
    public class Customer {
        private CoffeeType _coffee;
        private float _timeLeft;
        private float _lowPointTime;
        private int _pointsOnComplete;
        private int _lowPointOnComplete;

        public Customer(CoffeeType coffee, float time, float lowPointTime, int pointOnComplete, int LowPointOnComplete) {
            this._coffee = coffee;
            this._timeLeft = time;
            this._lowPointTime = lowPointTime;
            this._lowPointOnComplete = LowPointOnComplete;
        }

        public void ProcessTime(float value) {
            
            if (_timeLeft <= 0) return;
            
            _timeLeft -= value;

            if (_timeLeft < _lowPointTime) {
                _pointsOnComplete = _lowPointOnComplete;
            }
            if (_timeLeft <= 0) {
                TimeOut();
            }
        }

        private void TimeOut() {
            // We can handle any TimeOutHere
            CustomerManager.Instance.RemoveCustomer(this);
        }

        private void Complete() {
            CustomerManager.Instance.AddPoints(_pointsOnComplete);
        }
    }
}