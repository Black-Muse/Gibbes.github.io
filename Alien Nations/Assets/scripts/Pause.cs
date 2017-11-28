using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public static bool paused;
    public static bool inv;
    public Inventory inventory;

	// Use this for initialization
	void Start () {
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            Time.timeScale = 1 - Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inv = !inv;
        }
	}
}
