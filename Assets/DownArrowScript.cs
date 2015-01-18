using UnityEngine;
using System.Collections;

public class DownArrowScript : MonoBehaviour {
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
				if(Input.GetKeyDown(KeyCode.DownArrow))
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
					land.aDown = false;
					Destroy(gameObject);
				}
			}
			else{
				if(Input.GetKeyDown (KeyCode.S))
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
					land.aDown = false;
					Destroy(gameObject);
				}
			}
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{

		if(other.tag == "DownPad")
		{
			if(land.aDown == false)
			{
				isActive = true;
				land.aDown = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("here");
		if(other.tag == "DownPad")
		{
			Debug.Log ("MISS");
			land.aDown = false;
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
