using Data;
using UnityEngine;

namespace Game {
    
    public class Customer {
        public CoffeeType Coffee;
        public float TimeLeft;

        public Customer(CoffeeType coffee, float time) {
            this.Coffee = coffee;
            this.TimeLeft = time;
        }

        public void ProcessTime(float value) {
            
            if (TimeLeft <= 0) return;
            
            TimeLeft -= value;
            if (TimeLeft <= 0) {
                TimeOut();
            }
        }

        private void TimeOut() {
            // We can handle any TimeOutHere
        }
    }
}