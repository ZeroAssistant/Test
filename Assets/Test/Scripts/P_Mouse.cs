using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Mouse : MonoBehaviour
{
    Vector2 p_MouseLook;
    Vector2 p_MouseSmooth;

    public float sensitivity;
    public float smoothing;

    GameObject p_Camera;

	// Use this for initialization
	void Start ()
    {
        p_Camera = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        var cp = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        cp = Vector2.Scale(cp, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        p_MouseSmooth.x = Mathf.Lerp(p_MouseSmooth.x, cp.x, 1f / smoothing);
        p_MouseSmooth.y = Mathf.Lerp(p_MouseSmooth.y, cp.y, 1f / smoothing);
        p_MouseLook += p_MouseSmooth;

        transform.localRotation = Quaternion.AngleAxis(-p_MouseLook.y, Vector3.right);
        p_Camera.transform.localRotation = Quaternion.AngleAxis(p_MouseLook.x, p_Camera.transform.up);
	}
}
