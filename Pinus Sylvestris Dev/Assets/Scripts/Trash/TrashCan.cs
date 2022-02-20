using Core.Audio;
using Inventory;
using UnityEngine;
using AudioType = Core.Audio.Enums.AudioType;

namespace Trash {
    public class TrashCan : UseItemOnThis
    {
        public override void FirstUnlockInstance() {
            TrashItem();
        }

        public override void SubsequentActivation_IfAny() {
            TrashItem();
        }

        private void TrashItem() {
            SfxManager.Play(AudioType.SfxInteractWithTrashCan);
            SetItemAsUsed();
        }
    }
}
