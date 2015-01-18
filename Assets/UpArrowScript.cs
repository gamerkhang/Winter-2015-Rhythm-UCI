﻿using UnityEngine;
using System.Collections;

public class UpArrowScript : MonoBehaviour {
	public float startTime;
	public float endTime = 3f;
	public bool isVisible;
	public float mVelocity;
	public GameObject landing;
	public bool isActive;
	public Transform mSweetSpot;
	public Transform oSweetSpot;
	public bool isPlayer1;
	public LandingScript land;
	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find ("LandingPads");
		land = temp.GetComponent<LandingScript>();
		landing = GameObject.Find("UpArrowLanding");
		mSweetSpot = transform.Find("SweetSpot");
		oSweetSpot = landing.transform.Find("SweetSpot");
		float distance =  landing.transform.position.y - transform.position.y ;
		Debug.Log (distance);
		Debug.Log (endTime);
		mVelocity = distance/(endTime - 0);
		transform.rigidbody2D.velocity = new Vector2(0f,mVelocity);
	}
	
	// Update is called once per frame
	void Update () {
		if(isActive)
		{
			if(isPlayer1)
			{
				if(Input.GetKeyDown(KeyCode.UpArrow))
				{
					float dist = checkAccuracy();
					if(Mathf.Abs(dist) < .1f )
					{
						Debug.Log("GREAT");
					}
					else if(Mathf.Abs(dist) < .3f )
					{
						Debug.Log("OK");
					}
					else
					{
						Debug.Log("LAME");
					}
					land.aUp = false;
					Destroy(gameObject);
				}
			}
			else{
				if(Input.GetKeyDown (KeyCode.W))
				{
					float dist = checkAccuracy();
					if(Mathf.Abs(dist) < .1f )
					{
						Debug.Log("GREAT");
					}
					else if(Mathf.Abs(dist) < .3f )
					{
						Debug.Log("OK");
					}
					else
					{
						Debug.Log("LAME");
					}
					land.aUp = false;
					Destroy(gameObject);
				}
			}
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		
		if(other.tag == "UpPad")
		{
			if(land.aUp == false)
			{
				isActive = true;
				land.aUp = true;
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("here");
		if(other.tag == "UpPad")
		{
			Debug.Log ("MISS");
			land.aUp = false;
			Destroy (gameObject);
		}
	}
	
	float checkAccuracy()
	{
		float dist = (oSweetSpot.position.y - mSweetSpot.position.y);
		Debug.Log ("Distance is " + dist);
		return dist;
	}
	void FixedUpdate(){
		
	}
}
