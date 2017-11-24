using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour {

    public Text messageSpace;
    public Vector2 position;
    public bool shouldDestroy;
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
        shouldDestroy = false;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = position;
        if (transform.position.magnitude < 5)
        {
            message.text = "[E] Enter " + planet_name;
            if (Input.GetKey(KeyCode.E))
            {
                switch (planet_name)
                {
                    case "Fafnir":
                        metadata.faf = 340;
                        metadata.man = 220;
                        metadata.bel = 100;
                        break;
                    case "Mandru":
                        metadata.faf = 100;
                        metadata.man = 340;
                        metadata.bel = 220;
                        break;
                    case "Belmagia":
                        metadata.faf = 220;
                        metadata.man = 100;
                        metadata.bel = 340;
                        break;
                }
                metadata.dur = General.damage;
                SceneManager.LoadScene(planet_name);
            }
        }
        else
        {
            message.text = "";
        }
		if (shouldDestroy)
        {
            Debug.Log("Planet destroyed");
            Destroy(gameObject);
        }
	}
}
