using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    public Transform hot;
    public Transform cold;

    Transform t;
    Transform tt;
    float anchorX;
    float anchorY;
    float height;
    float distDenom;
    float transparency;
    bool up;

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
    }
	
	// Update is called once per frame
	void Update () {
        anchorX = t.position.x;
        anchorY = t.position.y;
        height = tt.position.y - anchorY;
        float yOffset = height * (((hot.position.y - transform.position.y) / distDenom) + 0.15f);
        transform.position = new Vector2(anchorX, anchorY + yOffset);
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
