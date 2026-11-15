using Game.MinigameFramework.Scripts.Framework.PlayerInfo;
using UnityEngine;

namespace GnomeGame {
    public class Robot : MonoBehaviour
    {
        // Parameters
        [SerializeField] private float moveSpeed = 2;

        // References
        [SerializeField] SpriteRenderer crosshairSprite;

        // Movement logic
        Rigidbody p;
        Vector2 moveInput = Vector2.zero;

        // Spraying logic
        bool spraying = false;

        void Start() {
            p = GetComponent<Rigidbody>();
        }

        public void SetPlayerColor(int playerIndex) {
            Color[] playerColors = new Color[] { Color.blue, Color.red, Color.green, Color.yellow };

            crosshairSprite.color = playerColors[playerIndex];
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