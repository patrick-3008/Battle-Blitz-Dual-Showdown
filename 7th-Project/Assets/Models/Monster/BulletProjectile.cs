using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public Object bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && gameObject.name.Contains("Player1"))
        {
            Object projectile = Instantiate(bullet, transform.position + transform.forward + transform.up, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = transform.forward * 10.0f;
            projectile.name = "redBullet";
            projectile.hideFlags = HideFlags.HideInHierarchy;
            projectile.GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.O) && gameObject.name.Contains("Player2"))
        {
            Object projectile = Instantiate(bullet, transform.position + transform.forward + transform.up, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = transform.forward * 10.0f;
            projectile.name = "bluebullet";
            projectile.hideFlags = HideFlags.HideInHierarchy;
            projectile.GetComponent<Renderer>().material.color = Color.blue;
        }

    }
}
