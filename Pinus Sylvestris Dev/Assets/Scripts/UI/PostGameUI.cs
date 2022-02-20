﻿using System;
using Core.Utils;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI {
    public class PostGameUI : MonoBehaviour {
        public TextMeshProUGUI scoreText;
        public Button restartButton;
        public Button quitButton;


        private void Awake() {
            quitButton.onClick.AddListener(Utils.Quit);
            restartButton.onClick.AddListener(() => {
                SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
            });
        }

        private void FixedUpdate() {
            scoreText.text = LevelManager.Instance.currentPoints.ToString();
        }
    }
}