using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spurdo : MonoBehaviour {

    public static float Speed;

	// Use this for initialization
	void Start () {
        Speed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -Speed);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

	}
}
