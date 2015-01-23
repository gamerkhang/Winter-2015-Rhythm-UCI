using UnityEngine;
using System.Collections;
public enum ArrowDir{LEFT, RIGHT, UP, DOWN};
public class ArrowScript : MonoBehaviour {
	public float startTime;
	public float endTime = 3f;
	public bool isVisible;
	public float mVelocity;
	public GameObject landing;
	public bool isActive;
	public Transform mSweetSpot;
	public Transform oSweetSpot;
	public bool isPlayer1;
	public float distance;
	public LandingScript land;
	
	public bool isHold;
	public float holdDuration;
	public GameObject[] holdNotes;
	public int numOfHoldNotes;
	public GameObject holdNote;
	public bool startHold;
	public PlayerStatus pStats;
	public KeyCode mInput;
	public string LandingString;
	public string padString;
	public GameObject mCamera;
	public ArrowDir dir;
	// Use this for initialization
	void Start () {
		if (isPlayer1) {
			mCamera = GameObject.Find ("P1Camera");
		} 
		else {
			mCamera = GameObject.Find ("P2Camera");
		}
	}
	public void initialize(float sTime, float eTime, bool isPlayer, float holdD = 0f)
	{
		GameObject temp;
		pStats = GameObject.Find ("PlayerStatusManager").GetComponent<PlayerStatus>();
		holdDuration = holdD;
		startTime = sTime;
		endTime = eTime;
		isPlayer1 = isPlayer;
		holdNote = Resources.Load<GameObject>("HoldArrows");
		switch (dir) 
		{
		case ArrowDir.DOWN:
		{
			if(isPlayer1)
			{
				mInput = KeyCode.S;
				temp = GameObject.Find ("LandingPads");
				landing = GameObject.Find("DownArrowLanding");
			}else
			{
				mInput = KeyCode.DownArrow;
				temp = GameObject.Find ("LandingPads2");
				landing = GameObject.Find("DownArrowLanding2");
			}
			land = temp.GetComponent<LandingScript>();
			padString = "DownPad";
			break;
		}
		case ArrowDir.UP:
		{
			if(isPlayer1)
			{
				mInput = KeyCode.W;
				temp = GameObject.Find ("LandingPads");
				landing = GameObject.Find("UpArrowLanding");
			}else
			{
				mInput = KeyCode.UpArrow;
				temp = GameObject.Find ("LandingPads2");
				landing = GameObject.Find("UpArrowLanding2");
			}
			land = temp.GetComponent<LandingScript>();
			padString = "UpPad";
			break;
		}
		case ArrowDir.LEFT:
		{
			if(isPlayer1)
			{
				mInput = KeyCode.A;
				temp = GameObject.Find ("LandingPads");
				landing = GameObject.Find("LeftArrowLanding");
			}else
			{
				mInput = KeyCode.LeftArrow;
				temp = GameObject.Find ("LandingPads2");
				landing = GameObject.Find("LeftArrowLanding2");
			}
			land = temp.GetComponent<LandingScript>();
			padString = "LeftPad";
			break;
		}
		case ArrowDir.RIGHT:
		{
			if(isPlayer1)
			{
				mInput = KeyCode.D;
				temp = GameObject.Find ("LandingPads");
				landing = GameObject.Find("RightArrowLanding");
			}else
			{
				mInput = KeyCode.RightArrow;
				temp = GameObject.Find ("LandingPads2");
				landing = GameObject.Find("RightArrowLanding2");
			}
			land = temp.GetComponent<LandingScript>();
			padString = "RightPad";
			break;
		}
		}
		

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
				if (!pStats.p2Frozen) {
					if(Input.GetKeyDown(mInput))
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
							switch(dir)
							{
							case ArrowDir.UP:
							{
								land.aUp = false;
								break;
							}
							case ArrowDir.DOWN:
							{
								land.aDown = false;
								break;
							}
							case ArrowDir.LEFT:
							{
								land.aLeft = false;
								break;
							}
							case ArrowDir.RIGHT:
							{
								land.aRight = false;
								break;
							}
							}
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
				if (!pStats.p1Frozen) {
					if(Input.GetKeyDown (mInput))
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
							switch(dir)
							{
							case ArrowDir.UP:
							{
								land.aUp = false;
								break;
							}
							case ArrowDir.DOWN:
							{
								land.aDown = false;
								break;
							}
							case ArrowDir.LEFT:
							{
								land.aLeft = false;
								break;
							}
							case ArrowDir.RIGHT:
							{
								land.aRight = false;
								break;
							}
							}
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
		
		if(other.tag == padString)
		{
			if(land.aUp == false)
			{
				isActive = true;
				switch(dir)
				{
				case ArrowDir.UP:
				{
					land.aUp = true;
					break;
				}
				case ArrowDir.DOWN:
				{
					land.aDown = true;
					break;
				}
				case ArrowDir.LEFT:
				{
					land.aLeft = true;
					break;
				}
				case ArrowDir.RIGHT:
				{
					land.aRight = true;
					break;
				}
				}
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("here");
		if(other.tag == padString)
		{
			Debug.Log ("MISS");
			SpriteRenderer[] s = gameObject.GetComponentsInChildren<SpriteRenderer>();
			foreach(SpriteRenderer sr in s)
			{
				sr.color = new Color(0,0,0);
			}
			foreach(GameObject hold in holdNotes)
			{
				if(hold != null)
				{
					Destroy(hold);
					Debug.Log("BooM");
				}
			}
			switch(dir)
			{
			case ArrowDir.UP:
			{
				land.aUp = false;
				break;
			}
			case ArrowDir.DOWN:
			{
				land.aDown = false;
				break;
			}
			case ArrowDir.LEFT:
			{
				land.aLeft = false;
				break;
			}
			case ArrowDir.RIGHT:
			{
				land.aRight = false;
				break;
			}
			}
			pStats.UpdateMeter(isPlayer1, false);
			Destroy (gameObject,.2f);
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

		while(holdDuration > time) {
			if(!Input.GetKey (mInput))
			{

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
		switch(dir)
		{
		case ArrowDir.UP:
		{
			land.aUp = false;
			break;
		}
		case ArrowDir.DOWN:
		{
			land.aDown = false;
			break;
		}
		case ArrowDir.LEFT:
		{
			land.aLeft = false;
			break;
		}
		case ArrowDir.RIGHT:
		{
			land.aRight = false;
			break;
		}
		}
		Destroy(gameObject);
	}
}