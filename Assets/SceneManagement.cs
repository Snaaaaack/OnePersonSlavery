using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
    private int Stage;

    public void SwitchToTitle() {
        SceneManager.LoadScene(0);
    }

    public void SwitchToMain() {
        SceneManager.LoadScene(1);
    }

    public void LoadStage(Button button) {
        int id = int.Parse(button.name);

        if (!Data.StageData[id - 1])
            return;

        Data.Stage = id;
        SceneManager.LoadScene(2);
    }
}
