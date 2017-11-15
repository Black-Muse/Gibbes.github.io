using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour {

    public Text messageSpace;
    Text message;
    public string planet_name;
    GameObject canvas;

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        message = Instantiate(messageSpace);
        canvas = GameObject.FindGameObjectWithTag("CanvasUI");
        message.transform.SetParent(canvas.transform, false);
        message.color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.magnitude < 5)
        {
            message.text = "[E] Enter " + planet_name;
        }
        else
        {
            message.text = "";
        }
		if (Mathf.Abs(transform.position.x) > 20)
        {
            Destroy(gameObject);
        }
	}
}
