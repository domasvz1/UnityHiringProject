using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeLeft;
    public Text countdownText;
    // All the game objects that need to be frozen before start
    public GameObject PlayerScript, ViperScript, TaxiScript, SanchezScript;
    // All the Images that need to shown at startng UI and then disappear
    public Image PlayerImage, ViperImage, TaxiImage, SanchezImage;

    // This script sets all the scripts with the movements to activ eafter the certain time
    void Start()
    {
        StartCoroutine("CountDown");
        SetTheCondition(false,true);
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Race Begins In " + timeLeft);

        if (timeLeft <= 0)
        {
            StopCoroutine("CountDown");
            countdownText.GetComponent<Text>().enabled = false;
            SetTheCondition(true, false);
        }
    }

    IEnumerator CountDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    void SetTheCondition(bool gameObjectsCondition, bool imagesConditon)
    {
        // Arrays to fit in all Objects and image so that we wouldn't need to duplicated code
        GameObject[] GameObjectsArray = { PlayerScript, ViperScript, TaxiScript, SanchezScript };
        Image[] ImagesArray = { PlayerImage, ViperImage, TaxiImage, SanchezImage };
        // Both arrays are the same size, so it doesnt matetr which one we take for the loop
        for (int i = 0; i < ImagesArray.Length; i++) 
        {
            GameObjectsArray[i].SetActive(gameObjectsCondition);
            ImagesArray[i].enabled = imagesConditon;
        }
    }
}