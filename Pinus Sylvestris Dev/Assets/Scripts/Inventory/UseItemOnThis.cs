﻿using Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory {
    public class UseItemOnThis : MonoBehaviour, IPointerUpHandler {
        
        public ItemType itemType;
        public bool anyTypeCanGoIn;

        private void Start() { }

        public virtual void DoesntWork() { }

        public virtual void FirstUnlockInstance() { }

        public virtual void SubsequentActivation_IfAny() { }

        public void SetItemAsUsed() {
            Inventory.Instance.UsedItem();
            if (GetComponent<Used>() == null) this.gameObject.AddComponent<Used>();
        }

        public void OnPointerUp(PointerEventData eventData) {
            if (Inventory.Instance.SelectedItem) {
                
                if (anyTypeCanGoIn) {
                    FirstUnlockInstance();
                    return;
                }
                
                if (Inventory.Instance.SelectedItem.itemType == itemType &&
                    GetComponent<Used>() == null) //!Inventory.Instance.SelectedItem.Unlocked)
                {
                    FirstUnlockInstance();
                } else {
                    if (GetComponent<Used>()) {
                        SubsequentActivation_IfAny();
                    } else
                        DoesntWork();
                }
            } else {
                if (GetComponent<Used>()) {
                    SubsequentActivation_IfAny();
                } else {
                    DoesntWork();
                }
            }
        }
    }
}