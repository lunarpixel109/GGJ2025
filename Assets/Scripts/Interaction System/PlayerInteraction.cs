using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityRandom = UnityEngine.Random;

namespace GGJ2025.InteractionSystem {
	[ExecuteInEditMode]
	public class PlayerInteraction : MonoBehaviour {

		public float maxInteractionDistance = 5f;
		public Vector3 interactionOffset;

		public bool canInteract;
		public InteractableObject other;


		private void Update() {

			if (Input.GetKeyDown(KeyCode.E) && canInteract && other != null) {
				other.Interact();
			}

		}

		private void OnTriggerEnter(Collider other) {
			this.other = other.GetComponent<InteractableObject>();
			if (other != null) {
				canInteract = true;
			}
		}

		private void OnTriggerExit(Collider other) {
			this.other = null;
			canInteract = false;
		}
	}
}