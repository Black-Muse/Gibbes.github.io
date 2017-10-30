using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour {

    public static float Distance;
    public static float HorizontalPos;
    public int MaxDistance;
    public Transform prefab;

    // Use this for initialization
    void Start () {
        Distance = 0.1f;
        HorizontalPos = 0;
        MaxDistance = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (HorizontalPos > MaxDistance) {
            Instantiate(prefab, new Vector2(12, (10 * Random.value) - 5), Quaternion.identity);
            MaxDistance += 5;
        }
        if (Input.GetKey(KeyCode.D))
        {
            HorizontalPos += Distance;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            HorizontalPos -= Distance;
        }
    }
}
