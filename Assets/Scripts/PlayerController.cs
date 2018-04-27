using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private MapRotation map;
    
    private void OnCollisionEnter(Collision collision) {
        Vector3 up = new Vector3(0, 500, 0);
        rb.AddForce(up);

        map.setCollisionPoint(transform.position);

        Color tileColor = collision.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Renderer>().material.GetColor("_Color");
        Color playerColor = transform.GetComponent<Renderer>().material.GetColor("_Color");
        transform.GetComponent<Renderer>().material.SetColor("_Color", new Color(tileColor.r + playerColor.r, tileColor.g + playerColor.g, tileColor.b + playerColor.b));

       // collision.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 0));
        
    }

    void FixedUpdate () {
	}

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * 100);
        
        map = GameObject.Find("Tiles").GetComponent<MapRotation>();

        transform.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 0));
    }

    private Color addColor(Color a, Color b) {
        Color c = new Color {
            r = (a.r + b.r) / 2 < 1 ? (a.r + b.r) / 2 : 1,
            g = (a.g + b.g) / 2 < 1 ? (a.g + b.g) / 2 : 1,
            b = (a.b + b.b) / 2 < 1 ? (a.b + b.b) / 2 : 1
        };
        return c;
    }
}
