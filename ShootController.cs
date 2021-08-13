using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 20;
    public bool hasBullet = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasBullet)
        {
            bullet.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.01f;
            bullet.transform.rotation = Camera.main.transform.rotation;
        }
        //bullet.transform.position = Camera.main.transform.position;
        //bullet.transform.rotation = Camera.main.transform.rotation;
        if (Input.GetButton("Fire1") && !bullet.GetComponent<BulletScript>().stuck)
        {
            if(hasBullet)
            {
                bullet.GetComponent<MeshRenderer>().enabled = true;
                hasBullet = false;

            }
            bullet.transform.LookAt(Camera.main.transform);
            bullet.transform.Rotate(0, 180, 0);

            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(bullet.transform.position-Camera.main.transform.position) * bulletSpeed;
        }
        else if (Input.GetButton("Fire2") && !hasBullet)
        {
            
            bullet.transform.LookAt(Camera.main.transform);
            bullet.transform.Rotate(0, 180, 0);

            bullet.GetComponent<Rigidbody>().velocity = -Vector3.Normalize(bullet.transform.position - Camera.main.transform.position) * bulletSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == bullet.name && !hasBullet)
        {
            bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bullet.GetComponent<MeshRenderer>().enabled = false;
            hasBullet = true;
        }
    }
}
