using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityRandom = UnityEngine.Random;


namespace GGJ2025.InteractionSystem {
    public class OxygenGenerator: InteractableObject {

        //public OxygenGeneratorSystem system;
        public ParticleSystem[] brokenParticles;

        private void Start() {
            brokenParticles = GetComponentsInChildren<ParticleSystem>();
        }

        public override void Interact() {
            gameObject.tag = "EnabledOxygenGenerator";
            foreach (ParticleSystem particle in brokenParticles) {
                particle.gameObject.SetActive(false);
            }
        }
    }
}