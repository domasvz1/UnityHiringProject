using UnityEngine;
using System.Collections;

public class VipersMovement : MonoBehaviour
{
    Rigidbody2D viper;
    float speedForce = 15f;
    float driftChanceSticky = 0.9f;
    float driftChanceSlippy = 1f;
    float maxStickyVelocity = 2.5f;

    void FixedUpdate()
    {
  
        viper = GetComponent<Rigidbody2D>();
        float driftFactor = driftChanceSticky;

        if (RightVelocity().magnitude > maxStickyVelocity)
            driftFactor = driftChanceSlippy;

        viper.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

        if ((transform.position.x < -244) && (transform.position.y > 120) && (transform.position.y < 155))
        {
            //Debug.Log("1");
            Accelarate();
        }

        if ( (transform.position.x < -231) && (transform.position.y > 153)  )
        {
            //Debug.Log("2");
            MakeATurn(-28);
            Accelarate();
        }

        if ( (transform.position.x > -231) && (transform.position.y >= 166) )
        {
            //Debug.Log("3");
            HandleYAxis(171f,2);
            Accelarate();
        }

        if ( (transform.position.x > -173) && (transform.position.y >= 147) )
        {
            //Debug.Log("4");
            MakeATurn(-20);
            Accelarate();
        }

        if ( (transform.position.x > -142) && (transform.position.y < 147)  )
        {
            HandleXAxis(-146f,1);
            Accelarate();
        }

        if ( (transform.position.x < -138) && (transform.position.x > -159)  && (transform.position.y < 136) )
        {
            //Debug.Log("6");
            viper.angularVelocity = -26;
            Accelarate();
        }

        if ((transform.position.x < -159) && (transform.position.x >-175) && (transform.position.y < 116) )
        {
            //Debug.Log("7");
            HandleYAxis(110f,3,true);

            Accelarate();
        }

        if ((transform.position.x < -174) && (transform.position.x > - 188) && (transform.position.y < 120) )
        {
            //Debug.Log("8");
            MakeATurn(20);
            Accelarate();
        }

        if ((transform.position.x < -188) && (transform.position.x > -200) && (transform.position.y < 120))
        {
            //Debug.Log("9");
            MakeATurn(-24);
            Accelarate();
        }
        
        if ((transform.position.x < -200) && (transform.position.x > -228.5) && (transform.position.y < 110) )
        {
            //Debug.Log("10");
            HandleYAxis(103f, 2, true);
            Accelarate();
        }

        if((transform.position.x < -228.5) && (transform.position.y < 120))
        {
            //Debug.Log("11");
            MakeATurn(-27);
            Accelarate();
        }

        if ((transform.position.x < -244) && (transform.position.y > 116)  && (transform.position.y < 125))
        {
            //Debug.Log("12");
            if (viper.position.x < -246f)
                viper.angularVelocity = -5;
            if (viper.position.x > -245f)
                viper.angularVelocity = 5;
            if (viper.position.x < -245f && viper.position.x > -246f)
                viper.angularVelocity = 0;
            Accelarate();
        }
    }

    void Accelarate() // Add force To Viper
    {
        viper.AddForce(transform.up * speedForce);
    }

    void HandleXAxis(float boundary, float speed)
    {
        if (viper.position.x < boundary)
            MakeATurn(speed);

        if (viper.position.x > boundary)
            MakeATurn(-1*speed);

        if (viper.position.x == boundary)
            viper.angularVelocity = 0;
    }

    void HandleYAxis(float boundaryY, float speed, bool reverse = false)
    {
        int koef = 1;
        if (reverse)
            koef = -1;

        if (viper.position.y < boundaryY)
            MakeATurn(speed*koef);
        if (viper.position.y > boundaryY)
            MakeATurn(-1*speed*koef);
        if (viper.position.y == boundaryY)
            MakeATurn(0);
    }

    void MakeATurn(float turningSpeed)
    {
        viper = GetComponent<Rigidbody2D>();
        viper.angularVelocity = turningSpeed;
    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }
}
