using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sales : MonoBehaviour {

    public Text messageSpace;
    Text message;
    GameObject canvas;

    // Use this for initialization
    void Start () {
        message = Instantiate(messageSpace);
        canvas = GameObject.FindGameObjectWithTag("CanvasUI");
        message.transform.SetParent(canvas.transform, false);
        message.color = Color.black;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.magnitude < 15)
        {
            switch (gameObject.tag)
            {
                case "Helium":
                    if (metadata.helium > 0)
                    {
                        message.text = "[E] Sell Helium";
                        if (Input.GetKey(KeyCode.E))
                        {
                            metadata.creds += metadata.helium * 800;
                            metadata.helium = 0;
                        }
                    }
                    else
                    {
                        message.text = "No Helium";
                    }
                    break;
                case "Hydrogen":
                    if (metadata.hydrogen > 0)
                    {
                        message.text = "[E] Sell Hydrogen";
                        if (Input.GetKey(KeyCode.E))
                        {
                            metadata.creds += metadata.hydrogen * 200;
                            metadata.hydrogen = 0;
                        }
                    }
                    else
                    {
                        message.text = "No Hydrogen";
                    }
                    break;
                case "Iron":
                    if (metadata.iron > 0)
                    {
                        message.text = "[E] Sell Iron";
                        if (Input.GetKey(KeyCode.E))
                        {
                            metadata.creds += metadata.iron * 600;
                            metadata.iron = 0;
                        }
                    }
                    else
                    {
                        message.text = "No Iron";
                    }
                    break;
            }
        }
        else
        {
            message.text = "";
        }
    }
}
