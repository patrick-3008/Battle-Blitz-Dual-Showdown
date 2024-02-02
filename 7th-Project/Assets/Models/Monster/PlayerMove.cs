using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int playerNum;
    public float maxSpeed = 5.0f;
    public CharacterController charController;
    public Camera camera;
    public float gravityY = 0.0f;
    public float mass = 1.0f;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dX = 0.0f;
        float dY = 0.0f;

        if (playerNum == 1)
        {
            dX = Input.GetAxis("Horizontal");
            dY = Input.GetAxis("Vertical");
        }
        else if (playerNum == 2)
        {
            dX = Input.GetAxis("Horizontal2");
            dY = Input.GetAxis("Vertical2");
        }


        Vector3 nonNormalizedMovementVector = new Vector3(dX, 0, dY);
        Vector3 movementVector = nonNormalizedMovementVector;
        movementVector = Quaternion.AngleAxis(camera.transform.eulerAngles.y, Vector3.up) * movementVector;
        movementVector.Normalize();
        movementVector *= maxSpeed;

        gravityY += Physics.gravity.y * mass * Time.deltaTime;

        if (charController.isGrounded)
            gravityY = -0.05f;

        Vector3 newMoveVector = movementVector;
        newMoveVector.y = gravityY;

        charController.Move(newMoveVector * Time.deltaTime);

        if (movementVector != Vector3.zero)
        {
            Quaternion rotationDirection = Quaternion.LookRotation(movementVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationDirection, 360 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (lives <= 0)
            gameObject.SetActive(false);
    }
}
