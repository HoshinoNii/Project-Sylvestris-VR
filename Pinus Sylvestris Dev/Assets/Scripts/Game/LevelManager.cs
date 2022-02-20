using System;
using UnityEngine;

namespace Game {
    public class LevelManager : MonoBehaviour {
        public static LevelManager Instance { get; private set; }
        public int currentPoints;

        private LevelState _state;
        public LevelState State {
            get => _state;
            set {
                _state = value;
                UpdateState();
            }
        }

        private void UpdateState() {
            switch (_state) {
                case LevelState.PreGame:
                    break;
                case LevelState.Game:
                    break;
                case LevelState.GameOver:
                    break;
            }
        }

        private void Awake() {
            Instance = this;
        }

        private void Update() {
            
        }
    }
}