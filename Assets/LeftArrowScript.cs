using UnityEngine;
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
		// Use this for initialization
	void Start () {
		GameObject temp;
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
				if(Input.GetKeyDown(KeyCode.LeftArrow))
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
					land.aLeft = false;
					Destroy(gameObject);
				}
			}
			else{
				if(Input.GetKeyDown (KeyCode.A))
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
					land.aLeft = false;
					Destroy(gameObject);
				}
			}
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if(isPlayer1)
		{
			if(other.tag == "LeftPad" && other.gameObject.layer == 8)
			{
				if(land.aLeft == false)
				{
				isActive = true;
					land.aLeft = true;
				}
			}
		}else
		{
			if(other.tag == "LeftPad" && other.gameObject.layer == 9)
			{
				if(land.aLeft == false)
				{
					isActive = true;
					land.aLeft = true;
				}
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("here");
		if(other.tag == "LeftPad")
		{
			Debug.Log ("MISS");
			land.aLeft = false;
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
