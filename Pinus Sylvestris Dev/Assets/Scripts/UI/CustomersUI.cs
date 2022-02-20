using System;
using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;

namespace UI {
    public class CustomersUI : MonoBehaviour {
        public static CustomersUI Instance { get; private set; }
        public List<GameObject> customerElements = new List<GameObject>();

        // Disable all the customers
        private void DisableAllCustomerElements() {
            foreach (GameObject customerElement in customerElements) {
                customerElement.SetActive(false);
            }
        }

        // Update the current Customers
        private void UpdateElements() {
            List<Customer> customers = CustomerManager.Instance.currentCustomers.ToList();
            for (int i = 0; i < customers.Count; i++) {
                customerElements[i].SetActive(true);
                customerElements[i].GetComponent<CustomerElement>().SetCustomer(customers[i]);
            }
        }


        private void Awake() {
            Instance = this;
            DisableAllCustomerElements();
        }

        private void Update() {
            UpdateCustomerElements();
        }

        public void UpdateCustomerElements() {
            DisableAllCustomerElements();
            UpdateElements();
        }
    }
}