using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x - Spurdo.velocity.x, transform.position.y - Spurdo.velocity.y);
    }
}
