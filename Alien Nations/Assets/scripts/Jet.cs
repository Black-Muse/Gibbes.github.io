using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour {

    public char activate;
    float dt;

	// Use this for initialization
	void Start () {
        dt = 0.15f;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (!Pause.paused)
        {
            switch (activate)
            {
                case 'd':
                    controller(Input.GetKey(KeyCode.D));
                    break;
                case 'a':
                    controller(Input.GetKey(KeyCode.A));
                    break;
                case 's':
                    controller(Input.GetKey(KeyCode.S));
                    break;
                case 'w':
                    controller(Input.GetKey(KeyCode.W));
                    break;
            }
        }
	}

    void controller(bool activated)
    {
        float a = GetComponent<SpriteRenderer>().color.a;
        if (activated && a < 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, a + dt);
        }
        else if (!activated && a > 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, a - dt);
        }
    }
}
