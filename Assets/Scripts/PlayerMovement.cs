using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityRandom = UnityEngine.Random;

namespace GGJ2025 {
	public class PlayerMovement : MonoBehaviour {

		public InputAction moveAction;
		public InputAction lookAction;
		public InputAction jumpAction;

		public CharacterController controller;
		public Animator animator;

		public float moveSpeed = 5f;
		public float sensitivity = 100f;

		public Vector3 velocity;

		float xRotation = 0f;

		public InputSystem_Actions actions;

		public Transform cameraTransform;

		private void Start() {
			actions = new InputSystem_Actions();
			controller = GetComponent<CharacterController>();
			animator = GetComponent<Animator>();
			Cursor.lockState = CursorLockMode.Locked;

			actions.Enable();
		}

		private void Update() {
			Vector2 moveInput = actions.Player.Move.ReadValue<Vector2>() * (moveSpeed * Time.deltaTime);
			Vector2 lookInput = actions.Player.Look.ReadValue<Vector2>() * (sensitivity * Time.deltaTime);

			xRotation -= lookInput.y;
			xRotation = Mathf.Clamp(xRotation, -90f, 90f);

			transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
			transform.Rotate(Vector3.up, lookInput.x * sensitivity * Time.deltaTime);


		}
	}
}