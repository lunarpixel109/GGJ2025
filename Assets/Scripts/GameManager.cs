using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace GGJ2025 {
	public class GameManager : MonoBehaviour {

		private float GameTime;
		private bool _isGameRunning;

        public OxygenGeneratorSystem[] oxygenBubbles;

		public GameObject playerObject;
		public GameObject loseUI;
		public GameObject winUI;

		private void Start() {
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

                if (_isGameRunning) {
                    GameTime += Time.deltaTime;
                }
            }

			if (allOn) {
				winUI.SetActive(true);
				playerObject.SetActive(false);
			}
		}

		public void LoseGame() {
			Debug.Log("Game Lost");
			loseUI.SetActive(true);
			playerObject.SetActive(false);
			_isGameRunning = false;
			if (PlayerPrefs.GetFloat("HighScore") < GameTime) {
				PlayerPrefs.SetFloat("HighScore", GameTime);
			}
		}
	}
}