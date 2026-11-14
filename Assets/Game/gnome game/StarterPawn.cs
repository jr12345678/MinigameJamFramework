using System;
using System.Collections;
using System.Collections.Generic;
using Game.MinigameFramework.Scripts.Framework.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GnomeGame {
    public class StarterPawn : Pawn {
        Vector2 _moveInput = Vector2.zero;
        Boolean gnome = true;
        Rigidbody p;
        void Start() {
            p = GetComponent<Rigidbody>();
        }
        void Update() {
            // TODO: Implement movement

            p.AddForce(new Vector3(_moveInput.normalized.x, 0, 0));
                
        }

        protected override void OnActionPressed(InputAction.CallbackContext context) {

            if (gnome) {
                if (context.action.name == PawnAction.Move) {
                    _moveInput = context.ReadValue<Vector2>();
                    print("hi");

                    if (context.action.name == PawnAction.ButtonA) {
                        // Jump
                    }

                    if (context.action.name == PawnAction.ButtonB) {
                        // Shoot
                    }
                } else {//if robot
                    if (context.action.name == PawnAction.Move) {
                        _moveInput = context.ReadValue<Vector2>();
                    }

                    if (context.action.name == PawnAction.ButtonA) {
                        // Jump
                    }

                    if (context.action.name == PawnAction.ButtonB) {
                        // Shoot
                    }
                }
            }
        }
        protected override void OnActionReleased(InputAction.CallbackContext context) {
            if (context.action.name == PawnAction.ButtonB) {
                // Stop shooting
            }
        }
    }
}