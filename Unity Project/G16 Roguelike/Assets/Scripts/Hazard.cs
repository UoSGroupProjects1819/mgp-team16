using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.GetComponent<PlayerScript>().StartCoroutine(col.transform.GetComponent<PlayerScript>().Damage(transform.position));
        }
    }
}
