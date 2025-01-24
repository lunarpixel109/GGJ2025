using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityRandom = UnityEngine.Random;

namespace GGJ2025.InteractionSystem {
	public class PlayerInteraction : MonoBehaviour {

		public float maxInteractionDistance = 1.5f;

		private InputAction interactAction;

		private void Start() {
			interactAction.performed += _ => Interact();
			
		}

		private void Interact() {
			Debug.Log("Interact");
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward, out hit, maxInteractionDistance)) {
				InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
				if (interactable != null) {
					Debug.Log(interactable.name);
					interactable.Interact();
				}
			}
		}
	}
}