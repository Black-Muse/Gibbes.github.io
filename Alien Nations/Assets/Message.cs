using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

    float transparency;
    bool up;

    // Use this for initialization
    void Start () {
        transparency = 1;
        up = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (transparency >= 1)
        {
            up = false;
        }
        else if (transparency <= 0)
        {
            up = true;
        }
        if (up)
        {
            transparency += 0.01f;
        }
        else
        {
            transparency -= 0.01f;
        }
        Color c = GetComponent<Text>().color;
        c.a = transparency;
        GetComponent<Text>().color = c;

        if (Mathf.Abs(transform.position.x) > 20)
        {
            Destroy(gameObject);
        }
    }
}
