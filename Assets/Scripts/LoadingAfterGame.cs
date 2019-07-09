using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingAfterGame : MonoBehaviour
{
    public Text editableText;
    bool blinking = true;
    WaitForSeconds waitForBlinking = new WaitForSeconds(0.1f); // The blinking will occur every 0.15 of the second
    public int timesForTextToBlink; // The limit of blinking ticks = 0.15 * 20, will be 3 seconds, after that the blinkng needs to stop
    int secondsCounter = 0; // counter of ticks that wll need to reach the limit and tell us when to stop the loop

    IEnumerator Start()
    {
        // if there's no key "first-place" with value, we return "no places"
        editableText.text = PlayerPrefs.GetString("first-place", "no Places") + " wins";
        string enabledText = "", comparedOne = editableText.text;

        while (blinking)
        {
            if (enabledText == comparedOne)
                enabledText = "";
            else if (enabledText == "")
                enabledText = comparedOne;
            // Assign empty or full text to the shown text
            editableText.text = enabledText;
            secondsCounter += 1; // add one tick to the counter
            yield return waitForBlinking;
            if (secondsCounter >= timesForTextToBlink)
                blinking = false;
        }      
    }
}
