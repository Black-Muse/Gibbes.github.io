using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (!Pause.paused)
        {
            transform.position = new Vector2(0, transform.position.y - Spurdo.velocity.y);
        }
    }
}
