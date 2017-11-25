using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tempship : MonoBehaviour {

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
            Debug.Log(message.text);
            message.text = "[E] Exit";
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("space");
            }
        }
        else
        {
            message.text = "";
        }
    }
}
