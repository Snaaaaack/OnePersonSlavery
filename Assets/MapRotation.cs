using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotation : MonoBehaviour {
    private Vector3 collisionPoint;

    private void OnCollisionEnter(Collision collision) {
        
    }


    void Start () {
	}
	
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.RotateAround(collisionPoint, Vector3.up, 5 * moveHorizontal);
    }

    public void setCollisionPoint(Vector3 Point) {
        collisionPoint = Point;
    }
}
