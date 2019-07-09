using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ViperCheckPoint : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        //If its not game obejct with the tag "Viper" then do nothing
        if (!other.CompareTag("Viper"))
            return;

        if (transform == ViperHandler.checkpointA[ViperHandler.currentCheckpoint].transform)
        {
            //Check so we dont exceed our checkpoint quantity
            if (ViperHandler.currentCheckpoint + 1 < ViperHandler.checkpointA.Length)
            {
                //Add to currentLap if currentCheckpoint is 0
                if (ViperHandler.currentCheckpoint == 0)
                    ViperHandler.currentLap++;
                ViperHandler.currentCheckpoint++;
            }
            else
            {
                //If we dont have any Checkpoints left, go back to 0
                ViperHandler.currentCheckpoint = 0;
            }

            // Everytime that character collides the checkpoint we will update characters checkpoint number
            CarLaps.amountOfViperCheckpoints += 1;   
        }
    }
}
