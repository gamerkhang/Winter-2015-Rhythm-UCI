﻿using UnityEngine;
using System.Collections;

public class LeftArrowScript : MonoBehaviour {
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
	public float distance;
	
	public bool isHold;
	public float holdDuration;
	public GameObject[] holdNotes;
	public int numOfHoldNotes;
	public GameObject holdNote;
	public bool startHold;
	public PlayerStatus pStats;
		// Use this for initialization
	void Start () {

	}
	public void initialize(float sTime, float eTime, bool isPlayer, float holdD = 0f)
	{
		pStats = GameObject.Find ("PlayerStatusManager").GetComponent<PlayerStatus>();
		holdDuration = holdD;
		startTime = sTime;
		endTime = eTime;
		isPlayer1 = isPlayer;
		GameObject temp;
		holdNote = Resources.Load<GameObject>("HoldArrows");
		if(isPlayer1)
		{
			temp = GameObject.Find ("LandingPads");
			landing = GameObject.Find("LeftArrowLanding");
		}else
		{
			temp = GameObject.Find ("LandingPads2");
			landing = GameObject.Find("LeftArrowLanding2");
		}
		land = temp.GetComponent<LandingScript>();
		mSweetSpot = transform.Find("SweetSpot");
		oSweetSpot = landing.transform.Find("SweetSpot");
		distance =  landing.transform.position.y - transform.position.y ;
//		Debug.Log (distance);
//		Debug.Log (endTime);
		mVelocity = distance/(endTime - startTime);
		transform.rigidbody2D.velocity = new Vector2(0f,mVelocity);

		if(holdDuration > 0)
		{
			isHold = true;
			float holdLength = mVelocity * holdDuration;
			float backPoint = transform.position.y - holdLength;
			int counter = 0;
			for(float i = transform.position.y - .1f; i > backPoint; i -= .3f)
			{
				counter++;
			}
			holdNotes = new GameObject[counter];
			numOfHoldNotes = counter;
			counter = 0;
			for(float i = transform.position.y - .1f; i > backPoint; i -= .3f)
			{
				holdNotes[counter] = (GameObject)Instantiate(holdNote,new Vector2(transform.position.x,i),transform.rotation);
				holdNotes[counter].transform.FindChild("Sprite").rotation = transform.FindChild ("ArrowSprite").rotation;
				holdNotes[counter].rigidbody2D.velocity = transform.rigidbody2D.velocity;
				counter++;
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		if(isActive)
		{
			if(!isPlayer1)
			{
				if (!pStats.p2leftFrozen) {
					if(Input.GetKeyDown(KeyCode.LeftArrow))
					{
						float dist = checkAccuracy();
						if(Mathf.Abs(dist) < .1f )
						{
							pStats.p2Score += pStats.great;
						}
						else if(Mathf.Abs(dist) < .3f )
						{
							pStats.p2Score += pStats.ok;
						}
						else
						{
							pStats.p2Score += pStats.lame;
						}
						pStats.UpdateMeter(isPlayer1, true);
						if(!isHold)
						{
							land.aLeft = false;
							Destroy(gameObject);
						}else
						{
							transform.position = landing.transform.Find("SweetSpot").position;
							transform.rigidbody2D.velocity = Vector2.zero;
							startHold = true;
							StartCoroutine("holdTheNote");
						}
					}
				}
			}
			else{
				if (!pStats.p1leftFrozen) {
					if(Input.GetKeyDown (KeyCode.A))
					{
						float dist = checkAccuracy();
						if(Mathf.Abs(dist) < .1f )
						{
							pStats.p1Score += pStats.great;
						}
						else if(Mathf.Abs(dist) < .3f )
						{
							pStats.p1Score += pStats.ok;
						}
						else
						{
							pStats.p1Score += pStats.lame;
						}
						pStats.UpdateMeter(isPlayer1, true);
						if(!isHold)
						{
							land.aLeft = false;
							Destroy(gameObject);
						}else
						{
							transform.position = landing.transform.Find("SweetSpot").position;
							transform.rigidbody2D.velocity = Vector2.zero;
							startHold = true;
							StartCoroutine("holdTheNote");
						}
					}
				}
			}
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "LeftPad")
		{
			if(land.aLeft == false)
			{
				isActive = true;
				land.aLeft = true;
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("here");
		if(other.tag == "LeftPad")
		{
			Debug.Log ("MISS");
			foreach(GameObject hold in holdNotes)
			{
				if(hold != null)
				{
					Destroy(hold);
					Debug.Log("BooM");
				}
			}
			land.aLeft = false;
			pStats.UpdateMeter(isPlayer1, false);
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
	IEnumerator holdTheNote() {
		float time = 0;
		KeyCode temp;
		if(isPlayer1)
		{
			temp = KeyCode.LeftArrow;
		}else
		{
			temp = KeyCode.A;
		}
		while(holdDuration > time) {
			if(!Input.GetKey (temp))
			{
				Debug.Log ("Pressing" + temp + "is " + Input.GetKey(temp));
				time = holdDuration + 1;
			}
			foreach(GameObject hold in holdNotes)
			{
				if(hold != null)
				{
					if(Mathf.Abs(hold.transform.FindChild ("SweetSpot").transform.position.y - 
					             landing.transform.FindChild("SweetSpot").transform.position.y) <.05f)
					{
						Destroy(hold);
						Debug.Log ("HELD");
					}else if(hold.transform.FindChild ("SweetSpot").transform.position.y > 
					         landing.transform.FindChild("SweetSpot").transform.position.y )
					{
						Destroy (hold);
					}
				}
			}
			time += Time.deltaTime;
			yield return null;
		}
		
		foreach(GameObject hold in holdNotes)
		{
			if(hold != null)
			{
				Destroy(hold);
				Debug.Log("BooM");
			}
		}
		land.aLeft = false;
		Destroy(gameObject);
	}

}