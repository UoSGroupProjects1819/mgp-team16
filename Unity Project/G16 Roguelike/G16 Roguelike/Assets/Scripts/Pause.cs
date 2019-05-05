using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public float pauseTime;
    public bool paused;

    void Start()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public IEnumerator PauseGame()
    {
        if (!paused)
        {
            Time.timeScale = 0.1f;
            yield return new WaitForSecondsRealtime(pauseTime);
            Time.timeScale = 1f;
            paused = false;
        }
    }
}
