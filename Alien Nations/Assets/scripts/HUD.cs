using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    public Transform hot;
    public Transform cold;

    Transform t;
    Transform tt;
    SpriteRenderer canvasColor;
    float canvasTransparency;
    float anchorX;
    float anchorY;
    float height;
    float distDenom;
    float transparency;
    bool up;

    float dangerZoneUp;
    float dangerZoneDown;

	// Use this for initialization
	void Start () {
        transparency = 1;
        up = false;
        t = transform.parent.transform;
        tt = t.parent.transform;
        anchorX = t.position.x;
        anchorY = t.position.y;
        height = tt.position.y - anchorY;
        distDenom = hot.position.y - cold.position.y;
        dangerZoneUp = height * 1.2f + anchorY;
        dangerZoneDown = 0.2f * height + anchorY;
        canvasColor = GameObject.FindGameObjectWithTag("CanvasColor").GetComponent<SpriteRenderer>();
        canvasTransparency = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (!Pause.paused)
        {
            updatePosition();
            outOfBoundsCheck();
            controlTransparency();
        }
	}

    void updatePosition()
    {
        anchorX = t.position.x;
        anchorY = t.position.y;
        height = tt.position.y - anchorY;
        dangerZoneUp = height + anchorY;
        dangerZoneDown = 0.25f * height + anchorY;
        float yOffset = height * (((hot.position.y - transform.position.y) / distDenom) + 0.15f);
        transform.position = new Vector2(anchorX, anchorY + yOffset);
    }

    void outOfBoundsCheck()
    {
        if (transform.position.y < dangerZoneDown)
        {
            General.damage += 10 * (dangerZoneDown - transform.position.y);
            canvasTransparency = Mathf.Min(.75f, 2 * (dangerZoneDown - transform.position.y));
            canvasColor.color = new Color(0xFF / 255, 0x7E / 255, 0x7E / 255, canvasTransparency);
        }
        if (transform.position.y > dangerZoneUp)
        {
            General.damage += 4 * (transform.position.y - dangerZoneUp);
            canvasTransparency = Mathf.Min(.75f, 2 * (transform.position.y - dangerZoneUp));
            canvasColor.color = new Color(0x72 / 255, 0x85 / 255, 0xFF / 255, canvasTransparency);
        }
    }

    void controlTransparency()
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
}
