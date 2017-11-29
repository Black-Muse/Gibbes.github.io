using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryText : MonoBehaviour {

    int value;
    Text txt;
    public float transparency;

    // Use this for initialization
    void Start () {
        retrieveValue();
        txt = GetComponent<Text>();
        transparency = 0;
        Color c = txt.color;
        c.a = transparency;
        txt.color = c;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag != "Untagged")
        {
            txt.text = "  " + gameObject.tag + ": " + value;
            retrieveValue();
        }
        Color c = txt.color;
        c.a = transparency;
        txt.color = c;
        if (Pause.inv)
        {
            fadeIn();
        }
        else
        {
            fadeOut();
        }
    }

    void retrieveValue ()
    {
        switch (gameObject.tag)
        {
            case "Fur":
                value = metadata.fur;
                break;
            case "Wood":
                value = metadata.wood;
                break;
            case "Spice":
                value = metadata.spice;
                break;
            case "Helium":
                value = metadata.helium;
                break;
            case "Hydrogen":
                value = metadata.hydrogen;
                break;
            case "Iron":
                value = metadata.iron;
                break;
            case "Creds":
                value = metadata.creds;
                break;
        }
    }

    void fadeIn()
    {
        if (transparency < 1)
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
