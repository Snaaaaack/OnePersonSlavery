using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private MapRotation map;
    private bool inCollision;
    private int count;
    private void OnCollisionEnter(Collision collision) {
        Vector3 up = new Vector3(0, 500, 0);
        //rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (inCollision)
            return;
        rb.AddForce(up);
        inCollision = true;
        map.setCollisionPoint(transform.position);
        
        Color tileColor = collision.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Renderer>().material.GetColor("_Color");
        Color playerColor = transform.GetComponent<Renderer>().material.GetColor("_Color");
        transform.GetComponent<Renderer>().material.SetColor("_Color",addColor(tileColor, playerColor));
        
    }

    void FixedUpdate () {
        if (inCollision) {
            count++;
            if (count > 3) {
                inCollision = false;
                count = 0;
            }
        }
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
       // rb.AddForce(transform.right * 100);
        map = GameObject.Find("Area").GetComponent<MapRotation>();

        transform.GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f));
    }

    private Color addColor(Color tile, Color player) {
        Color c = player;
        if (c.r > tile.r)
            c.r -= 0.25f;
        else if (c.r < tile.r)
            c.r += 0.25f;
        if (c.g > tile.g)
            c.g -= 0.25f;
        else if (c.g < tile.g)
            c.g += 0.25f;
        return c;
    }
}
