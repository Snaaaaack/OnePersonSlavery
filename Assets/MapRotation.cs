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
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            int dir = touch.position.x < (Screen.width / 2) ? 1 : -1;
            transform.RotateAround(collisionPoint, Vector3.up, 5 * dir);
        }
        /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.RotateAround(collisionPoint, Vector3.up, 5 * moveHorizontal);
        */
    }

    public void setCollisionPoint(Vector3 Point) {
        collisionPoint = Point;
    }
}
