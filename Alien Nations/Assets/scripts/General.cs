using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour {

    public static float HorizontalPos;
    public static float VerticalPos;
    public static float VerticalMagnitude;
    public static float NextVerticalMagnitude;
    public static float HorizontalMagnitude;
    public static float NextHorizontalMagnitude;
    public static bool GameOver;
    public static int AsteroidCount;
    public Asteroid[] asteroids;
    public Transform alien;
    public int RayZ;
    public int ForceMultiplier;
    public static bool mouseDragging;
    public static float damage;
    public static int health;

    Camera cam;
    LineRenderer lr;
    RaycastHit2D hit;
    GameObject target;
    float timeToDeath;
    float chanceOfButt;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
        lr = GetComponent<LineRenderer>();
        HorizontalPos = 0;
        AsteroidCount = 0;
        VerticalMagnitude = NextVerticalMagnitude = HorizontalMagnitude = NextHorizontalMagnitude = 0;
        RayZ = 1;
        ForceMultiplier = 30;
        GameOver = false;
        health = 300;
        damage = metadata.dur;
        timeToDeath = 0;
        chanceOfButt = 0.5f;
    }

    // Update is called once per frame
    void Update() {
        if (!Pause.paused)
        {
            movement();
            tractorBeam();
            checkReset();
        }
    }
    
    void checkReset()
    {
        if (GameOver)
        {
            if (timeToDeath < 1)
            {
                timeToDeath += 0.005f;
            }
            else
            {
                SceneManager.LoadScene("space");
            }
        }
    }

    // Deals with movement
    void movement()
    {
        VerticalPos += Spurdo.velocity.y / 1.5f;
        HorizontalPos += Spurdo.velocity.x / 1.5f;
        VerticalMagnitude += Mathf.Abs(Spurdo.velocity.y);
        HorizontalMagnitude += Mathf.Abs(Spurdo.velocity.x);
        if (Spurdo.velocity.y > 0) {
            spawnVert((Random.value * 24) - 12, 11);
        }
        else
        {
            spawnVert((Random.value * 24) - 12, -11);
        }
        if (Spurdo.velocity.x > 0)
        {
            spawnHor(15, (Random.value * 10) - 5);
        }
        else
        {
            spawnHor(-15, (Random.value * 10) - 5);
        }
    }
    
    // Manages creation of new asteroids
    void spawnVert (float x, float y)
    {
        if (VerticalMagnitude > NextVerticalMagnitude && AsteroidCount < 30)
        {
            NextVerticalMagnitude += 5;
            int classifier = calculateClassifier((HUD.sunPos - HUD.hudPos) / HUD.distDenom);
            Asteroid new_asteroid = Instantiate(asteroids[classifier], new Vector2(x, y), Quaternion.identity);
            new_asteroid.setClassifier(classifier);
            AsteroidCount += 1;
        }
    }

    // Manages creation of new asteroids
    void spawnHor(float x, float y)
    {
        if (HorizontalMagnitude > NextHorizontalMagnitude && AsteroidCount < 30)
        {
            NextHorizontalMagnitude += 5;
            int classifier = calculateClassifier((HUD.sunPos - HUD.hudPos) / HUD.distDenom);
            Asteroid new_asteroid = Instantiate(asteroids[classifier], new Vector2(x, y), Quaternion.identity);
            new_asteroid.setClassifier(classifier);
            AsteroidCount += 1;
        }
    }

    int calculateClassifier (float relativeLocation)
    {
        float heliumProb = (relativeLocation + 0.25f) * (100 - chanceOfButt);
        if (heliumProb < 70)
        {
            heliumProb = 5;
        }
        float hydrogenProb = ((100 - heliumProb - chanceOfButt) / 2);
        float ironProb = hydrogenProb;
        float randomRoll = 100 * Random.value;
        if (randomRoll < chanceOfButt)
        {
            return 3;
        }
        else if (randomRoll < chanceOfButt + ironProb)
        {
            return 1;
        }
        else if (randomRoll < chanceOfButt + hydrogenProb + ironProb)
        {
            return 0;
        }
        else
        {
            return 2;
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
            Vector3 end = Vector2.zero;
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
