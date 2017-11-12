using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {

    public static float distance;
    public static bool noBack;
    public static bool noFront;
    public Transform background_anchor;
    public Background back;

    // Use this for initialization
    void Start () {
        distance = 0.003f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x + distance / 4, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x - distance, transform.position.y);
        }
    }
}
