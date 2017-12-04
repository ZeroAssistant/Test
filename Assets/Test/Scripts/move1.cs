using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    public KeyCode[] keycode;
    Vector3 twoPixel = new Vector3(0, 0, 2);

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Time.deltaTime * 60, 0, 0);
            //moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if(Input.GetKeyDown(keycode[0]))
        {
            controller.Move(twoPixel);
        }
        else if (Input.GetKeyDown(keycode[1]))
        {
            controller.Move(-twoPixel);
        }
    }
}
