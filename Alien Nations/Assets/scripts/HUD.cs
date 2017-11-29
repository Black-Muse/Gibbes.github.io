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
    public static float distDenom;
    public static float hudPos;
    public static float sunPos;
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
        hudPos = transform.position.y;
        sunPos = hot.position.y;
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
        hudPos = transform.position.y;
        sunPos = hot.position.y;
        dangerZoneUp = height + anchorY;
        dangerZoneDown = 0.25f * height + anchorY;
        float yOffset = height * (((sunPos - hudPos) / distDenom) + 0.15f);
        transform.position = new Vector2(anchorX, anchorY + yOffset);
    }

    void outOfBoundsCheck()
    {
        if (hudPos < dangerZoneDown)
        {
            General.damage += 10 * (dangerZoneDown - hudPos);
            canvasTransparency = Mathf.Min(.75f, 2 * (dangerZoneDown - hudPos));
            canvasColor.color = new Color(0xFF / 255, 0x7E / 255, 0x7E / 255, canvasTransparency);
        }
        if (hudPos > dangerZoneUp)
        {
            General.damage += 4 * (hudPos - dangerZoneUp);
            canvasTransparency = Mathf.Min(.75f, 2 * (hudPos - dangerZoneUp));
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
