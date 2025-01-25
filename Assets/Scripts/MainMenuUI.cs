using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityRandom = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GGJ2025
{
	public class MainMenuUI : MonoBehaviour
	{

        public Button playButton;
        public Button quitButton;

        private void Start()
        {
            playButton.onClick.AddListener(PlayGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}