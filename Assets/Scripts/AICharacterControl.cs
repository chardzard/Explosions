using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson {
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour {
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for

        public int health = 3;
        public GameController controller;
        public GameObject explosion;

        private bool isDead = false;

        private void Start() {
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;
            agent.updatePosition = true;
        }


        private void Update() {
            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }


        public void SetTarget(Transform target) {
            this.target = target;
        }

        public void Damage(int damage) {
            health -= damage;
            if (health <= 0 && !isDead) {
                isDead = true;
                Destroy(gameObject);
                controller.IncreaseScore(1);
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
        }
    }
}
