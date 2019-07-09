using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCheckPoint : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        //If its not player, then do nothing
        if (!other.CompareTag("Player"))
            return;

        if (transform == PlayerHandler.checkpointA[PlayerHandler.currentCheckpoint].transform)
        {
            //Check so we dont exceed our checkpoint quantity
            if (PlayerHandler.currentCheckpoint + 1 < PlayerHandler.checkpointA.Length)
            {
                //Add to currentLap if currentCheckpoint is 0
                if (PlayerHandler.currentCheckpoint == 0)
                    PlayerHandler.currentLap++;
                PlayerHandler.currentCheckpoint++;
            }
            else
            {
                //If we dont have any Checkpoints left, go back to 0
                PlayerHandler.currentCheckpoint = 0;
            }

            // Everytime that character collides the checkpoint we will update characters checkpoint number
            CarLaps.amountOfPlayerCheckpoints += 1;

        }
    }
}
