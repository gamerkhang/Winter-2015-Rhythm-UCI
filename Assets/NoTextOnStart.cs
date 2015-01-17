using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoTextOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
