using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Jump : MonoBehaviour
{
    public float p_ForceRJ;
    public float p_ForceHover;

    Rigidbody p_Rigidbody;

	// Use this for initialization
	void Start ()
    {
        p_Rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.LeftShift))
        {
            p_Rigidbody.AddForce(0, p_ForceRJ, 0);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            p_Rigidbody.AddForce(0, p_ForceHover, 0);
        }
	}
}
