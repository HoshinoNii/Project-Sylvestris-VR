using System;
using Core.Utils;
using Game;
using TMPro;
using UnityEngine;

namespace UI {
    public class LevelDataUI : MonoBehaviour {
        public TextMeshProUGUI gameTime;
        public TextMeshProUGUI score;

        private void Update() {
            gameTime.text = $"TIME LEFT: {Utils.ConvertFloatToTime(LevelManager.Instance.timeLeft)}";
            score.text = $"CURRENT SCORE: {LevelManager.Instance.currentPoints}";
        }
    }
}
