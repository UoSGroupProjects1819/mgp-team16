using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest : MonoBehaviour
{

    public Camera cam;
    public Vector2 pos;
    public GameObject light;

    void Update()
    {
        pos = cam.ScreenToWorldPoint(Input.mousePosition);
        light.transform.position = pos;
    }
}
