using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoButtonOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button> ().enabled = false;
		GetComponent<Image> ().enabled = false;
		GetComponentInChildren<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
