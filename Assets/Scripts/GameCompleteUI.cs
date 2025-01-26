using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityRandom = UnityEngine.Random;

namespace GGJ2025 {
	public class GameCompleteUI : MonoBehaviour {

		public Button mainMenuButton;
		public Button quitButton;

		private void Start() {
			mainMenuButton.onClick.AddListener(MainMenu);
			quitButton.onClick.AddListener(QuitGame);
		}

		public void MainMenu() {
			SceneManager.LoadScene(0);
		}

		public void QuitGame() {
			Application.Quit();
		}

	}
}