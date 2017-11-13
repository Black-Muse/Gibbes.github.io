using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet_test : MonoBehaviour {

    float speed;

	// Use this for initialization
	void Start () {
        speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().angularVelocity = -speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().angularVelocity = speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
	}
}
