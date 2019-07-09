using UnityEngine;
using System.Collections;

public class SanchezMovement : MonoBehaviour
{
    Rigidbody2D sanchez;
    float driftChanceSticky = 0.9f;
    float driftChanceSlippy = 1f;
    float maxStickyVelocity = 2.5f;

    public float inicialSpeed;
    public float turningSpeed;
    private Transform target;

    private void Start()
    {
        // Sanchez's target will be always the Player object
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
    }

    void FixedUpdate()
    {
        // Drift component will be usefull with steering
        sanchez = GetComponent<Rigidbody2D>();
        float driftFactor = driftChanceSticky;

        if (RightVelocity().magnitude > maxStickyVelocity)
            driftFactor = driftChanceSlippy;

        sanchez.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

        if (Vector2.Distance(transform.position, target.position) > 3.6f)
        {
            Vector2 direction = target.position - transform.position;
            float angle = -1 * Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turningSpeed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, target.position, inicialSpeed * Time.deltaTime);
        }
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
