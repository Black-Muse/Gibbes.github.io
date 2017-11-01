using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class General : MonoBehaviour {

    public static float Distance;
    public static float HorizontalPos;
    public static float LevelDistance;
    public static int AsteroidCount;
    public static int AlienCount;
    public int MaxDistance;
    public Transform asteroid;
    public Transform alien;
    public int RayZ;
    public int ForceMultiplier;
    public Slider sld;
    public Slider hld;
    public static bool mouseDragging;
    public static float damage;
    public static int health;

    Camera cam;
    LineRenderer lr;
    RaycastHit2D hit;
    GameObject target;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
        lr = GetComponent<LineRenderer>();
        Distance = 0.1f;
        HorizontalPos = 0;
        LevelDistance = 250.0f;
        AsteroidCount = 0;
        AlienCount = 0;
        MaxDistance = 0;
        RayZ = 1;
        ForceMultiplier = 15;
        health = 300;
        damage = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
        horizontals();
        tractorBeam();
        sld.value = Mathf.Max(0, HorizontalPos / LevelDistance);
        hld.value = damage / health;

        
    }
    
    // Deals with horizontal movement
    void horizontals ()
    {
        if (HorizontalPos > MaxDistance)
        {
            Instantiate(asteroid, new Vector2(12, (10 * Random.value) - 5), Quaternion.identity);
            MaxDistance += 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            HorizontalPos += Distance;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            HorizontalPos -= Distance / 4;
        }
    }

    // Works with tractor beam
    void tractorBeam()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            string tag = "";
            if (hit)
            {
                target = hit.transform.gameObject;
                tag = target.tag;
            }
            mouseDragging = tag == "draggable";
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (mouseDragging)
            {
                mouseDragging = false;
                target.GetComponent<Rigidbody2D>().AddForceAtPosition((cam.ScreenToWorldPoint(Input.mousePosition) - target.transform.position) * ForceMultiplier, hit.point);
            }
        }
        if (mouseDragging)
        {
            Vector3 start = target.transform.position;
            Vector3 end = cam.ScreenToWorldPoint(Input.mousePosition);
            start.z = RayZ;
            end.z = RayZ;
            lr.SetPositions(new Vector3[] { start, end });
        }
        else
        {
            lr.SetPositions(new Vector3[] { Vector3.zero, Vector3.zero });
        }
    }

}
