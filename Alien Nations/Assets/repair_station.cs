using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class repair_station : MonoBehaviour
{

    public Text messageSpace;
    Text message;
    GameObject canvas;

    // Use this for initialization
    void Start()
    {
        message = Instantiate(messageSpace);
        canvas = GameObject.FindGameObjectWithTag("CanvasUI");
        message.transform.SetParent(canvas.transform, false);
        message.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude < 15)
        {
            if (Input.GetKey(KeyCode.E))
            {
                metadata.dur = 0;
            }
            if (metadata.dur == 0)
            {
                message.text = "SHIP AT FULL HEALTH";
            }
            else
            {
                message.text = "[E] Full Ship Repair";
            }
        }
        else
        {
            message.text = "";
        }
    }
}
