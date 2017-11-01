using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spurdo : MonoBehaviour {

    public static float Speed;
    public GameObject Fodder;

    int flip;
    int maxRot;
    int repeating;
    int repeatingMax;
    int tilt;
    int z;

	// Use this for initialization
	void Start () {
        Speed = 2.0f;
        flip = 0;
        maxRot = 5;
        repeating = 0;
        repeatingMax = 8;
        z = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 angle = transform.rotation.eulerAngles;
        if (Input.GetKey(KeyCode.W))
        {
            if (z < maxRot)
            {
                transform.eulerAngles = new Vector3(0, 0, z++);
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (z > -maxRot)
            {
                transform.eulerAngles = new Vector3(0, 0, z--);
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -Speed);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            if (z > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, z--);
            }
            if (z < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, z++);
            }
        }

	}

    // Collider flasher
    void OnCollisionEnter2D(Collision2D collision)
    {
        InvokeRepeating("flash", 0, 0.05f);
        for (var n = 0; n < 4 + Mathf.Floor(Random.value * 3); n++)
        {
            Instantiate(Fodder, collision.transform.position, Quaternion.identity);
        }
        Destroy(collision.collider.gameObject);
        General.mouseDragging = false;
        General.damage += collision.relativeVelocity.magnitude * 5;

        if (General.damage >= General.health)
        {
            for (var n = 0; n < 20 + Mathf.Floor(Random.value * 3); n++)
            {
                Instantiate(Fodder, collision.transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }

    void flash()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, flip);
        flip = 1 - flip;
        repeating++;
        if (repeating >= repeatingMax)
        {
            repeating = 0;
            CancelInvoke();
        }
    }

}
