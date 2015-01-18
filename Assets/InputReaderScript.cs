using UnityEngine;
using System.Collections;

public enum ButtonsPressed { NOTHING, LEFT, RIGHT, UP , DOWN , LEFTRIGHT, LEFTUP, LEFTDOWN, 
	RIGHTUP, RIGHTDOWN, UPDOWN, LEFTRIGHTUP, LEFTRIGHTDOWN, LEFTUPDOWN,RIGHTUPDOWN,
	LEFTRIGHTUPDOWN}

public class InputReaderScript : MonoBehaviour {
	public float inputTolerence = 0.05f;
	//2frames
	public float inputWindow = 0.032f;
	public float lastInputWindow;
	public float lastInputTime1;
	public float lastInputTime2;
	public ButtonsPressed lastInput1;
	public ButtonsPressed lastInput2;
	public ButtonsPressed currentInput1;
	public ButtonsPressed currentInput2;
	public int nInputs1;
	public int nInputs2;
	public int mInputs1;
	public int mInputs2;
	// Use this for initialization
	void Start () {
		currentInput1 = ButtonsPressed.NOTHING;
		currentInput2 = ButtonsPressed.NOTHING;
		lastInputWindow = Time.time;
		nInputs1 = 0;
		mInputs1 = -1;
		nInputs2 = 0;
		mInputs2 = -1;
	}
	
	// Update is called once per frame
	void Update () {
		//if in a input window record inputs
		if(Time.time < lastInputWindow + inputWindow)
		{
			ParseInputPlayer1();
			ParseInputPlayer2();

		}
		//else start a new input window and clear inputs
		else
		{
			lastInputWindow = Time.time;
			currentInput1 = ButtonsPressed.NOTHING;
			currentInput2 = ButtonsPressed.NOTHING;
			nInputs1 = 0;
			mInputs1 = -1;
			nInputs2 = 0;
			mInputs2 = -1;
			ParseInputPlayer1();
			ParseInputPlayer2();
		}

	}

