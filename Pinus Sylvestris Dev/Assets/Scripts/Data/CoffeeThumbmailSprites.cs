using System;
using UnityEngine;

namespace Data {
    public class CoffeeThumbmailSprites : MonoBehaviour {
        public Sprite[] images;
        public static CoffeeThumbmailSprites Instance { get; private set; }

        private void Awake() {
            Instance = this;
        }
    }
}