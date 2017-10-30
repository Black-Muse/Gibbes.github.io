using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public int Count;

	// Use this for initialization
	void Start () {
        Count = 0;
        GetComponent<Rigidbody2D>().angularVelocity = Random.value * 60.0f;
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x + General.Distance, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x - General.Distance, transform.position.y);
        }
    }
}
