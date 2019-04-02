using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    public GameObject playerObj;
    public Vector3 offset;
    public Sprite[] spriteList;

    void Update()
    {
        transform.position = playerObj.transform.position + offset;

        print(playerObj.transform.rotation.z);

        if (playerObj.transform.rotation.z >= -1 && playerObj.transform.rotation.z < -0.85f)
        {
            GetComponent<SpriteRenderer>().sprite = spriteList[7];
        }
        if (playerObj.transform.rotation.z >= -0.85f && playerObj.transform.rotation.z < -0.35f)
        {
            GetComponent<SpriteRenderer>().sprite = spriteList[0];
        }
        if (playerObj.transform.rotation.z >= -0.35f && playerObj.transform.rotation.z < -0.15f)
        {
            GetComponent<SpriteRenderer>().sprite = spriteList[1];
        }
        if (playerObj.transform.rotation.z >= -0.15f && playerObj.transform.rotation.z < 0.15f)
        {
            GetComponent<SpriteRenderer>().sprite = spriteList[2];
        }
        if (playerObj.transform.rotation.z >= 0.15f && playerObj.transform.rotation.z < 0.35f)
        {
            GetComponent<SpriteRenderer>().sprite = spriteList[3];
        }
        if (playerObj.transform.rotation.z >= 0.35f && playerObj.transform.rotation.z < 0.75f)
        {
            GetComponent<SpriteRenderer>().sprite = spriteList[4];
        }
        if (playerObj.transform.rotation.z >= 0.75f && playerObj.transform.rotation.z < 0.95f)
        {
            GetComponent<SpriteRenderer>().sprite = spriteList[5];
        }
        if (playerObj.transform.rotation.z >= 0.95f && playerObj.transform.rotation.z < 1)
        {
            GetComponent<SpriteRenderer>().sprite = spriteList[6];
        }

    }
}
