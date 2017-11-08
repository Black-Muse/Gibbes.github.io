using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet_Hud : MonoBehaviour
{
    Transform t;
    Transform tt;
    public Transform anchor;

    public Planet planet;
    float transparency;
    bool up;
    float anchorX;
    float anchorY;
    float multiplier;
    public float initialDistance;
    public float currentDistance;
    bool shouldSpawn;

    // Use this for initialization
    void Start()
    {
        transparency = 1;
        up = false;
        t = transform.parent.transform;
        tt = t.parent.transform;
        anchorX = t.position.x;
        anchorY = t.position.y;
        multiplier = tt.position.y - anchorY;
        initialDistance += 90;
        currentDistance = initialDistance;
        shouldSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        blink_slowly();
        move();
    }

    // Slow blinking
    void blink_slowly()
    {
        if (transparency >= 1)
        {
            up = false;
        }
        else if (transparency <= 0)
        {
            up = true;
        }
        if (up)
        {
            transparency += 0.01f;
        }
        else
        {
            transparency -= 0.01f;
        }
        GetComponent<SpriteRenderer>().color = new Color(178, 255, 0, transparency);
    }

    // Control position
    void move()
    {
        float xOffset = multiplier * Mathf.Cos(currentDistance * Mathf.PI / 180);
        float yOffset = multiplier * Mathf.Sin(currentDistance * Mathf.PI / 180);
        transform.position = new Vector2(anchorX + xOffset, anchorY + yOffset);
        if (Mathf.Sin(currentDistance * Mathf.PI / 180) > 0.9f)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, transparency);
            if (shouldSpawn)
            {
                Instantiate(planet);
                planet.transform.position = new Vector2(anchor.position.x, anchor.position.y);
            }
            shouldSpawn = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(178, 255, 0, transparency);
            shouldSpawn = true;
        }
        currentDistance = initialDistance + General.HorizontalPos;
    }
}
