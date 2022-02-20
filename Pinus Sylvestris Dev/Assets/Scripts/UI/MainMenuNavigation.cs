using System;
using Core.Audio;
using Core.Utils;
using Game;
using Location;
using UnityEngine;
using AudioType = Core.Audio.Enums.AudioType;

namespace UI {
    public class MainMenuNavigation : MonoBehaviour {
        
        [Header("Screens")]
        public GameObject creditsScreen;
        public GameObject mainMenuScreen;
        public GameObject instructionsScreen;

        private void DisableAll() {
            creditsScreen.SetActive(false);
            mainMenuScreen.SetActive(false);
            instructionsScreen.SetActive(false);
        }

        private void Start() {
            DisableAll();
            mainMenuScreen.SetActive(true);
            AudioManager.Instance.StopAll();
            AudioManager.Instance.PlayAudio(AudioType.BgmMainMenu, true, 2f, 0f, .2f, true);
        }

        private void Update() {
            // Google Cardboard "X" Button Trigger
            if(Input.GetKeyDown(KeyCode.Escape)){
                Utils.Quit();   
            }
        }

        
        // start the game
        public void Play() {
            SfxManager.Play(AudioType.SfxUIButtonClick);
            LocationManager.Instance.GotoLocation(LocationType.MainTable);
            LevelManager.Instance.StartGame();
        }
        
        // Show credits gameobject
        public void ShowCredits() {
            DisableAll();
            SfxManager.Play(AudioType.SfxUIButtonClick);
            creditsScreen.SetActive(true);
            AudioManager.Instance.StopAll();
            AudioManager.Instance.PlayAudio(AudioType.BgmCredits, true, 2f, 0f, .2f, true);
        }

        // Show main menu gameobject
        public void ShowMainMenu() {
            DisableAll();
            SfxManager.Play(AudioType.SfxUIButtonClick);
            mainMenuScreen.SetActive(true);
            AudioManager.Instance.StopAll();
            AudioManager.Instance.PlayAudio(AudioType.BgmMainMenu, true, 2f, 0f, .2f, true);
        }

        // show instructions gameobject
        public void ShowInstructions() {
            DisableAll();
            SfxManager.Play(AudioType.SfxUIButtonClick);
            instructionsScreen.SetActive(true);
        }
    }
}