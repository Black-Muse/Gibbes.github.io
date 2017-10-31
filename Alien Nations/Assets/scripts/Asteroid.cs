using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public int Count;
    Rigidbody2D comp;

	// Use this for initialization
	void Start () {
        comp = GetComponent<Rigidbody2D>();
        Count = 0;
        comp.angularVelocity = Random.value * 60.0f;
        comp.velocity = Random.insideUnitCircle;

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
        deleteIfFar();
        if (comp.angularVelocity > 60.0f)
        {
            comp.angularVelocity = 60.0f;
        }
        if (comp.angularVelocity < -60.0f)
        {
            comp.angularVelocity = -60.0f;
        }

    }

    // Remove asteroids that have gotten too far away
    void deleteIfFar ()
    {
        if (Mathf.Abs(transform.position.x) > 20 || Mathf.Abs(transform.position.y) > 20)
        {
            Destroy(gameObject);
        }
    }
}
