using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool stuck = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            stuck = true;
            Debug.Log("Hit");
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            stuck = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
