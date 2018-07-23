using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowManager : MonoBehaviour {
    public enum State { Init, Start, Main, Playing, Clear, Result, Over };
    private Transform player;
    private GameObject map;
    private CameraController Camera;
    private Rigidbody rb;
    private State state = State.Init;

    public int stageCount;
	public Button startButton;
	public Button endButton;
	public Button mainButton;
    public Button stage;

	public State currentState {
        get { return state; }
    }

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player").GetComponent<Transform>();
        Camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
        rb = player.GetComponent<Rigidbody>();
        map = GameObject.Find("Map");
        startButton.GetComponent<Button>().onClick.AddListener(onClickStart);
		endButton.GetComponent<Button>().onClick.AddListener(onClickEnd);
		mainButton.GetComponent<Button>().onClick.AddListener(onClickMain);
        stage.GetComponent<Button>().onClick.AddListener(onClickStage);
        for (int i = 0; i < stageCount; i++) {

        }

        Camera.SetCameraToStart();

		player.gameObject.SetActive(false);
		endButton.gameObject.SetActive(false);
		mainButton.gameObject.SetActive(false);
        stage.gameObject.SetActive(false);

		toState(State.Start);
    }

    // Update is called once per frame
    void Update() {
        switch(state) {
            case State.Start: onStateStart(); break;
			case State.Main: onStateMain(); break;
            case State.Playing: onStatePlaying(); break;
            case State.Clear: onStateClear(); break;
            case State.Over: onStateOver(); break;
        }
    }

	private void onClickStart() {
		startButton.gameObject.SetActive(false);
		endButton.gameObject.SetActive(false);
        stage.gameObject.SetActive(true);

        Camera.SetCameraToMain();

		toState(State.Main);
	} 
	
	private void onClickEnd() {
		endButton.gameObject.SetActive(false);
		mainButton.gameObject.SetActive(true);
		player.gameObject.SetActive(false); 
		toState(State.Result);
	}

	private void onClickMain() {
		mainButton.gameObject.SetActive(false);
		startButton.gameObject.SetActive(true);
		toState(State.Main);
	}

    private void onClickStage() {
        stage.gameObject.SetActive(false);

        player.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().Reset();

        Camera.SetCameraToPlayer();
        toState(State.Playing);
    }

    private void onStateStart() {
        Debug.Log(state);
    }

	private void onStateMain() {
		Debug.Log(state);
	}

    private void onStatePlaying() {
        Debug.Log(state);

        if (player.position.y < -5) {
            toState(State.Over);
        }
    }

    private void onStateClear() {
        Debug.Log(state);
    }

	private void onStateResult() {
		Debug.Log(state);
	}

    private void onStateOver() {
        Debug.Log(state);

		player.GetComponent<PlayerController>().Reset();
        for(int i = 0; i < map.transform.childCount; i++) {
            for(int j = 0; j < map.transform.GetChild(i).childCount; j++)
                map.transform.GetChild(i).GetChild(j).gameObject.SetActive(true);
        }
        map.GetComponent<MapGenerator>().ColorMap();
        
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        toState(State.Playing);
    }
    
    public void toState(State s) {
        state = s;
    }
}
