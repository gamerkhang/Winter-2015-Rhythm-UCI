﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChooseSong : MonoBehaviour {

	public AudioClip Song0;
	public AudioClip Song1;

	public Text songStats;
	public Button startGame;

	void Start () {

	}

	public void OnButtonPress(string fileName) {
		songStats.enabled = true;
		ApplicationModel.beatMap = fileName;
		switch (fileName) {
		case "Song0.txt":
			songStats.text = "Title: Start Shootin\n" +
				"by Little People\n" +
				"Length: 3:03\n" +
				"Genre: Acapella\n" +
				"High Score: ";
				audio.clip = Song0;
			ApplicationModel.songaudiofile = Song0;
				audio.Play();
			break;
		case "Song1.txt":
			songStats.text = "Title: Natural Green\n" +
				"by Blazo\n" +
				"Length: 2:24\n" +
				"Genre: Jazz, Hip Hop\n" +
				"High Score: 100,200,300";
				audio.clip = Song1;
				ApplicationModel.songaudiofile = Song1;
				audio.Play();
			break;
		}

		startGame.GetComponent<Button> ().enabled = true;
		startGame.GetComponent<Image> ().enabled = true;
		startGame.GetComponentInChildren<Text> ().enabled = true;
	}
}