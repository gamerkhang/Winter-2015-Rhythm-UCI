using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrossSceneTest : MonoBehaviour {
	public Text test;

	// Use this for initialization
	void Start () {
		test.text = "" + ApplicationModel.P2Char;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
