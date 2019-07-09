using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarLaps : MonoBehaviour
{
    // All the characters that are in the game
    public static string Player = "Player";
    public static string Viper = "Viper";
    public static string Taxi = "Taxi";
    public static string Sanchez = "Sanchez";

    // Checkpoints of all carss [Player, Viper, Taxi, Orange]
    public static int amountOfPlayerCheckpoints = 0;
    public static int amountOfViperCheckpoints = 0;
    public static int amountOfTaxiCheckpoints = 0;
    public static int amountOfSanchezCheckpoints = 0;

    public Transform firstCheckpoint;
    public static Transform newTaxisCheckpoint, newSanchezCheckpoint;

    // Characters places in the map
    public Image firstPlace, secondPlace, thirdPlace, fourthPlace;
    public Text lapsText;

    // Staring line ups of the characters
    public static List<int> charactersAmount = new List<int>(new int[] { amountOfViperCheckpoints, amountOfPlayerCheckpoints, amountOfTaxiCheckpoints, amountOfSanchezCheckpoints });
    public static string[] places = { "Viper", "Player", "Taxi", "Sanchez" };

    void Start()
    {
        newTaxisCheckpoint = firstCheckpoint;
        newSanchezCheckpoint = firstCheckpoint;
    }

    void FixedUpdate()
    {
        RedoCharactersArray(); // We will redo characters array here

        for (int i = 0; i < charactersAmount.Count - 1; i++)
        {
            for (int j = i + 1; j < charactersAmount.Count; j++)
            {
                // If we find one characters amount of checkpoints is lower than the other
                if (charactersAmount[i] < charactersAmount[j])
                {
                    // First we swap the in the array called 'places', so we get a string array
                    SwapTwoCharacters(i, j);

                    // Swap the Images
                    SwapTheImages(i,j);

                    // Now by that same string array we redo characters array
                    RedoCharactersArray();
                }
            }
        }
        // We check if anyone won already
        CheckLaps();
    }

    public static void RedoCharactersArray()
    {
        // First we clear the list
        charactersAmount.Clear();

        // Then by the 'places' array we assign new values to the 'chareactersAmount' list
        for (int i = 0; i < places.Length; i++)
        {
            if (places[i] == Player)
                charactersAmount.Add(amountOfPlayerCheckpoints);
            else if (places[i] == Viper)
                charactersAmount.Add(amountOfViperCheckpoints);
            else if (places[i] == Taxi)
                charactersAmount.Add(amountOfTaxiCheckpoints);
            else if (places[i] == Sanchez)
                charactersAmount.Add(amountOfSanchezCheckpoints);
        }
    }

    // Swap two characters by the given Indexes
    public static void SwapTwoCharacters(int putIntoIndex, int putFromIndex)
    {
        string temp = places[putIntoIndex];
        places[putIntoIndex] = places[putFromIndex];
        places[putFromIndex] = temp;
    }

    public void SwapTheImages(int firstI, int secondI) // Function to swap the images
    {
        Image[] spritesArray = { firstPlace, secondPlace, thirdPlace, fourthPlace };
        var temp = spritesArray[firstI].sprite;
        spritesArray[firstI].sprite = spritesArray[secondI].sprite;
        spritesArray[secondI].sprite = temp;
    }

    void CheckLaps()
    {
        // If we pass one lap(or 13 checkpoints) we decrease lap count by one
        if (amountOfPlayerCheckpoints >= 13)
            lapsText.text = "1";

        for (int i = 0; i < charactersAmount.Count; i++)
        {
            // If anyone has more than all checkpoints or equal change the scene to winner
            if(charactersAmount[i] > 26)
                SceneManager.LoadScene("AfterGame");
        }
    }

    private void OnDestroy()
    {
        // Before we get destroyed, we save the first place
        PlayerPrefs.SetString("first-place", places[0]);
    }
}