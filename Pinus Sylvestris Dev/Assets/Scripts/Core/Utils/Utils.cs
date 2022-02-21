using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Utils {
    public static class Utils  {
        
        // Fade in/out
        public static IEnumerator Fade(float time, Material material, bool fadeOut)
        {
            // Fade to transparent
            while (fadeOut ? material.color.a > 0.0f : material.color.a < 1.0f) {
                material.color = new Color(material.color.r, material.color.g, material.color.b,
                    material.color.a - Time.unscaledDeltaTime / time);
                yield return null;
            }
        }
        
        // convert float value to Time String
        public static string ConvertFloatToTime(float value) {
            TimeSpan ts = TimeSpan.FromSeconds(value);
            return $"{ts.Minutes}:{ts.Seconds}";
        }

        // quit
        public static void Quit() {
            Application.Quit();
        }

        // scene restart
        public static void RestartScene() {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex ) ;
        }
    }
}