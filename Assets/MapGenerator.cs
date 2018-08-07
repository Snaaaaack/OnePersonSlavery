using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapGenerator : MonoBehaviour {
    public static int MapSize = 21;
    private int[] MapData;
    private Color[] ColorIndex;
    private int Stage;
    private Vector2Int dest;
    // Use this for initialization
    void Start() {
        Stage = Data.Stage;
        MapData = new int[MapSize];
        InitColor();
        ParseMap(Stage);
        ColorMap();
        HighlightDest();
    }
    
    void HighlightDest() {
        Vector3 pos = transform.GetChild(dest.x).GetChild(dest.y).position;
        pos.y = -1;
        transform.GetChild(dest.x).GetChild(dest.y).position = pos;
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

        Debug.Log("Now Loading stage:");
        Debug.Log(Stage);

        for (int i = 0; i < index - 1; i++)
            sr.ReadLine();

        string[] input = sr.ReadLine().Split('/');
        for (int i = 0; i < MapSize; i++) 
            MapData[i] = int.Parse(input[1].Substring(i, 1));
        
        dest.x = int.Parse(input[2].Substring(0, 1));
        dest.y = int.Parse(input[2].Substring(2, 1));

        sr.Close();
        fs.Close();
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
