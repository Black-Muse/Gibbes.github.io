using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x + General.Distance / 4, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x - General.Distance, transform.position.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - General.Distance);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + General.Distance);
        }
    }
}
