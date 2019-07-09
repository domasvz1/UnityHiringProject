using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayersCamera : MonoBehaviour {

    public Transform target;
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

	void Update () {

        transform.position = new Vector3(target.position.x, target.position.y, -10f);

        if(bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
               Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
               Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }        
    }
}
