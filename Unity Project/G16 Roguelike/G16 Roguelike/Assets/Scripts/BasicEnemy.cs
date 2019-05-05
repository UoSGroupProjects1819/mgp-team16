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
    public Animator anim;
    public bool[] walkChecks;

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

                Vector3 lookVector = player.transform.position - transform.position;
                float lookAngle = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg;
                if(lookAngle > -22 && lookAngle < 22 && !walkChecks[0])
                {
                    anim.Play("walkRight", 0, 0.25f);
                    for (int i = 0; i < walkChecks.Length; i++)
                    {
                        walkChecks[i] = false;
                    }
                    walkChecks[0] = true;
                }
                if (lookAngle > 22 && lookAngle < 67 && !walkChecks[1])
                {
                    anim.Play("walkUpRight", 0, 0.25f);
                    for (int i = 0; i < walkChecks.Length; i++)
                    {
                        walkChecks[i] = false;
                    }
                    walkChecks[1] = true;
                }
                if (lookAngle > 67 && lookAngle < 112 && !walkChecks[2])
                {
                    anim.Play("walkUp", 0, 0.25f);
                    for (int i = 0; i < walkChecks.Length; i++)
                    {
                        walkChecks[i] = false;
                    }
                    walkChecks[2] = true;
                }
                if (lookAngle > 112 && lookAngle < 157 && !walkChecks[3])
                {
                    anim.Play("walkUpLeft", 0, 0.25f);
                    for (int i = 0; i < walkChecks.Length; i++)
                    {
                        walkChecks[i] = false;
                    }
                    walkChecks[3] = true;
                }
                if (lookAngle > 157 && lookAngle < 180 && !walkChecks[4])
                {
                    anim.Play("walkLeft", 0, 0.25f);
                    for (int i = 0; i < walkChecks.Length; i++)
                    {
                        walkChecks[i] = false;
                    }
                    walkChecks[4] = true;
                }
                if (lookAngle > -157 && lookAngle < -112 && !walkChecks[5])
                {
                    anim.Play("walkDownLeft", 0, 0.25f);
                    for (int i = 0; i < walkChecks.Length; i++)
                    {
                        walkChecks[i] = false;
                    }
                    walkChecks[5] = true;
                }
                if (lookAngle > -112 && lookAngle < -67 && !walkChecks[6])
                {
                    anim.Play("walkDown", 0, 0.25f);
                    for (int i = 0; i < walkChecks.Length; i++)
                    {
                        walkChecks[i] = false;
                    }
                    walkChecks[6] = true;
                }
                if (lookAngle > -67 && lookAngle < -22 && !walkChecks[7])
                {
                    anim.Play("walkDownRight", 0, 0.25f);
                    for (int i = 0; i < walkChecks.Length; i++)
                    {
                        walkChecks[i] = false;
                    }
                    walkChecks[7] = true;
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
