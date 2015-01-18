using UnityEngine;
using System.Collections;

public class MainMenu3Mins : MonoBehaviour {

	float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= startTime + 20f) {
			GetComponent<ChangeScene> ().ChangeToScene(0);
		}
	}
}
