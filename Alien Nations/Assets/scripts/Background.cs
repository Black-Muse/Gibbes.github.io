using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (!Pause.paused)
        {
            transform.position = new Vector2(transform.position.x - Spurdo.velocity.x / 8, transform.position.y);
        }
    }
}
