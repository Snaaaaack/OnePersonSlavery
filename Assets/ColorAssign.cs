using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAssign : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for (int i = 0; i < transform.childCount; i++) {
            Color randomColor = Random.ColorHSV();
            transform.GetChild(i).GetComponent<Transform>().GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", randomColor);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
