using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;

	void Start () {
        //SetCameraToPlayer();
    }

    // Update is called once per frame
    void LateUpdate() {
        transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z) + offset;
    }

    public void SetCameraToPlayer() { 
        transform.position = new Vector3(-5, 10, -5);
        offset = transform.position - player.transform.position;
        offset.y += 10;
        transform.LookAt(new Vector3(0, 0, 0));
    }
}
