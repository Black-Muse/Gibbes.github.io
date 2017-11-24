using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet_Hud : MonoBehaviour
{
    public Transform hot;
    public Transform cold;

    Transform t;
    Transform tt;
    public Transform anchor;
    public Planet planet;
    public Transform ship;
    public float orbitPosition;

    float transparency;
    bool up;
    float anchorX;
    float anchorY;
    float multiplier;
    public float initialDistance;
    public float currentDistance;
    bool shouldSpawn;
    Planet p;

    // Use this for initialization
    void Start()
    {
        transparency = 1;
        up = false;
        t = transform.parent.transform;
        tt = t.parent.transform;
        anchorX = t.position.x;
        anchorY = t.position.y;
        multiplier = orbitPosition * (tt.position.y - anchorY);
        switch (planet.planet_name)
        {
            case "Fafnir":
                initialDistance = metadata.faf;
                break;
            case "Mandru":
                initialDistance = metadata.man;
                break;
            case "Belmagia":
                initialDistance = metadata.bel;
                break;
        }
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
        Vector2 relativePosition = transform.position - ship.position;
        if (relativePosition.magnitude < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, transparency);
            if (shouldSpawn)
            {
                p = Instantiate(planet);
                shouldSpawn = false;
            }
            float proportion = relativePosition.magnitude / 0.5f;
            relativePosition.Normalize();
            p.position = proportion * anchor.position.magnitude * relativePosition;
        }
        else
        {
            if (!shouldSpawn)
            {
                p.shouldDestroy = true;
            }
            GetComponent<SpriteRenderer>().color = new Color(178, 255, 0, transparency);
            shouldSpawn = true;
        }
        currentDistance = initialDistance + General.HorizontalPos;
    }
}
