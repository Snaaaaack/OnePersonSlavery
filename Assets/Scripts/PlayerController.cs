using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    MapRotation map;
    
    private void OnCollisionEnter(Collision collision) {
        Vector3 up = new Vector3(0, 500, 0);
        rb.AddForce(up);

        map.setCollisionPoint(transform.position);
    }

    void FixedUpdate () {
	}

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * 100);

        map = GameObject.Find("Tiles").GetComponent<MapRotation>();
    }
}
