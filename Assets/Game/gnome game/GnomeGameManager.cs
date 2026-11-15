using System.Collections;
using System.Collections.Generic;
using Game.MinigameFramework.Scripts.Framework.PlayerInfo;
using UnityEngine;

namespace GnomeGame {
    public class GnomeGameManager : MonoBehaviour {
        private MinigameManager.Ranking _ranking = new();

        [SerializeField] List<AssignerPawn> _pawns;

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
        }

        public void EndMinigame() {
            // TODO: Determine player rankings
            MinigameManager.instance.EndMinigame(_ranking);
        }
    }
}