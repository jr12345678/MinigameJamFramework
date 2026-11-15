using UnityEngine;

namespace GnomeGame {
    public class Robot : MonoBehaviour
    {
        // Parameters
        [SerializeField] private float moveSpeed = 2;

        // Movement logic
        Rigidbody p;
        Vector2 moveInput = Vector2.zero;

        // Spraying logic
        bool spraying = false;

        void Start() {
            p = GetComponent<Rigidbody>();
        }

// =====================================================================================================
        // Applies movement input
        void Update() {
            // apply movement
            p.AddForce(new Vector3(moveInput.x, moveInput.y, 0).normalized * moveSpeed);

            if (spraying) {
                print("Robot is spraying");
            }
        }

        // sets the movement input to the provided
        public void SetMovement(Vector2 newInput) {
            moveInput = newInput;
        }

        // sets spraying boolean
        public void SetSpraying(bool setTo = true) {
            spraying = setTo;
        }
    }
}