	void ParseInputPlayer1()
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			if(nInputs1 == 0)
			{
			currentInput1 = ButtonsPressed.LEFT;
			nInputs1++;
			}
			if(Input.GetKey (KeyCode.RightArrow))
			{
				if(nInputs1 == 1)
				{
				currentInput1 = ButtonsPressed.LEFTRIGHT;
				nInputs1++;
				}
				if(Input.GetKey (KeyCode.UpArrow))
				{
					if(nInputs1 ==2)
					{
					currentInput1 = ButtonsPressed.LEFTRIGHTUP;
					nInputs1++;
					}
					if(Input.GetKey (KeyCode.DownArrow))
					{
						if(nInputs1 ==3)
						{
						currentInput1 = ButtonsPressed.LEFTRIGHTUPDOWN;
						nInputs1++;
						}
					}
				}else if(Input.GetKey (KeyCode.DownArrow))
				{
					if(nInputs1 == 2)
					{
					currentInput1 = ButtonsPressed.LEFTRIGHTDOWN;
					nInputs1++;
					}
				}
			}else if(Input.GetKey (KeyCode.UpArrow))
			{
				if(nInputs1 == 1)
				{
				currentInput1 = ButtonsPressed.LEFTUP;
				nInputs1++;
				}
				if(Input.GetKey (KeyCode.DownArrow))
				{
					if(nInputs1 == 2)
					{
					currentInput1 = ButtonsPressed.LEFTUPDOWN;
					nInputs1++;
					}
				}
			}else if(Input.GetKey (KeyCode.DownArrow))
			{
				if(nInputs1 == 1)
				{
				currentInput1 = ButtonsPressed.LEFTDOWN;
				nInputs1++;
				}
			}
		}else if(Input.GetKey (KeyCode.RightArrow))
		{
			if(nInputs1 == 0)
			{
			currentInput1 = ButtonsPressed.RIGHT;
			nInputs1++;
			}
			if(Input.GetKey (KeyCode.UpArrow))
			{
				if(nInputs1 == 1)
				{
				currentInput1 = ButtonsPressed.RIGHTUP;
				nInputs1++;
				}
				if(Input.GetKey (KeyCode.DownArrow))
				{
					if(nInputs1 == 2)
					{
					currentInput1 = ButtonsPressed.RIGHTUPDOWN;
					nInputs1++;
					}
				}
			}else if(Input.GetKey (KeyCode.DownArrow))
			{
				if(nInputs1 == 1)
				{
				currentInput1 = ButtonsPressed.RIGHTDOWN;
				nInputs1++;
				}
			}
		}
		else if(Input.GetKey (KeyCode.UpArrow))
		{
			if(nInputs1 == 0)
			{
			currentInput1 = ButtonsPressed.UP;
			nInputs1++;
			}
			if(Input.GetKey (KeyCode.DownArrow))
			{
				if(nInputs1 == 1)
				{
				currentInput1 = ButtonsPressed.UPDOWN;
				nInputs1++;
				}
			}
		}
		else if(Input.GetKey (KeyCode.DownArrow))
		{
			if(nInputs1 == 0)
			{
			currentInput1 = ButtonsPressed.DOWN;
			nInputs1++;
			}
		}

		if(nInputs1 > mInputs1 && currentInput1 != ButtonsPressed.NOTHING)
		{
			lastInput1 = currentInput1;
			lastInputTime1 = Time.time;
			mInputs1 = nInputs1;
			Debug.Log(currentInput1);
		}
	}

	void ParseInputPlayer2()
	{
		if(Input.GetKey(KeyCode.A))
		{
			if(nInputs2 == 0)
			{
				currentInput2 = ButtonsPressed.LEFT;
				nInputs2++;
			}
			if(Input.GetKey (KeyCode.D))
			{
				if(nInputs2 == 1)
				{
					currentInput2 = ButtonsPressed.LEFTRIGHT;
					nInputs2++;
				}
				if(Input.GetKey (KeyCode.W))
				{
					if(nInputs2 ==2)
					{
						currentInput2 = ButtonsPressed.LEFTRIGHTUP;
						nInputs2++;
					}
					if(Input.GetKey (KeyCode.S))
					{
						if(nInputs2 ==3)
						{
							currentInput2 = ButtonsPressed.LEFTRIGHTUPDOWN;
							nInputs2++;
						}
					}
				}else if(Input.GetKey (KeyCode.S))
				{
					if(nInputs2 == 2)
					{
						currentInput2 = ButtonsPressed.LEFTRIGHTDOWN;
						nInputs2++;
					}
				}
			}else if(Input.GetKey (KeyCode.W))
			{
				if(nInputs2 == 1)
				{
					currentInput2 = ButtonsPressed.LEFTUP;
					nInputs2++;
				}
				if(Input.GetKey (KeyCode.S))
				{
					if(nInputs2 == 2)
					{
						currentInput2 = ButtonsPressed.LEFTUPDOWN;
						nInputs2++;
					}
				}
			}else if(Input.GetKey (KeyCode.S))
			{
				if(nInputs2 == 1)
				{
					currentInput2 = ButtonsPressed.LEFTDOWN;
					nInputs2++;
				}
			}
		}else if(Input.GetKey (KeyCode.D))
		{
			if(nInputs2 == 0)
			{
				currentInput2 = ButtonsPressed.RIGHT;
				nInputs2++;
			}
			if(Input.GetKey (KeyCode.W))
			{
				if(nInputs2 == 1)
				{
					currentInput2 = ButtonsPressed.RIGHTUP;
					nInputs2++;
				}
				if(Input.GetKey (KeyCode.S))
				{
					if(nInputs2 == 2)
					{
						currentInput2 = ButtonsPressed.RIGHTUPDOWN;
						nInputs2++;
					}
				}
			}else if(Input.GetKey (KeyCode.S))
			{
				if(nInputs2 == 1)
				{
					currentInput2 = ButtonsPressed.RIGHTDOWN;
					nInputs2++;
				}
			}
		}
		else if(Input.GetKey (KeyCode.W))
		{
			if(nInputs2 == 0)
			{
				currentInput2 = ButtonsPressed.UP;
				nInputs2++;
			}
			if(Input.GetKey (KeyCode.S))
			{
				if(nInputs2 == 1)
				{
					currentInput2 = ButtonsPressed.UPDOWN;
					nInputs2++;
				}
			}
		}
		else if(Input.GetKey (KeyCode.S))
		{
			if(nInputs2 == 0)
			{
				currentInput2 = ButtonsPressed.DOWN;
				nInputs2++;
			}
		}
		
		if(nInputs2 > mInputs2 && currentInput2 != ButtonsPressed.NOTHING)
		{
			lastInput2 = currentInput2;
			lastInputTime2 = Time.time;
			mInputs2 = nInputs2;
			Debug.Log(currentInput2);
		}
	}
}
