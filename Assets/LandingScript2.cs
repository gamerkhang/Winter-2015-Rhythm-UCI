using UnityEngine;
using System.Collections;

public class LandingScript2 : MonoBehaviour {
	public bool aLeft;
	public bool aRight;
	public bool aUp;
	public bool aDown;
	// Use this for initialization
	void Start () {
		aLeft = false;
		aRight = false;
		aUp = false;
		aDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(aLeft == false && Input.GetKey(KeyCode.A))
		{
			Debug.Log("stahp LEFT");
		}
		if(aRight== false && Input.GetKey(KeyCode.D))
		{
			Debug.Log("stahp Right");
		}
		if(aUp == false && Input.GetKey(KeyCode.W))
		{
			Debug.Log("stahp Up");
		}
		if(aDown == false && Input.GetKey(KeyCode.S))
		{
			Debug.Log("stahp Down");
		}
	}
}
