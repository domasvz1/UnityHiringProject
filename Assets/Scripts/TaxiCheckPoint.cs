using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TaxiCheckPoint : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If its not game object with the tag "Taxi" then do nothing
        if (!collision.CompareTag("Taxi"))
            return;

        if (transform == TaxiHandler.checkpointA[TaxiHandler.currentCheckpoint].transform)
        {
            //Check so we dont exceed our checkpoint quantity
            if (TaxiHandler.currentCheckpoint + 1 < TaxiHandler.checkpointA.Length)
            {
                //Add to currentLap if currentCheckpoint is 0
                if (TaxiHandler.currentCheckpoint == 0)
                    TaxiHandler.currentLap++;
                TaxiHandler.currentCheckpoint++;
            }
            else
            {
                //If we dont have any Checkpoints left, go back to 0
                TaxiHandler.currentCheckpoint = 0;
            }

            // Everytime we make sure that checkpints change too
            CarLaps.newTaxisCheckpoint = TaxiHandler.checkpointA[TaxiHandler.currentCheckpoint];

            // Everytime that character collides the checkpoint we will update characters checkpoint number
            CarLaps.amountOfTaxiCheckpoints += 1;
        }
    }
}
