using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace UnityStandardAssets.Effects {
    public class ExplosionPhysicsForce : MonoBehaviour {
        public float explosionForce = 4;


        private IEnumerator Start() {
            // wait one frame because some explosions instantiate debris which should then
            // be pushed by physics force
            yield return null;

            float multiplier = GetComponent<ParticleSystemMultiplier>().multiplier;

            float r = 10 * multiplier;
            var cols = Physics.OverlapSphere(transform.position, r);
            var rigidbodies = new List<Rigidbody>();
            foreach (var col in cols) {
                if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody)) {
                    rigidbodies.Add(col.attachedRigidbody);
                }
                AICharacterControl AI = col.GetComponent<AICharacterControl>();
                if (AI != null) {
                    AI.Damage(1);
                }
            }
            foreach (var rb in rigidbodies) {
                rb.AddExplosionForce(explosionForce * multiplier, transform.position, r, 0, ForceMode.Impulse);
            }
            StartCoroutine(destroy());
        }

        IEnumerator destroy() {
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }
    }    
}
