using System;
using Core.Utils;
using Location;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class PauseControl : MonoBehaviour {
        public bool isPaused;
        public GameObject pauseScreen;
        public Button pauseButton;

        [Header("Pause Screen Elements")] 
        public Button resumeButton;
        public Button mainMenuButton;
        public Button restartButton;

        private void Awake() {
            pauseScreen.SetActive(false);
            pauseButton.onClick.AddListener(Pause);
            resumeButton.onClick.AddListener(Resume);
            mainMenuButton.onClick.AddListener(MainMenu);
            restartButton.onClick.AddListener(Restart);
        }

        public void Pause() {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }

        public void Restart() {
            Time.timeScale = 1;
            Utils.RestartScene();
        }
        
        public void Resume() {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }

        public void MainMenu() {
            Time.timeScale = 1;
            Utils.RestartScene();
        }
    }
}
