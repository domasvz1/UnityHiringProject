using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScript : MonoBehaviour {

    float scale = 1;
    WaitForSeconds waitForSeconds = new WaitForSeconds(0.6f);
    
    IEnumerator Start()
    {
        // The second we start the menu script we start the menu music
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicScript>().PlayMusic();

        // I'm using LogoScript in Menu and HowToPlay Scens, so I play the continue playing music in both of them
        while (true)
        {
            if (scale == 1.1f)
                scale = 1;
            else if (scale == 1)
                scale = 1.1f;
            transform.localScale = new Vector2(scale, scale);

            yield return waitForSeconds;
        }
    }
}
