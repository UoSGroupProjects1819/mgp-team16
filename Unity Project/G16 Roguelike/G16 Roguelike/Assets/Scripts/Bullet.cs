using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float addRot;

    void Start()
    {
        Destroy(gameObject, 1);
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
        transform.Rotate(new Vector3(addRot, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Untagged")
        {
            Destroy(gameObject);
        }
    }
}
