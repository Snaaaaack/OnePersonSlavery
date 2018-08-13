using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StageSelect : MonoBehaviour {
    public GameObject buttonPrefab;
    public GameObject panel;

	// Use this for initialization
	void Start () {
        LoadClearData();
	    for(int i = 2; i <= 5; i++) {
            Create(i);
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void LoadClearData() {
        string filepath = Application.persistentDataPath + "/level.txt";
        if(!File.Exists(filepath)) {
            string[] leveldata = {
                "1000000",
            };
            File.WriteAllLines(filepath, leveldata);
        }
        FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        //FileStream fs = new FileStream("Assets\\Data\\level.txt", FileMode.Open, FileAccess.Read);
        
        for (int i = 0; i < Data.StageData.Length; i++) {
            Data.StageData[i] = fs.ReadByte() == (byte)'1';
        }

        fs.Close();
    }

    public void Create(int i) {
        GameObject button = Instantiate(buttonPrefab);
        button.transform.SetParent(panel.transform);    
        button.transform.GetChild(0).GetComponent<Text>().text = Data.StageData[i - 1] ? i.ToString() : "X";
        button.transform.name = i.ToString();
        RectTransform rt = button.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(-600+ 200 * i, 300);
    }
}
