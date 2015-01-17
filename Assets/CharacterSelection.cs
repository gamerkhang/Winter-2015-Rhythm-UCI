using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelection : MonoBehaviour {

	//Players can't select same character
	

	public int totalChar;
	bool P1Lock;
	bool P2Lock;
	public Sprite UnlockedSprite;
	public Sprite LockedSprite;

	//Players
	public GameObject P1Select;
	public GameObject P2Select;
	public GameObject P1Cursor;
	public GameObject P2Cursor;
	public Sprite P1CurrSprite;
	public Sprite P2CurrSprite;

	public GameObject SongSelect;

	public List<GameObject> CharList;

	public Text P1SelectStats;
	public Text P2SelectStats;

	static string Char0Stats = "Name: Cactus\n" +
		"Dance Style: Break\n" +
		"Hometown: Desert\n" +
		"Age: 20\n";
	static string Char1Stats = "Name: Bro\n" +
		"Dance Style: Brodown\n" +
		"Hometown: Westwood\n" +
		"Age: 5\n";
	static string Char2Stats = "Name: Redhead\n" +
		"Dance Style: BLah\n" +
		"Hometown: Dewefawefafet\n" +
		"Age: 25\n";
	static string Char3Stats = "Name: Girl\n" +
		"Dance Style: aweofiajwfoiawjef\n" +
		"Hometown: Dawefawe\n" +
		"Age: 2039402984\n";

	// Use this for initialization
	void Start () {
		P1Lock = false;
		P2Lock = false;
		totalChar = 3;
		CharList = new List<GameObject> ();
		for (int i = 1; i <= totalChar+1; i++) {
			CharList.Add (GameObject.Find ("Character" + i));
		}
		ApplicationModel.P1Char = 0;
		ApplicationModel.P2Char = 3;
		P1CurrSprite = P1Select.GetComponent<SpriteRenderer> ().sprite = GameObject.Find ("Character1").GetComponent<SpriteRenderer>().sprite;
		P2CurrSprite = P2Select.GetComponent<SpriteRenderer> ().sprite = GameObject.Find ("Character2").GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		//Character POS:
		//1: -211.5, -120
		//2: -70.5, -120
		//3: 70.5, -120
		//4: -211.5, -120
		if (!P1Lock) {
			if (Input.GetKeyUp(KeyCode.A)) {
				if (ApplicationModel.P1Char == 0)
					ApplicationModel.P1Char = totalChar;
				else {
					ApplicationModel.P1Char--;
				}
				if (ApplicationModel.P1Char == ApplicationModel.P2Char) {
					if (ApplicationModel.P2Char == 0) {
						ApplicationModel.P1Char = totalChar;
					}
					else {
						ApplicationModel.P1Char = ApplicationModel.P2Char - 1;
					}
				}
			}
			else if (Input.GetKeyUp(KeyCode.D)) {
				if (ApplicationModel.P1Char == totalChar)
					ApplicationModel.P1Char = 0;
				else {
					ApplicationModel.P1Char++;
				}

				if (ApplicationModel.P1Char == ApplicationModel.P2Char) {
					if (ApplicationModel.P2Char == totalChar) {
						ApplicationModel.P1Char = 0;
					}
					else {
						ApplicationModel.P1Char = ApplicationModel.P2Char + 1;
					}
				}
			}
			else if (Input.GetKeyUp(KeyCode.W)) {
				//LOCK P1 CHARACTER SELECT
				P1Lock = true;
				P1Cursor.GetComponent<SpriteRenderer> ().sprite = LockedSprite;
				P1Cursor.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (40f, 40f, 0f);

			}

			P1Select.GetComponent<SpriteRenderer> ().sprite = CharList[ApplicationModel.P1Char].GetComponent<SpriteRenderer> ().sprite;
			switch (ApplicationModel.P1Char) {
				case 0:
					P1SelectStats.GetComponent<Text> ().text = Char0Stats;	
					break;
				case 1:
					P1SelectStats.GetComponent<Text> ().text = Char1Stats;
					break;
				case 2:
					P1SelectStats.GetComponent<Text> ().text = Char2Stats;
					break;
				case 3:
					P1SelectStats.GetComponent<Text> ().text = Char3Stats;
					break;
			}

			P1Cursor.transform.localPosition = new Vector3 (CharList[ApplicationModel.P1Char].transform.localPosition.x, -120f, 0f);
		}
		else {
			if (Input.GetKeyUp(KeyCode.S)) {
				P1Lock = false;
				P1Cursor.GetComponent<SpriteRenderer> ().sprite = UnlockedSprite;
				P1Cursor.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (100f, 100f, 0f);
			}
		}

		if (!P2Lock) {
			if (Input.GetKeyUp(KeyCode.LeftArrow)) {
				if (ApplicationModel.P2Char == 0)
					ApplicationModel.P2Char = totalChar;
				else {
					ApplicationModel.P2Char--;
				}
				if (ApplicationModel.P2Char == ApplicationModel.P1Char) {
					if (ApplicationModel.P1Char == 0) {
						ApplicationModel.P2Char = totalChar;
					}
					else {
						ApplicationModel.P2Char = ApplicationModel.P1Char - 1;
					}
				}
			}
			else if (Input.GetKeyUp(KeyCode.RightArrow)) {
				if (ApplicationModel.P2Char == totalChar)
					ApplicationModel.P2Char = 0;
				else {
					ApplicationModel.P2Char++;
				}
				if (ApplicationModel.P2Char == ApplicationModel.P1Char) {
					if (ApplicationModel.P1Char == totalChar) {
						ApplicationModel.P2Char = 0;
					}
					else {
						ApplicationModel.P2Char = ApplicationModel.P1Char + 1;
					}
				}
			}
			else if (Input.GetKeyUp(KeyCode.UpArrow)) {
				//LOCK P2 CHARACTER SELECT
				P2Lock = true;
				P2Cursor.GetComponent<SpriteRenderer> ().sprite = LockedSprite;
				P2Cursor.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (40f, 40f, 0f);
			}
			P2Select.GetComponent<SpriteRenderer> ().sprite = CharList[ApplicationModel.P2Char].GetComponent<SpriteRenderer> ().sprite;
			switch (ApplicationModel.P2Char) {
				case 0:
					P2SelectStats.GetComponent<Text> ().text = Char0Stats;	
					break;
				case 1:
					P2SelectStats.GetComponent<Text> ().text = Char1Stats;
					break;
				case 2:
					P2SelectStats.GetComponent<Text> ().text = Char2Stats;
					break;
				case 3:
					P2SelectStats.GetComponent<Text> ().text = Char3Stats;
					break;
			}																				//Insert Text Here
			P2Cursor.transform.localPosition = new Vector3 (CharList[ApplicationModel.P2Char].transform.localPosition.x, -120f, 0f);
		}
		else {
			if (Input.GetKey(KeyCode.DownArrow)) {
				P2Lock = false;
				P2Cursor.GetComponent<SpriteRenderer> ().sprite = UnlockedSprite;
				P2Cursor.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (100f, 100f, 0f);
			}
		}

		if (P1Lock && P2Lock) {
			SongSelect.GetComponent<Button> ().enabled = true;
			SongSelect.GetComponent<Image> ().enabled = true;
			SongSelect.GetComponentInChildren<Text> ().enabled = true;
		}
		else {
			SongSelect.GetComponent<Button> ().enabled = false;
			SongSelect.GetComponent<Image> ().enabled = false;
			SongSelect.GetComponentInChildren<Text> ().enabled = false;
		}
	}
}