using UnityEngine;
using System.Collections;

public class TaxisMovement : MonoBehaviour
{
    // Two fields for cars movement
    public float inicialSpeed;
    public float turningSpeed;
    private Transform target;

    void FixedUpdate()
    {
        target = CarLaps.newTaxisCheckpoint; // Marking the target, a.k.a the next checkpoint

        if (CarLaps.newTaxisCheckpoint != null)
        {
            Vector2 direction = target.position - transform.position;
            float angle = -1 * Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turningSpeed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, target.position, inicialSpeed * Time.deltaTime);
        }
    }
}