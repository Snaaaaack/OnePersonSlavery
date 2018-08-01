using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
    private int Stage;

    public void SwitchToTitle() {
        SceneManager.LoadScene(0);
    }

    public void SwitchToMain() {
        SceneManager.LoadScene(1);
    }

    public void SwitchToPlaying() {
        //deprecated
        SceneManager.LoadScene(2);
    }

    public void LoadStage() {
        SceneManager.LoadScene(2);
    }
}
