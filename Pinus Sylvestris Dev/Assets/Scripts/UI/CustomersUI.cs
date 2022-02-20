using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

namespace UI {
    public class CustomersUI : MonoBehaviour {
        public static CustomersUI Instance { get; private set; }
        public List<GameObject> customerElements = new List<GameObject>();

        private void DisableAllCustomerElements() {
            foreach (GameObject customerElement in customerElements) {
                customerElement.SetActive(false);
            }
        }

        private void UpdateElements() {
            List<Customer> customers = CustomerManager.Instance.currentCustomers;
            for (int i = 0; i < customers.Count; i++) {
                customerElements[i].SetActive(true);
                customerElements[i].GetComponent<CustomerElement>().SetCustomer(customers[i]);
            }
        }


        private void Awake() {
            Instance = this;
            DisableAllCustomerElements();
        }

        public void UpdateCustomerElements() {
            DisableAllCustomerElements();
            UpdateElements();
        }
    }
}