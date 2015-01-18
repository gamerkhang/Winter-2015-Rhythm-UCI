using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChooseSong : MonoBehaviour {

	public Text songStats;
	public Button startGame;
	void Start () {

	}

	public void OnButtonPress(string songName) {
		songStats.enabled = true;
		ApplicationModel.song = songName;
		switch (songName) {
		case "I_Need_Your_Love":
			songStats.text = "Title: I Need Your Love\n" +
				"by Pentatonix\n" +
				"Length: 3:03\n" +
				"Genre: Acapella\n" +
				"High Score: ";
			break;
		case "Natural_Green":
			songStats.text = "Title: Natural Green\n" +
					"by Blazo\n" +
					"Length: 2:24\n" +
					"Genre: Jazz, Hip Hop\n" +
					"High Score: 100,200,300";
			break;
		}
		startGame.GetComponent<Button> ().enabled = true;
		startGame.GetComponent<Image> ().enabled = true;
		startGame.GetComponentInChildren<Text> ().enabled = true;
	}
}