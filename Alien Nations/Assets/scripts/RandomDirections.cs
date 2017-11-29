using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirections : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle;
        GetComponent<Rigidbody2D>().angularVelocity = Random.value * 60.0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
