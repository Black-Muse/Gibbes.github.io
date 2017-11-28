using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    Text t;

	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!Pause.paused)
        {
            float damage = Mathf.Floor(100 * General.damage / General.health);
            t.text = "Durability: " + (100 - damage) + "%";
        }
	}
}
