using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotation : MonoBehaviour {
    private Vector3 collisionPoint;

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.name);
        collisionPoint = collision.gameObject.transform.position;
    }


    void Start () {
	}
	
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.RotateAround(collisionPoint, Vector3.up, 5 * moveHorizontal);
        Debug.Log(collisionPoint);
    }

    public void setCollisionPoint(Vector3 Point) {
        collisionPoint = Point;
    }
}
