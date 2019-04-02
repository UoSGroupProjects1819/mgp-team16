using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;
    public bool invincible;
    public float invincibleTime;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Damage(int value)
    {
        if (!invincible)
        {
            health -= value;
            invincible = true;
            yield return new WaitForSeconds(invincibleTime);
            invincible = false;
        }
    }
}
