using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterTime : MonoBehaviour
{
    // Script called in various scenes when after the given time, a given scene needs to be called

    public float time; // The time until the scene loads
    public string scene; // Scene that will load

    IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }
}



