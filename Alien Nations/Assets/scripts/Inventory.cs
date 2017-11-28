using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    Image img;
    public float transparency; 

	// Use this for initialization
	void Start () {
        transparency = 0;
        img = GetComponent<Image>();
        Color c = img.color;
        c.a = transparency;
        img.color = c;
	}
	
	// Update is called once per frame
	void Update () {
        Color c = img.color;
        c.a = transparency;
        img.color = c;
        if (Pause.inv)
        {
            fadeIn();
        }
		else
        {
            fadeOut();
        }
    }

    void fadeIn()
    {
        if (transparency < 0.5f)
        {
            transparency += 0.05f;
        }
    }

    void fadeOut()
    {
        if (transparency > 0)
        {
            transparency -= 0.05f;
        }
    }
}
