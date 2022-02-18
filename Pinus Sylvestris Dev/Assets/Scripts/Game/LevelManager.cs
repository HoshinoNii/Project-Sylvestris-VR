﻿using System;
using UnityEngine;

namespace Game {
    public enum LevelState {
        PreGame,
        Game,
        GameOver,
    }
    
    public class LevelManager : MonoBehaviour {
        public static LevelManager Instance { get; private set; }

        private LevelState state;
        public LevelState State {
            get => state;
            set {
                state = value;
                UpdateState();
            }
        }

        private void UpdateState() {
            switch (state) {
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