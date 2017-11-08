using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet_Hud : MonoBehaviour
{
    float transparency;
    bool up;
    float anchorX;
    float anchorY;
    float multiplier;
    public float initialDistance;
    float currentDistance;

    // Use this for initialization
    void Start()
    {
        transparency = 1;
        up = false;
        Transform t = transform.parent.transform;
        Transform tt = t.parent.transform;
        anchorX = t.position.x;
        anchorY = t.position.y;
        multiplier = tt.position.y - anchorY;
        initialDistance += 90;
        currentDistance = initialDistance;
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
        Color c = GetComponent<SpriteRenderer>().color;
        c.a = transparency;
        GetComponent<SpriteRenderer>().color = c;
    }

    // Control position
    void move()
    {
        transform.position = new Vector2(anchorX + multiplier * Mathf.Cos(currentDistance * Mathf.PI / 180), anchorY + multiplier * Mathf.Sin(currentDistance * Mathf.PI / 180));
        currentDistance = initialDistance + General.HorizontalPos;
    }
}
