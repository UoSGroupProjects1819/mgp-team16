using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;
    public bool invincible;
    public float invincibleTime;
    public AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            audioManager.PlayClip(4);
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<BasicEnemy>().enabled = false;
            gameObject.GetComponent<EnemyHealth>().enabled = false;

        }
    }

    IEnumerator Damage(int value)
    {
        health -= value;
        return null;
        /*
        if (!invincible)
        {
            health -= value;
            invincible = true;
            yield return new WaitForSeconds(invincibleTime);
            invincible = false;
        }
        */
    }
}
