using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [Header("Camera Stats")]
    public float speed;
    public float shakeTime;
    public float shakeAmount;

    [Header("Init variables")]
    public GameObject player;
    public GameObject camObj;

    [Header("Read variables")]
    public bool shake;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, -10), speed);
        if (shake)
        {
            camObj.transform.localPosition = Random.insideUnitSphere * shakeAmount;
        }
        else
        {
            camObj.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public IEnumerator Shake()
    {
        shake = true;
        yield return new WaitForSecondsRealtime(shakeTime);
        shake = false;
    }
}