using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour {
    public GameObject buttonPrefab;
    public GameObject panel;

	// Use this for initialization
	void Start () {
	    for(int i = 2; i <= 5; i++) {
            Create(i);
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Create(int i) {
        GameObject button = Instantiate(buttonPrefab);

        button.transform.SetParent(panel.transform);
        //button.GetComponent<Button>().onClick.AddListener(OnClick);
        button.transform.GetChild(0).GetComponent<Text>().text = i.ToString();

        RectTransform rt = button.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(-300 + 100 * i, 100);
    }

    void OnClick() {
        Debug.Log("Clicked!");
    }
}
