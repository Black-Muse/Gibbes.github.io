using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    Rigidbody2D comp;

	// Use this for initialization
	void Start () {
        comp = GetComponent<Rigidbody2D>();
        comp.angularVelocity = Random.value * 60.0f;
        comp.velocity = Random.insideUnitCircle;

    }
	
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
        deleteIfFar();
        controlSpin();

    }

    // Remove asteroids that have gotten too far away
    void deleteIfFar ()
    {
        if (Mathf.Abs(transform.position.x) > 20 || Mathf.Abs(transform.position.y) > 20)
        {
            if (gameObject.tag == "draggable") {
                General.AsteroidCount -= 1;
            }
            Destroy(gameObject);
        }
    }

    // Makes sure asteroids don't spin out of control
    void controlSpin()
    {
        if (comp.angularVelocity > 60.0f)
        {
            comp.angularVelocity = 60.0f;
        }
        if (comp.angularVelocity < -60.0f)
        {
            comp.angularVelocity = -60.0f;
        }
    }
}
