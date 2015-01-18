using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrossSceneTest : MonoBehaviour {
	public Text test;
	public Text TEST2;
	// Use this for initialization
	void Start () {
		test.text = "" + ApplicationModel.P2Char;
		TEST2.text = ApplicationModel.songbeatmap;
		GameObject.Find ("GameManager").audio.clip = ApplicationModel.songaudiofile;
		GameObject.Find ("GameManager").audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
