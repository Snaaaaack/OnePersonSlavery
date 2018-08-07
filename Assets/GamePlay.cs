using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GamePlay : MonoBehaviour {
    private Transform player;
    private GameObject map;
    private CameraController Camera;
    private Rigidbody rb;
    
    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player").GetComponent<Transform>();
        Camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
        rb = player.GetComponent<Rigidbody>();
        map = GameObject.Find("Map");
        Camera.SetCameraToPlayer();
    }

    // Update is called once per frame
    void Update() {
        if (player.position.y < -5)
            GameOver();
    }
    
    public void ClearGame() {
        SaveData(Data.Stage);
        SceneManager.LoadScene(3);
    }

    private void SaveData(int stage) {
        FileStream fs = new FileStream("Assets\\Data\\level.txt", FileMode.Open, FileAccess.ReadWrite);

        Debug.Log("Saving clear data...");
        
        fs.Seek(stage, SeekOrigin.Begin);
        fs.WriteByte((byte)'1');
        fs.Close();
    }

    private void GameOver() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}