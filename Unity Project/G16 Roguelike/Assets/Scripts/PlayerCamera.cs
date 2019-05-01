using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [Header("Camera Stats")]
    public float speed;

    [Header("Init variables")]
    public GameObject player;

    void Update()
    {
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, -10), speed);
    }
}