using Game.MinigameFramework.Scripts.Framework.PlayerInfo;
using System.Timers;
using UnityEditor.UI;
using UnityEngine;

namespace GnomeGame {
    public class Robot : MonoBehaviour
    {
        // Parameters
        [SerializeField] private float moveSpeed = 2;

        // References
        [SerializeField] SpriteRenderer crosshairSprite;

        SprayTimer t;

        // Movement logic
        Rigidbody p;
        Vector2 moveInput = Vector2.zero;

        // Spraying logic
        bool spraying = false;

        void Start() {
            p = GetComponent<Rigidbody>();
            t = GetComponent<SprayTimer>();
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
                if (!t.ticking) {
                    print("baller");
                    t.startTimer();
                }
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