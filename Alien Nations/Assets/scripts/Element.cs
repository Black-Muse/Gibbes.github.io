using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

    Rigidbody2D comp;

    // Use this for initialization
    void Start()
    {
        comp = GetComponent<Rigidbody2D>();
        comp.velocity = Random.insideUnitCircle;
        comp.angularVelocity = Random.value * 60.0f;
    }

    // Update is called once per frame
    void Update () {
        if (Mathf.Abs(transform.position.x) > 20 || Mathf.Abs(transform.position.y) > 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Spurdo")
        {
            switch (gameObject.tag)
            {
                case "Helium":
                    metadata.helium++;
                    break;
                case "Hydrogen":
                    metadata.hydrogen++;
                    break;
                case "Iron":
                    metadata.iron++;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
