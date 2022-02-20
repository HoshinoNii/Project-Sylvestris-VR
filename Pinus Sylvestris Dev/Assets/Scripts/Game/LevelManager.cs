using System;
using System.Collections;
using Core.Audio;
using Core.Utils;
using Location;
using UnityEngine;
using AudioType = Core.Audio.Enums.AudioType;

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
                // executeOnce = false;
                state = value;
                UpdateState();
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
            // if (executeOnce) return;
            // executeOnce = true;
        }
        
        private void Game() {
            
            
            
            // if (executeOnce) return;
            // executeOnce = true;
            
        }
        
        
        
        private void GameOver() {
            // if (executeOnce) return;
            // executeOnce = true;
            StartCoroutine(CoroEndGame());
        }
        
        
        private void Awake() {
            Instance = this;
            State = LevelState.PreGame;
        }

        private void Update() {
            if (State != LevelState.Game) return;
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0) State = LevelState.GameOver;
        }

        public void StartGame() {
            StartCoroutine(CoroStartGame());
        }

        
        
        // Coroutine for Start Game
        IEnumerator CoroStartGame() {
            AudioManager.Instance.StopAll();
            AudioManager.Instance.PlayAudio(AudioType.BgmGame, true, 2f, 0f, .2f, true);
            yield return new WaitForSecondsRealtime(3f);
            State = LevelState.Game;
        }

        // Coroutine for Game Over
        IEnumerator CoroEndGame() {
            AudioManager.Instance.StopAll();
            AudioManager.Instance.PlayAudio(AudioType.BgmPostGame, true, 2f, 0f, .2f, true);
            yield return new WaitForSecondsRealtime(1f);
            LocationManager.Instance.GotoLocation(LocationType.EndGame);
        }
    }
}