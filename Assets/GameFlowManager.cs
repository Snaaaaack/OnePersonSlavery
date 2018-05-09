using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowManager : MonoBehaviour {
    public enum State { Init, Start, Main, Playing, Clear, Result, Over };
    private Transform player;
    private State state = State.Init;

	public Button startButton;
	public Button resultButton;
	public Button mainButton;

	public State currentState {
        get { return state; }
    }

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player").GetComponent<Transform>();
		startButton.GetComponent<Button>().onClick.AddListener(onClickStart);
		resultButton.GetComponent<Button>().onClick.AddListener(onClickResult);
		mainButton.GetComponent<Button>().onClick.AddListener(onClickMain);
		player.gameObject.SetActive(false);
		resultButton.gameObject.SetActive(false);
		mainButton.gameObject.SetActive(false);
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
		player.gameObject.SetActive(true);
		player.GetComponent<PlayerController>().Reset();

		startButton.gameObject.SetActive(false);
		resultButton.gameObject.SetActive(true);

		toState(State.Playing);
	} 
	
	private void onClickResult() {
		resultButton.gameObject.SetActive(false);
		mainButton.gameObject.SetActive(true);
		player.gameObject.SetActive(false);
		toState(State.Result);
	}

	private void onClickMain() {
		mainButton.gameObject.SetActive(false);
		startButton.gameObject.SetActive(true);
		toState(State.Main);
	}

    private void onStateStart() {
        Debug.Log(state);
        toState(State.Main);
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
        toState(State.Playing);
    }
    
    public void toState(State s) {
        state = s;
    }
}
