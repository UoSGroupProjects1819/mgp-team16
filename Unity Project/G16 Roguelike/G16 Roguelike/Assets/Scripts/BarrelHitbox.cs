using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelHitbox : MonoBehaviour
{

    public Pause pause;

    private void Start()
    {
        pause = GameObject.Find("Pause Manager").GetComponent<Pause>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            pause.StartCoroutine(pause.PauseGame());
            collision.gameObject.GetComponent<EnemyHealth>().StartCoroutine("Damage", 100);
        }
        if (collision.transform.tag == "Player")
        {
            pause.StartCoroutine(pause.PauseGame());
            collision.gameObject.GetComponent<PlayerScript>().StartCoroutine("Damage", transform.position);
        }
        if (collision.gameObject.GetComponent<Barrel>() == true)
        {
            print("Barrel hit");
            pause.StartCoroutine(pause.PauseGame());
            collision.gameObject.GetComponent<Barrel>().StartCoroutine("Hit");
        }
    }
}
