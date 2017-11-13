using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite_control : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            GetComponent<Animator>().Play("spurdo_walk");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<Animator>().Play("spurdo_walk");
        }
        else
        {
            GetComponent<Animator>().Play("spurdo_idle");
        }
	}
}
