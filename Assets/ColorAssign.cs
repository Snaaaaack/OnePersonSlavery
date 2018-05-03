using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAssign : MonoBehaviour {
    private float[] ci = { 0.25f, 0.5f, 0.75f };    //Color Index

    // temp
    void Start() {
        int index = 0;
        for (int r = 0; r < 3; r++)
            for (int g = 0; g < 3; g++) {
                transform.GetChild(index).GetComponent<Transform>().GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(ci[r], ci[g], 0.5f));
                index++;
            }
    }
	
    /*
    void Start() {

     }
     
    */

	// Update is called once per frame
	void Update () {
		
	}
}