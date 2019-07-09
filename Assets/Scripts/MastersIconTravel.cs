using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastersIconTravel : MonoBehaviour
{
    Rigidbody2D mIcon;

    WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
    float IVelocity = 20;
    float scale = 1.2f;

    void FixedUpdate()
    {
        mIcon = GetComponent<Rigidbody2D>();

        if ((mIcon.position.x > 2.1) && (mIcon.position.y < 1.42))
        {
            mIcon.AddForce(transform.right * -1);
            mIcon.AddForce(transform.up * 1);
        }
        else
            mIcon.velocity = Vector2.zero;
    }

    IEnumerator Start()
    {
        mIcon = GetComponent<Rigidbody2D>();
        // Icon Transformation needs to start only when player sees it
        while (true)
        {
            if (transform.position.x < 2.1 && transform.position.y < 0.36)
            {
                if (scale == 1.2f)
                    scale = 1.1f;
                else if (scale == 1.1f)
                    scale = 1.2f;

                if (IVelocity == 20)
                    IVelocity = -20;
                else if (IVelocity == -20)
                    IVelocity = 20;

                transform.localScale = new Vector2(scale, scale);
                mIcon.angularVelocity = IVelocity;
            }
            yield return waitForSeconds;
        }
    }
}
