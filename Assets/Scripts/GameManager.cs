using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityRandom = UnityEngine.Random;

namespace GGJ2025 {
	public class GameManager : MonoBehaviour {

		public float GameTime { get; private set; }
		private bool _isGameRunning;

        public OxygenGeneratorSystem[] oxygenBubbles;

		public GameObject playerObject;
		public GameObject loseUI;
		public GameObject winUI;

		public TextMeshProUGUI timerText;

		private void Start() {
			Cursor.lockState = CursorLockMode.Locked;
			_isGameRunning = true;
			oxygenBubbles = FindObjectsByType<OxygenGeneratorSystem>(FindObjectsInactive.Include, FindObjectsSortMode.None);
			if (oxygenBubbles.Length == 0) {
				throw new Exception("No Oxygen Bubbles found in scene");
			}
		}

		private void Update() {
			bool allOn = true;
			foreach (OxygenGeneratorSystem bubble in oxygenBubbles) {
				if (!bubble.oxyDome.activeInHierarchy) {
					allOn = false;
					break;
				}

            }

			if (_isGameRunning) {
                GameTime += Time.deltaTime;
            }

			TimeSpan currentTime = TimeSpan.FromSeconds(GameTime);
			timerText.text = $"Time: {currentTime.Minutes:D2}:{currentTime.Seconds:D2}.{currentTime.Milliseconds:D3}";

			if (allOn) {
				winUI.SetActive(true);
				playerObject.SetActive(false);
				PlayerPrefs.SetFloat($"CurrentScore{SceneManager.GetActiveScene().buildIndex}", GameTime);
				if (PlayerPrefs.GetFloat($"HighScore{SceneManager.GetActiveScene().buildIndex}", float.MaxValue) < GameTime) {
					PlayerPrefs.SetFloat($"HighScore{SceneManager.GetActiveScene().buildIndex}", GameTime);
				}
				PlayerPrefs.Save();
				_isGameRunning = false;
			}
		}

		public void LoseGame() {
			Debug.Log("Game Lost");
			loseUI.SetActive(true);
			playerObject.SetActive(false);
			_isGameRunning = false;
		}
	}
}