using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{

    bool hit;

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
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            transform.GetChild(2).gameObject.SetActive(false);
        }

        hit = true;
    }

}
