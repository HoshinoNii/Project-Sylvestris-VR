using System;
using Core.Audio;
using Core.Utils;
using Location;
using UnityEngine;
using UnityEngine.UI;
using AudioType = Core.Audio.Enums.AudioType;

namespace UI {
    public class PauseControl : MonoBehaviour {
        public bool isPaused;
        public GameObject[] pauseScreens;
        public Button pauseButton;

        [Header("Pause Screen Elements")] 
        public Button resumeButton;
        public Button mainMenuButton;
        public Button restartButton;

        // Init the functions and attach the functions
        private void Awake() {
            SetPauseScreenStates(false);
            pauseButton.onClick.AddListener(Pause);
            resumeButton.onClick.AddListener(Resume);
            mainMenuButton.onClick.AddListener(MainMenu);
            restartButton.onClick.AddListener(Restart);
        }

        private void SetPauseScreenStates(bool state) {
            foreach (GameObject pauseScreen in pauseScreens) {
                pauseScreen.SetActive(state);
            }
        }
        
        public void Pause() {
            SetPauseScreenStates(true);
            Time.timeScale = 0;
            AudioManager.Instance.StopAudio(AudioType.BgmGame, false, 0f, 0f, .2f);
        }

        public void Restart() {
            Time.timeScale = 1;
            Utils.RestartScene();
        }
        
        public void Resume() {
            Time.timeScale = 1;
            SetPauseScreenStates(false);
            AudioManager.Instance.Resume(AudioType.BgmGame, false, 0f, 0f, .2f);
        }

        public void MainMenu() {
            Time.timeScale = 1;
            Utils.RestartScene();
        }
    }
}
