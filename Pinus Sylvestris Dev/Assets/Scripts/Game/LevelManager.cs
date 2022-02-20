using System;
using UnityEngine;

namespace Game {
    public class LevelManager : MonoBehaviour {
        public static LevelManager Instance { get; private set; }
        public int currentPoints;
        [SerializeField] private LevelState state;
        public float timeLeft;
        public bool executeOnce;

        public LevelState State {
            get => state;
            set {
                executeOnce = false;
                state = value;
            }
        }

        private void UpdateState() {
            switch (state) {
                case LevelState.PreGame:
                    PreGame();
                    break;
                case LevelState.Game:
                    Game();
                    break;
                case LevelState.GameOver:
                    GameOver();
                    break;
            }
        }
        
        


        private void PreGame() {
            if (executeOnce) return;
            executeOnce = true;
        }
        
        private void Game() {
            
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0) State = LevelState.GameOver;
            
            if (executeOnce) return;
            executeOnce = true;
            
        }
        
        private void GameOver() {
            if (executeOnce) return;
            executeOnce = true;
        }
        
        
        private void Awake() {
            Instance = this;
            State = LevelState.PreGame;
        }

        private void Update() {
            UpdateState();
        }
    }
}