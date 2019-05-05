using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{

    bool hit;
    public PlayerCamera cam;
    public Pause pause;
    public AudioSource audioS;

    private void Start()
    {
        audioS = gameObject.GetComponent<AudioSource>();
        pause = GameObject.Find("Pause Manager").GetComponent<Pause>();
        cam = GameObject.Find("CameraObj").GetComponent<PlayerCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            StartCoroutine("Hit");
        }
    }

    IEnumerator Hit()
    {
        if (!hit)
        {
            audioS.PlayOneShot(audioS.clip);
            cam.shakeAmount = 1f;
            cam.shakeTime = 0.2f;
            cam.StartCoroutine(cam.Shake());
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            hit = true;
            yield return new WaitForSeconds(1f);
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }

}
