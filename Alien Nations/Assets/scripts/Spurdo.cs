using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spurdo : MonoBehaviour {

    public static Vector2 velocity;
    public static float dx, dy;
    public static float maxX, maxY;
    public static float minX, minY;

    int flip, maxRot, repeating, repeatingMax, z;

    public GameObject[] fodders;
    public Transform background_anchor;
    public Background[] backs;

    // Use this for initialization
    void Start ()
    {
        velocity = Vector2.zero;
        dx = dy = 0.0025f;
        maxX = maxY = 0.1f;
        minX = -maxX / 4;
        minY = -maxY;

        flip = 0;
        maxRot = 20;
        repeating = 0;
        repeatingMax = 8;
        z = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (velocity.x < maxX)
            velocity.x += dx;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (velocity.x > minX)
            velocity.x -= dx;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (velocity.y < maxY)
            velocity.y += dy;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (velocity.y > minY)
                velocity.y -= dy;
        }
        rotation();
        background();
    }

    void rotation()
    {
        Vector3 angle = transform.rotation.eulerAngles;
        if (Input.GetKey(KeyCode.W) && transform.position.y < 5)
        {
            if (z < maxRot)
            {
                transform.eulerAngles = new Vector3(0, 0, z++);
            }
        }
        else if (Input.GetKey(KeyCode.S) && transform.position.y > -5)
        {
            if (z > -maxRot)
            {
                transform.eulerAngles = new Vector3(0, 0, z--);
            }
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
        Asteroid a = collision.collider.GetComponent<Asteroid>();
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
        General.damage += collision.relativeVelocity.magnitude * 20;
        if (General.damage >= General.health)
        {
            for (var n = 0; n < 20 + Mathf.Floor(Random.value * 3); n++)
            {
                Instantiate(fodders[0], collision.transform.position, Quaternion.identity);
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

    void background()
    {
        if (Mathf.Abs(backs[2].transform.position.x) <= 0.15f)
        {
            backs[0].transform.position = new Vector2(background_anchor.position.x * 2, 0);
            RotateForward();
        }
        if (Mathf.Abs(backs[0].transform.position.x) <= 0.15f)
        {
            backs[2].transform.position = new Vector2(-background_anchor.position.x * 2, 0);
            RotateBackward();
        }
    }
    void RotateForward()
    {
        Background temp = backs[0];
        backs[0] = backs[1];
        backs[1] = backs[2];
        backs[2] = temp;
    }

    void RotateBackward()
    {
        Background temp = backs[2];
        backs[2] = backs[1];
        backs[1] = backs[0];
        backs[0] = temp;
    }

}
