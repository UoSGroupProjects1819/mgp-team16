using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    [Header("Player Stats")]
    public int maxHealth;
    public int knockBack;
    public int damageKnockBack;
    public int rotationSpeed;
    public float reloadSpeed;
    public float invincibleTime;
    public int bulletCount;
    public float bulletSpread;

    [Header("Read Variables")]
    public int health;
    public bool canShoot;
    public bool invincible;
    Quaternion lookQuaternion;
    bool minus;
    public Vector2 pos;
    public bool hasControl;

    [Header("Init variables")]
    public Rigidbody2D rB;
    public Camera cam;
    public GameObject bulletPrefab;
    public GameObject sprite;

    [Header("Gun Effects")]
    public Transform MuzzleFlashPrefab;
    public Transform Gun;

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
        lookQuaternion = Quaternion.AngleAxis(lookAngle, Vector3.forward);
        //apply rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookQuaternion, Time.deltaTime * rotationSpeed);

        if (hasControl) {
            if (Input.GetMouseButton(0))
            {
                if (canShoot)
                {
                    StartCoroutine("Fire");
                }
            }
        }
        
    }

    IEnumerator Fire()
    {
        canShoot = false;

        for (int i = 0; i < bulletCount; i++)
        {
            minus = !minus;
            if (!minus) {
                GameObject tempBullet = Instantiate(bulletPrefab, transform.position, lookQuaternion);
                tempBullet.transform.Rotate(0, 0, bulletSpread * i, Space.Self);
            }
            else
            {
                GameObject tempBullet = Instantiate(bulletPrefab, transform.position, lookQuaternion);
                tempBullet.transform.Rotate(0, 0, bulletSpread * -i, Space.Self);
            }
        }

        rB.AddForce(-transform.right * knockBack);
        yield return new WaitForSeconds(reloadSpeed);
        canShoot = true;
    }

    public IEnumerator Damage(Vector3 objPos)
    {
        if (!invincible)
        {
            if (health <= 1)
            {
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
            else
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
}