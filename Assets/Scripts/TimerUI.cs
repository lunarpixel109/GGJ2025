using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace GGJ2025 {
	public class TimerUI : MonoBehaviour {

		public TextMeshProUGUI levelTimerText;
		public TextMeshProUGUI bestTimeText;

		public GameObject newBestTime;

		public int level;
		public bool isInGame = false;

		//public GameManager gameManager;

		private void Start() {
		//	gameManager = FindAnyObjectByType<GameManager>();

			TimeSpan currentTime = TimeSpan.FromSeconds(PlayerPrefs.GetFloat($"CurrentScore{level}", 754.456f));
			TimeSpan bestTime = TimeSpan.FromSeconds(PlayerPrefs.GetFloat($"HighScore{level}", 754.456f));

			//float time = PlayerPrefs.GetFloat($"CurrentScore{level}", 0);

			if (currentTime == bestTime) {
				newBestTime.SetActive(true);
			}


			levelTimerText.text = $"Time: {currentTime.Minutes:D2}:{currentTime.Seconds:D2}.{currentTime.Milliseconds:D3}";
			bestTimeText.text = $"Best Time: {bestTime.Minutes:D2}:{bestTime.Seconds:D2}.{bestTime.Milliseconds:D3}";
		}


	}
}