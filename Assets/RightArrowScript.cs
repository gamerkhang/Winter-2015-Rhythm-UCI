using UnityEngine;
using System.Collections;

public class RightArrowScript : MonoBehaviour {
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
	// Use this for initialization
	void Start () {
		
	}
	public void initialize(float sTime, float eTime, bool isPlayer)
	{
		startTime = sTime;
		endTime = eTime;
		isPlayer1 = isPlayer;
		GameObject temp;
		if(isPlayer1)
		{
			temp = GameObject.Find ("LandingPads");
			landing = GameObject.Find("DownArrowLanding");
		}else
		{
			temp = GameObject.Find ("LandingPads2");
			landing = GameObject.Find("DownArrowLanding2");
		}
		land = temp.GetComponent<LandingScript>();
		mSweetSpot = transform.Find("SweetSpot");
		oSweetSpot = landing.transform.Find("SweetSpot");
		distance =  landing.transform.position.y - transform.position.y ;
//		Debug.Log (distance);
//		Debug.Log (endTime);
		mVelocity = distance/(endTime - startTime);
		transform.rigidbody2D.velocity = new Vector2(0f,mVelocity);
	}

	
	// Update is called once per frame
	void Update () {
		if(isActive)
		{
			if(isPlayer1)
			{
				if(Input.GetKeyDown(KeyCode.RightArrow))
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
					land.aRight = false;
					Destroy(gameObject);
				}
			}
			else{
				if(Input.GetKeyDown (KeyCode.D))
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
					land.aRight = false;
					Destroy(gameObject);
				}
			}
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		
		if(other.tag == "RightPad")
		{
			if(land.aRight == false)
			{
				isActive = true;
				land.aRight = true;
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("here");
		if(other.tag == "RightPad")
		{
			Debug.Log ("MISS");
			land.aRight = false;
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
