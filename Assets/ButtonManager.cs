using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
	public float AlphaThreshold = 0.1f;

	void Start() {
		this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
