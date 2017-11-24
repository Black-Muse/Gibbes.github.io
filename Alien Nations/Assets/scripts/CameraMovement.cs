using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    float maxPos;
    float dy;
    private Vector3 velocity;

	// Use this for initialization
	void Start () {
        maxPos = 0.5f;
        dy = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vec = transform.position;
        Vector3 target = Vector3.zero;
        if (Input.GetKey(KeyCode.S))
        {
            target.y = maxPos;
        }
        if (Input.GetKey(KeyCode.W))
        {
            target.y = -maxPos;
        }
        vec.y = Mathf.SmoothDamp(transform.position.y, target.y, ref velocity.y, dy);
        transform.position = vec;
	}
}
