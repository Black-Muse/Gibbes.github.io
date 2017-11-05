using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class General : MonoBehaviour {

    public static float Distance;
    public static float HorizontalPos;
    public static float VerticalPos;
    public static float Magnitude;
    public static float NextMagnitude;
    public static float LevelDistance;
    public static int AsteroidCount;
    public static int AlienCount;
    public Transform asteroid;
    public Transform alien;
    public int RayZ;
    public int ForceMultiplier;
    public Slider hld;
    public SpriteRenderer hud;
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
        Magnitude = 0;
        NextMagnitude = 0;
        RayZ = 1;
        ForceMultiplier = 15;
        health = 300;
        damage = 0;
        Color c = hud.color;
        c.a = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        movement();
        tractorBeam();
        hld.value = damage / health;
    }
    
    // Deals with movement
    void movement ()
    {   
        bool w = Input.GetKey(KeyCode.W), a = Input.GetKey(KeyCode.A), s = Input.GetKey(KeyCode.S), d = Input.GetKey(KeyCode.D);
        if (w || a || s || d)
        {
            if (w)
            {
                VerticalPos += Distance;
                Magnitude += Distance;
                spawn((Random.value * 24) - 12, 11);
            }
            else if (s)
            {
                VerticalPos -= Distance;
                Magnitude += Distance;
                spawn((Random.value * 24) - 12, -11);
            }
            if (d)
            {
                HorizontalPos += Distance;
                Magnitude += Distance;
                spawn(12, (10 * Random.value) - 5);
            }
            else if (a)
            {
                HorizontalPos -= Distance / 4;
                Magnitude += Distance / 4;
                spawn(-12, (10 * Random.value) - 5);
            }
        }
    }
    
    // Manages creation of new asteroids
    void spawn (float x, float y)
    {
        if (Magnitude > NextMagnitude && AsteroidCount < 30)
        {
            NextMagnitude += 5;
            Instantiate(asteroid, new Vector2(x, y), Quaternion.identity);
            AsteroidCount += 1;
        }
    }

    // Works with tractor beam
    void tractorBeam ()
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
                target.GetComponent<Rigidbody2D>().AddForceAtPosition((target.transform.position - cam.ScreenToWorldPoint(Input.mousePosition)) * ForceMultiplier, hit.point);
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
