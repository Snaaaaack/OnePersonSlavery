using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;
    //private GameObject start;
    //private GameObject main;
    GameFlowManager manager;

	void Start () {
        manager = GameObject.Find("GameManager").GetComponent<GameFlowManager>();
        /*
        start = GameObject.Find("Start");
        main = GameObject.Find("Main");
        */
        SetCameraToPlayer();
    }

    // Update is called once per frame
    void LateUpdate() {
        switch (manager.currentState) {
            case GameFlowManager.State.Start:
                break;
            case GameFlowManager.State.Playing:
                transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z) + offset;
                break;
        }
	}

    public void SetCameraToPlayer() { 
        /*
        start.SetActive(false);
        main.SetActive(false);
        */
        transform.position = new Vector3(-5, 10, -5);
        offset = transform.position - player.transform.position;
        offset.y += 10;
        transform.LookAt(new Vector3(0, 0, 0));
    }
    /*
    public void SetCameraToStart() {
        start.SetActive(true);
        main.SetActive(false);

        transform.position = new Vector3(0,-30, 0);
        transform.LookAt(start.transform);
    }

    public void SetCameraToMain() {
        start.SetActive(false);
        main.SetActive(true);

        transform.position = new Vector3(0, -30, 0);
        transform.LookAt(main.transform);
    }
    */
}
