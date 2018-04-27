using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour {

    public enum State { Init, Start, Playing, Clear, Over };

    private State state = State.Init;
    public State currentState {
        get { return state; }
    }
    

    // Use this for initialization
    void Start() {
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
        toState(State.Over);
    }

    private void onStateClear() {
        Debug.Log(state);
    }

    private void onStateOver() {
        Debug.Log(state);
        toState(State.Clear);
    }
    
    public void toState(State s) {
        state = s;
    }
}
