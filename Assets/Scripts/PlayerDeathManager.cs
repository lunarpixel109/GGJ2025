using System;
using Cinemachine;
using UnityEngine;

namespace GGJ2025 {
    public class PlayerDeathManager : MonoBehaviour {

        [TagField] public string deathTag = "Death";

        public GameManager gameManager;

        private void Start() {
            //gameManager = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag(deathTag)) {
                gameManager.LoseGame();
            }
        }
    }
}