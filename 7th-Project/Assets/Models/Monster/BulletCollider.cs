using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude <= 1.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            PlayerMove pm = collision.gameObject.GetComponent<PlayerMove>();
            if (pm.lives > 0 && ((pm.name.Contains("Player1") && GetComponent<Rigidbody>().name.Contains("blue")) ||
                (pm.name.Contains("Player2") && GetComponent<Rigidbody>().name.Contains("red"))))
            {
                if (GetComponent<Rigidbody>().velocity.magnitude >= 5.0f)
                {
                    pm.lives--;
                }
            }
        }
    }
}
