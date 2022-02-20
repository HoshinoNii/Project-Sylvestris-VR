using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI {
    public class BaristaUI : MonoBehaviour {
        
        [SerializeField] private List<GameObject> texts = new List<GameObject>();
        private BaristaMachine.BaristaMachine BaristaMachine => GetComponentInParent<BaristaMachine.BaristaMachine>();

        private void HideAllObjects() {
            foreach (GameObject text in texts) {
                text.GetComponentInChildren<TextMeshProUGUI>().text = "";
                text.SetActive(false);
            }
        }
        private void FixedUpdate() {
            UpdateUI();
           
        }

        private void UpdateUI() {
            HideAllObjects();
            for (int i = 0; i < BaristaMachine.Ingredients.Count; i++) {
                texts[i].SetActive(true);
                texts[i].GetComponentInChildren<TextMeshProUGUI>().text = BaristaMachine.Ingredients[i];
            }
        }
    }
}
