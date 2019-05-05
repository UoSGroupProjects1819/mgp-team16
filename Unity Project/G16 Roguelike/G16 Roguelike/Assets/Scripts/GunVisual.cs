using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunVisual : MonoBehaviour
{

    public GameObject playerObj;

    void Update()
    {
        if (playerObj.transform.rotation.z >= -1 && playerObj.transform.rotation.z < -0.85f)
        {
            GetComponent<SpriteRenderer>().flipY = true;
            GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
        if (playerObj.transform.rotation.z >= -0.85f && playerObj.transform.rotation.z < -0.35f)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
        if (playerObj.transform.rotation.z >= -0.35f && playerObj.transform.rotation.z < -0.15f)
        {
            GetComponent<SpriteRenderer>().flipY = false;
            GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
        if (playerObj.transform.rotation.z >= -0.15f && playerObj.transform.rotation.z < 0.15f)
        {
            GetComponent<SpriteRenderer>().flipY = false;
            GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
        if (playerObj.transform.rotation.z >= 0.15f && playerObj.transform.rotation.z < 0.35f)
        {
            GetComponent<SpriteRenderer>().flipY = false;
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        if (playerObj.transform.rotation.z >= 0.35f && playerObj.transform.rotation.z < 0.75f)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        if (playerObj.transform.rotation.z >= 0.75f && playerObj.transform.rotation.z < 0.95f)
        {
            GetComponent<SpriteRenderer>().flipY = true;
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        if (playerObj.transform.rotation.z >= 0.95f && playerObj.transform.rotation.z < 1)
        {
            GetComponent<SpriteRenderer>().flipY = true;
            GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
    }
}
