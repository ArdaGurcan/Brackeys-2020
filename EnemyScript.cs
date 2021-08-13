using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    float enemySpeed = 4;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        GetComponent<Rigidbody>().velocity = transform.forward * enemySpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "bullet" && other.GetComponent<Rigidbody>().velocity.magnitude > 0.01f)
        {
            Destroy(gameObject);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
