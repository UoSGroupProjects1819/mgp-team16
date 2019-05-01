using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public float minDist;
    public bool slowDown;
    public float activeDist;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < activeDist)
        {
            Vector3 playerDir = player.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDir);
            if (hit.transform.tag == "Player")
            {
                if (slowDown)
                {
                    if (Vector3.Distance(transform.position, player.transform.position) > minDist)
                    {
                        transform.position += playerDir * speed * Time.deltaTime;
                    }
                    else
                    {
                        transform.position += playerDir.normalized * speed * Time.deltaTime;
                    }
                }
                else
                {
                    transform.position += playerDir.normalized * speed * Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.gameObject.GetComponent<PlayerScript>().StartCoroutine("Damage", transform.position);
        }
    }
}
