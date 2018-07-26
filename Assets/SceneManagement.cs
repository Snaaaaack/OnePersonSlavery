using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    public void SwitchToTitle() {
        SceneManager.LoadScene(0);
    }

    public void SwitchToMain() {
        SceneManager.LoadScene(1);
    }

    public void SwitchToPlaying() {
        SceneManager.LoadScene(2);
    }
}
