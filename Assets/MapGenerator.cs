using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapGenerator : MonoBehaviour {
    public static int MapSize = 21;
    private int[] MapData;
    private Color[] ColorIndex;
    // Use this for initialization
    void Start() {
        MapData = new int[MapSize];
        InitColor();
        ParseMap(0);
        ColorMap();
    }

    // Update is called once per frame
    void Update() {

    }

    void InitColor() {
        ColorIndex = new Color[9];
        for (int i = 1; i <= 3; i++) {
            for (int j = 1; j <= 3; j++) {
                ColorIndex[3 * i + j - 4] = new Color(0.25f * i, 0.25f * j, 0.5f);
            }
        }
    }

    void ParseMap(int index) {
        FileStream fs = new FileStream("Assets\\Data\\map.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);

        for (int i = 0; i < index - 1; i++)
            sr.ReadLine();

        string input = sr.ReadLine().Split('/')[1];
        for (int i = 0; i < MapSize; i++) {
            MapData[i] = int.Parse(input.Substring(i, 1));
        }
    } 

    public void ColorMap() {
        int area, tile;
        for (int i = 0; i < MapSize; i++) {
            area = i / 7;
            tile = i % 7;
            if (MapData[i] == 0) {
                transform.GetChild(area).GetChild(tile).gameObject.SetActive(false);
            }
            else {
                transform.GetChild(area).GetChild(tile).gameObject.SetActive(true);
                transform.GetChild(area).GetChild(tile).GetComponent<Transform>().GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", ColorIndex[MapData[i] - 1]);
            }
        }
    }
}
