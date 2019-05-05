using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float addRot;
    public bool collided;
    Pause pause;

    void Start()
    {
        pause = GameObject.Find("Pause Manager").GetComponent<Pause>();
        Destroy(gameObject, 1);
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
        transform.Rotate(new Vector3(addRot, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Untagged" || other.transform.tag == "Barrel")
        {
            Destroy(gameObject);
        }
        if (other.transform.tag == "Enemy" && !collided)
        {
            pause.StartCoroutine(pause.PauseGame());
            collided = true;
            other.gameObject.GetComponent<EnemyHealth>().StartCoroutine("Damage",1);
            Destroy(gameObject);
        }
    }

}
