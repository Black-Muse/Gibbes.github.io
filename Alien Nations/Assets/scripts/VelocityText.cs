using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocityText : MonoBehaviour {

    Text txt;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (gameObject.tag)
        {
            case "vert":
                txt.text = "Vert. Velocity: " + (Spurdo.velocity.y * 1000).ToString("0");
                break;
            case "horz":
                txt.text = "Horz. Velocity: " + (Spurdo.velocity.x * 1000).ToString("0");
                break;
        }
	}
}
