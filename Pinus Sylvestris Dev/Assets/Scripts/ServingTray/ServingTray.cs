using Core.Audio;
using Game;
using Inventory;
using UnityEngine;
using AudioType = Core.Audio.Enums.AudioType;

namespace ServingTray {
    public class ServingTray : UseItemOnThis {
        public override void FirstUnlockInstance() {
            ServeCustomer();
        }

        public override void SubsequentActivation_IfAny() {
            ServeCustomer();
        }

        private void ServeCustomer() {
            CoffeeItem item = Inventory.Inventory.Instance.SelectedItem.GetComponent<CoffeeItem>();
            if (!item) return;
            SfxManager.Play(AudioType.SfxInteractWithServingTray);
            CustomerManager.Instance.ServeCustomer(item.coffeeType);
            SetItemAsUsed();
        }
    }
}