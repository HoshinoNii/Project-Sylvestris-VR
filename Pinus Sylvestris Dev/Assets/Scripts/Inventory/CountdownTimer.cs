using UnityEngine;
using UnityEngine.UI;

namespace Inventory {
    public class CountdownTimer : MonoBehaviour {
        public float timeRemaining = 10;
        public bool autoStart = false;
        public Text uiTimer;

        public GameObject theEnd, timerEndText, paused;
        public AudioSource audio;
        public AudioClip clip, pauseclip;

        [HideInInspector] public bool timerIsRunning = false;

        private void Start() {
            if (autoStart) timerIsRunning = true;
        }

        public void StartTimer() {
            timerIsRunning = true;
        }

        public void TogglePauseTimer() {
            timerIsRunning = !timerIsRunning;


            if (timerIsRunning) {
                //add code here
                paused.SetActive(false);
            } else {
                //add code here
                paused.SetActive(true);

                //pause audio
                if (audio) {
                    audio.Stop();
                    audio.PlayOneShot(pauseclip);
                }
            }
        }

        public void TimerRunOut() {
            theEnd.SetActive(true);
            timerEndText.SetActive(true);
            audio.Stop();
            audio.PlayOneShot(clip);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                TogglePauseTimer();
            }

            if (timerIsRunning) {
                if (timeRemaining > 0) {
                    timeRemaining -= Time.deltaTime;
                    float minutes = Mathf.FloorToInt(timeRemaining / 60);
                    float seconds = Mathf.FloorToInt(timeRemaining % 60);
                    if (uiTimer) uiTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                } else {
                    TimerRunOut();
                    timeRemaining = 0;
                    float minutes = Mathf.FloorToInt(timeRemaining / 60);
                    float seconds = Mathf.FloorToInt(timeRemaining % 60);
                    if (uiTimer) uiTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                    timerIsRunning = false;
                }
            }
        }
    }
}