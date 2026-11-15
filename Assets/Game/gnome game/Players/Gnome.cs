using UnityEngine;

namespace GnomeGame {
    public class Gnome : MonoBehaviour
    {
        // Parameters
        [SerializeField] private float jumpForce = 6;
        [SerializeField] private float moveSpeed = 2;

        // Movement logic
        bool grounded = true;
        Rigidbody p;
        Vector2 moveInput = Vector2.zero;

        private GnomeGameManager manager;
        private int pawnIndex;

        void Start() {
            p = GetComponent<Rigidbody>();
            manager = FindAnyObjectByType<GnomeGameManager>();
        }

        public void SetPlayerColor(int playerIndex) {
            Color[] playerColors = new Color[] { Color.blue, Color.red, Color.green, Color.yellow };

            // TODO update color indicator in some way

            pawnIndex = playerIndex;
        }

// =====================================================================================================
        // Applies movement input
        void Update() {
            p.AddForce(new Vector3(moveInput.normalized.x, 0, 0) * moveSpeed);
        }

        // sets the movement input to the provided
        public void SetMovement(Vector2 newInput) {
            moveInput = newInput;
        }

        // triggers a jump if able
        public void TriggerJump() {
            if (grounded) {
                p.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }

// =====================================================================================================
        // Handles grounded detection for gnomes
        // Ground layer is 10
        // Additionally should respond to being hit by water
        // Water should be on layer 15 "Projectile"
        void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.layer == 10) {
                grounded = true;
            }
            if (collision.gameObject.layer == 15) {
                Die();
            }
        }

        // Handles grounded exit detection for gnomes
        // Ground layer is 10
        void OnCollisionExit(Collision collision) {
            if (collision.gameObject.layer == 10) {
                grounded = false;
            }
        } 
        
// =====================================================================================================
        //Kills and removes a gnome
        private void Die() {
            manager.GnomeDeath(pawnIndex);
            Destroy(this);
        }
    }
}