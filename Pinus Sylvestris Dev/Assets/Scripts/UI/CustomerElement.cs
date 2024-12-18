﻿using System;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class CustomerElement : MonoBehaviour {
        public Customer customerData;
        public TextMeshProUGUI name;
        public TextMeshProUGUI coffeeType;
        public Image image;
        public Image progressSlider;


        // Set the Customer Class
        public void SetCustomer(Customer customer) {
            customerData = customer;
        }

        // link up Customer Class data with the UI
        private void MapData() {
            if (customerData == null) return;
            name.text = customerData.name;
            coffeeType.text = customerData.coffee.ToString();
            image.sprite = customerData.coffeeImage;
            progressSlider.fillAmount = customerData.timeLeft / 100;
        }

        private void FixedUpdate() {
            MapData();
        }
    }
}
