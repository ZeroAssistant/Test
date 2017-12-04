using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Controller : MonoBehaviour
{
    public float p_WalkSpeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            //显示鼠标
            Cursor.lockState = CursorLockMode.None;
        }

        float p_WalkFB = Input.GetAxis("Vertical") * p_WalkSpeed;
        float p_WalkLR = Input.GetAxis("Horizontal") * p_WalkSpeed;

        p_WalkFB *= Time.deltaTime;
        p_WalkLR *= Time.deltaTime;

        transform.Translate(p_WalkLR, 0, p_WalkFB);
    }
}
