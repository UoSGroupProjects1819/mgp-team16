using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [Header("Player Stats")]
    public int maxHealth;
    public int knockBack;
    public int damageKnockBack;
    public int rotationSpeed;
    public float reloadSpeed;
    public float invincibleTime;

    [Header("Read Variables")]
    public int health;
    public bool canShoot;
    public bool invincible;

    [Header("Init variables")]
    public Rigidbody2D rB;
    public Camera cam;

    void Start()
    {
        health = maxHealth;
    }

    void FixedUpdate()
    {
        //Init look at vectors
        Vector3 mousePos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector3 transform2D = new Vector3(transform.position.x, transform.position.y, 0);
        //translate look at vectors to a rotation
        Vector3 lookVector = mousePos - transform2D;
        float lookAngle = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg;
        Quaternion lookQuaternion = Quaternion.AngleAxis(lookAngle, Vector3.forward);
        //apply rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookQuaternion, Time.deltaTime * rotationSpeed);

        if (Input.GetMouseButton(0))
        {
            if (canShoot)
            {
                StartCoroutine("Fire");
            }
        }

        //TEST TEST TEST TEST TEST
        if (Input.GetMouseButton(1))
        {
            if (!invincible)
            {
                StartCoroutine(Damage(mousePos));
            }
        }
        //-------------------------
    }

    IEnumerator Fire()
    {
        canShoot = false;
        rB.AddForce(-transform.right * knockBack);
        yield return new WaitForSeconds(reloadSpeed);
        canShoot = true;
    }

    public IEnumerator Damage(Vector3 objPos)
    {
        if (!invincible)
        {
            Vector3 dir = objPos - transform.position;
            invincible = true;
            health -= 1;
            rB.AddForce(-dir * damageKnockBack);
            yield return new WaitForSeconds(invincibleTime);
            invincible = false;
        }
    }
}