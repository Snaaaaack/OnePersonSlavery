using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour {
    public enum State { Init, Start, Playing, Clear, Over };
    private Transform player;
    private State state = State.Init;
    public State currentState {
        get { return state; }
    }
    

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player").GetComponent<Transform>();
        toState(State.Start);
    }

    // Update is called once per frame
    void Update() {
        switch(state) {
            case State.Start: onStateStart(); break;
            case State.Playing: onStatePlaying(); break;
            case State.Clear: onStateClear(); break;
            case State.Over: onStateOver(); break;
        }
    }

    private void onStateStart() {
        Debug.Log(state);
        toState(State.Playing);
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

    private void onStateOver() {
        Debug.Log(state);

        player.GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f));
        player.position = new Vector3(0, 5, 0);
        toState(State.Playing);
    }
    
    public void toState(State s) {
        state = s;
    }
}
