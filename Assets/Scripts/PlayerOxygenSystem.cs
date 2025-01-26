using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityRandom = UnityEngine.Random;

namespace GGJ2025 {
	public class PlayerOxygenSystem : MonoBehaviour {

		[Header("Oxygen System Config")]
		public float oxygenLevel = 100f;
		public float oxygenDepletionRate = 1f;
		public float oxygenDepletionRateWhileRunning = 2f;
		public float oxygenRegenRate = 1f;

		private bool isInOxygen = false;


		[Header("Oxygen System UI")]
		//public Slider oxygenSlider;
		public TextMeshProUGUI oxygenText;

		private void Update() {
			if (isInOxygen) {
				oxygenLevel += oxygenRegenRate * Time.deltaTime;
			} else {
				oxygenLevel -= oxygenDepletionRate * Time.deltaTime;
			}

			oxygenLevel = Mathf.Clamp(oxygenLevel, 0, 100);

			//oxygenSlider.value = oxygenLevel;
			oxygenText.text = $"Oxygen Level: {oxygenLevel:F0}%";

			if (oxygenLevel <= 0) {
				Debug.Log("Player died");
			}
		}


		private void OnTriggerEnter(Collider other) {
			Debug.Log($"Trigger Enter: {other.gameObject.GetComponentInParent<Transform>().tag}");
			if (other.gameObject.GetComponent<Transform>().parent.tag == "OxyDome") {
				Debug.Log("Player entered oxygen");
				isInOxygen = true;
			}
		}

		private void OnTriggerExit(Collider other) {
			Debug.Log("Trigger Exit");
			if (other.gameObject.GetComponent<Transform>().parent.tag == "OxyDome") {
				Debug.Log("Player exited oxygen");
				isInOxygen = false;
			}
		}
	}
}