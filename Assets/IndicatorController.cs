using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour {
    private Transform player;
    private Renderer dest;
    private GameObject desttile;
    private Vector3 pos;
    private bool ColorSet = false;
    // Use this for initialization
    void Start () {
		player = GameObject.Find("Player").GetComponent<Transform>();
        desttile = GameObject.Find("Map").GetComponent<Transform>().GetChild(Data.DestArea).GetChild(Data.DestTile).gameObject;
        dest = desttile.transform.GetChild(0).GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float x, y, z, d;

        if (!ColorSet) {
            Color c = dest.material.GetColor("_Color");
            transform.GetComponent<Renderer>().material.SetColor("_Color", c);
            ColorSet = true;
        }
        
        if (dest.isVisible)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(true);

        pos = transform.position;
        x = desttile.transform.position.x - transform.position.x;
        z = desttile.transform.position.z - transform.position.z;
        d = Mathf.Sqrt(x * x + z * z);
        //normalize
        x = player.position.x + x / d;
        y = player.position.y;
        z = player.position.z + z / d;
        
        transform.position = new Vector3(x, y, z);
	}
}
