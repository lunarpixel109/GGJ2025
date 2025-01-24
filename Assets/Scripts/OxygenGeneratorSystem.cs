using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GGJ2025.InteractionSystem;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace GGJ2025 {
	public class OxygenGeneratorSystem : MonoBehaviour {

		public GameObject oxyDome;

		public OxygenGenerator[] generators;

		bool isOn = false;

		private void Start() {
			generators = GetComponentsInChildren<OxygenGenerator>();
		}


		private void Update() {
			bool allOn = true;
			foreach (OxygenGenerator generator in generators) {
				if (generator.gameObject.tag != "EnabledOxygenGenerator") {
					allOn = false;
					break;
				}
			}

			if (allOn) {
				oxyDome.SetActive(true);
			}
		}
	}
}