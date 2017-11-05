using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hud : MonoBehaviour {

    float transparency;
    bool up;

	// Use this for initialization
	void Start ()
    {
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
        Color c = GetComponent<SpriteRenderer>().color;
        c.a = transparency;
        GetComponent<SpriteRenderer>().color = c;
	}
}
