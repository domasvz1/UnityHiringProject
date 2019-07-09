using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBeforeGame : MonoBehaviour {

    public Text editableText;
    bool blinking = true;
    string checkedText = " Qualifying " + "\n" + "Race"; // The initial text
    WaitForSeconds waitForBlinking = new WaitForSeconds(0.25f); // The blinking will occur every 0.25 of the second
    public int timesForTextBlink; // The limit of blinking ticks = 0.25seconds * 12, will be 3 seconds, after that the blinkng needs to stop
    int secondsCounter = 0; // counter of ticks that wll need to reach the limit and tell us when to stop the loop

    IEnumerator Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicScript>().StopMusic();
        while (blinking)
        {
            if (checkedText == " Qualifying " + "\n" + "Race")
                checkedText = "";
            else if (checkedText == "")
                checkedText = " Qualifying " + "\n" + "Race";

            editableText.text = checkedText;
            secondsCounter += 1;
            yield return waitForBlinking;
            if (secondsCounter >= timesForTextBlink)
                blinking = false;
        }
    }    
}
