using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRoom : MonoBehaviour
{

    public GameObject loadingScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject.Find("Main Camera").transform.GetChild(0).gameObject.SetActive(true);
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
