using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnroidIconTravel : MonoBehaviour {

    WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);
    float scale = 1.2f;

    void FixedUpdate ()
    {
        Rigidbody2D aIcon = GetComponent<Rigidbody2D>();

        if ( (aIcon.position.x < 1.60 ) && (aIcon.position.y > 0.9))
        {
            aIcon.AddForce(transform.right*35);
            aIcon.AddForce(transform.up * -10);
        }
        else
            aIcon.velocity = Vector2.zero;
    }

    IEnumerator Start()
    {
        while (true)
        {
            if (transform.position.x > -3.65 && transform.position.y < 2.90)
            {
                if (scale == 1.2f)
                    scale = 1.3f;
                else if (scale == 1.3f)
                    scale = 1.2f;

                transform.localScale = new Vector2(scale, scale);
                yield return waitForSeconds;
            }
        }
    }
}
