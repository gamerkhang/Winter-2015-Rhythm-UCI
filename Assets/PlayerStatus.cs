using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour {
	//Frozen
	public bool p1upFrozen = false;
	public bool p1downFrozen = false;
	public bool p1leftFrozen = false;
	public bool p1rightFrozen = false;

	public bool p2upFrozen = false;
	public bool p2downFrozen = false;
	public bool p2leftFrozen = false;
	public bool p2rightFrozen = false;

	float p1LastFreeze;
	float p2LastFreeze;

	//Points Worth
	public int great = 1000;
	public int ok = 500;
	public int lame = 100;

	//Player values
	public int p1Score;
	public int p2Score;

	public int p1Meter;
	public int p2Meter;

	public int p1Streak;
	public int p2Streak;

	public int p1HighestStreak;
	public int p2HighestStreak;

	public Queue<string> p1Attacks;
	public Queue<string> p2Attacks;

	//UI
	public Text p1ScoreText;
	public Text p2ScoreText;
	
	public Text p1StreakText;
	public Text p2StreakText;
	
	public Text p1MeterText; 	 	
	public Text p2MeterText;
	
	public Text p1AttackText;
	public Text p2AttackText;


	// Use this for initialization
	void Start () {
		p1Score = 0;
		p2Score = 0;
		p1Meter = 0;
		p2Meter = 0;

		p1LastFreeze = 0;
		p2LastFreeze = 0;

		p1Attacks = new Queue<string> ();
		p2Attacks = new Queue<string> ();

		

		//Here make it link to the meter/score text gameobjects prob
	}
	
	// Update is called once per frame
	void Update () {
		p1ScoreText.text = "P1: " + p1Score;
		p2ScoreText.text = "P2: " + p2Score;

		p1StreakText.text = "P1 Streak: " + p1Streak;
		p2StreakText.text = "P2 Streak: " + p2Streak;
		
		p1MeterText.text = "P1 Meter: " + p1Meter;
		p2MeterText.text = "P2 Meter: " + p2Meter;

		//Unfreeze
		if (Time.time >= p1LastFreeze + 3f) {
			p1leftFrozen= false;
			p1upFrozen= false;
			p1downFrozen= false;
			p1rightFrozen= false;
		}
		if (Time.time >= p2LastFreeze + 3f) {
			p2leftFrozen= false;
			p2upFrozen= false;
			p2downFrozen= false;
			p2rightFrozen= false;
		}

		//Attacks
		if (Input.GetKey (KeyCode.LeftShift) && p1Attacks.Count > 0) {
			PlayerAttacking (true, p1Attacks.Dequeue());
			p1AttackText.text = "P1: No Attack";
		}
		if (Input.GetKey (KeyCode.RightShift) && p2Attacks.Count > 0) {
			PlayerAttacking (false, p2Attacks.Dequeue());
			
			p2AttackText.text = "P2: No Attack";
		}
	}

	public void UpdateMeter(bool isPlayer1, bool goodHit) {
		if (isPlayer1) {
			if (goodHit) {
				p1Meter++;
				p1Streak++;
				if (p1Meter >= 1) {
					p1Meter = 0;
					//where judge attack randomization goes
					p1Attacks.Enqueue("Freeze");
					p1AttackText.text = p1Attacks.Peek ();
				}
			}
			else {
				p1Meter--;
				p1Streak = 0;
				if (p1Meter <= -10) {
					p1Meter = -10;
				}
			}
		}
		else {
			if (goodHit) {
				p2Meter++;
				p2Streak++;
				if (p2Meter >= 1) {
					p2Meter = 0;
					//where judge attack randomization goes
					p2Attacks.Enqueue("Freeze");
					p2AttackText.text = p2Attacks.Peek ();
				}
			}
			else {
				p2Meter--;
				p2Streak = 0;
				if (p2Meter <= -10) {
					p2Meter = -10;
				}
			}
		}
	}
	
	void PlayerAttacking(bool isPlayer1, string attack) {
		if (isPlayer1) {
			if (attack == "Freeze") {
				//p2pads[Random.Range(0, 3)] = true;
				p2leftFrozen= true;
				p2upFrozen= true;
				p2downFrozen= true;
				p2rightFrozen= true;
				p2LastFreeze = Time.time;
			}
		}
		else {
			if (attack == "Freeze") {
				//p1pads[Random.Range(0, 3)] = true;
				p1leftFrozen= true;
				p1upFrozen= true;
				p1downFrozen= true;
				p1rightFrozen= true;
				p1LastFreeze = Time.time;
			}
		}
	}




}
