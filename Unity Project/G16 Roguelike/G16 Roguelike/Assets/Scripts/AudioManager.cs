using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource[] clips;

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    public void PlayClip(int clip)
    {
        clips[clip].PlayOneShot(clips[clip].clip);
    }
}
