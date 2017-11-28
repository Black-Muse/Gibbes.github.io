using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    Rigidbody2D comp;
    public int classifier;

    public GameObject[] fodders;

    public void setClassifier(int c)
    {
        classifier = c;
    }

    public int getClassifier()
    {
        return classifier;
    }

	// Use this for initialization
	void Start () {
        comp = GetComponent<Rigidbody2D>();
        comp.angularVelocity = Random.value * 60.0f;
        comp.velocity = Random.insideUnitCircle;

    }
	
	// Update is called once per frame
	void Update () {
        if (!Pause.paused)
        {
            deleteIfFar();
            controlSpin();
        }
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

    // Collider flasher
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "draggable") {
            Asteroid a = collision.collider.GetComponent<Asteroid>();
            if (GetComponent<Rigidbody2D>().velocity.magnitude > 1 || a.GetComponent<Rigidbody2D>().velocity.magnitude > 1)
            {
                int i;
                if (a.getClassifier() == 2)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                for (var n = 0; n < 4 + Mathf.Floor(Random.value * 3); n++)
                {
                    Instantiate(fodders[i], collision.transform.position, Quaternion.identity);
                }
                Destroy(collision.collider.gameObject);
                General.mouseDragging = false;
            }
        }
    }
}
