using System;
using System.Collections;
using System.Collections.Generic;
using Game.MinigameFramework.Scripts.Framework.PlayerInfo;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GnomeGame {
    public class GnomeGameManager : MonoBehaviour {
        private MinigameManager.Ranking _ranking = new();

        [SerializeField] List<AssignerPawn> _pawns;
        private double timer = 30.0;
        private int deaths = 0;

        // Picks which player to be the robot and sets the rest to gnomes
        void Start() {
            // decide on who is the robot
            int robotIndex = Random.Range(0, PlayerManager.GetNumPlayers() - 1);
            print("Player " + robotIndex + " has been made the robot!");

            // Tell each pawn the assignment
            for (int i = 0; i < PlayerManager.GetNumPlayers(); i++) {
                AssignerPawn pawn = _pawns[i];
                pawn.AssignPlayerType(robotIndex);
            }

            // TODO: begin timer
            timer = 30.0;
        }

        void Update() {
            if (timer > 0.0) {
                timer -= Time.deltaTime;
                // TODO: adjust some sort of timer visual
                if (timer <= 0.0) {
                    EndMinigame();
                }
            }
        }

        public void GnomeDeath(int pawnIndex) {
            // Give each knocked out gnome the next-worst rank
            _ranking[pawnIndex] = PlayerManager.GetNumPlayers() - deaths;
            deaths += 1;
            // Once all gnomes have died, end the game for a robot victory
            if (deaths == PlayerManager.GetNumPlayers() - 1) {
                EndMinigame();
            }
        }

        public void EndMinigame() {
            // If the timer ended, assign new rankings based on player type
            if (timer <= 0.0) {
                for (int i = 0; i < PlayerManager.GetNumPlayers(); i++) {
                    // Player is a surviving gnome and gets first place
                    print("setting scores");
                    if (_pawns[i].IsGnome()) {
                        _ranking[i] = 1;
                    }
                    // Player is the robot, and gets last because the timer ran out
                    else if (_pawns[i].IsRobot()) {
                        _ranking[i] = PlayerManager.GetNumPlayers();
                    } 
                    // Player was formerly a gnome that was killed and made null
                    // Their ranking should be changed by 1 to be better than the robot
                    else {
                        _ranking[i] -= 1;
                    }
                }
            } 
            // If the timer did not end, all gnomes are dead and the robot gets first
            // Gnomes should have had their rankings assigned upon death
            else {
                for (int i = 0; i < PlayerManager.GetNumPlayers(); i++) {
                    if (_pawns[i].IsRobot()) {
                        _ranking[i] = 1;
                    }
                }
            }
            
            MinigameManager.instance.EndMinigame(_ranking);
        }
    }
}