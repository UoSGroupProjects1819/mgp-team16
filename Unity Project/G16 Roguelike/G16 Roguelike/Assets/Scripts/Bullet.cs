using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float addRot;
    public bool collided;

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
        if (other.transform.tag == "Enemy" && !collided)
        {
            collided = true;
            other.gameObject.GetComponent<EnemyHealth>().StartCoroutine("Damage",1);
            Destroy(gameObject);
        }
    }
}
