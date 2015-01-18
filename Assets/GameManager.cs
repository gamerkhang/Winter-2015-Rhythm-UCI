using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class GameManager : MonoBehaviour {
	//song file read in string and song audio file readin string comes from outer static object but there
	//   still has to be links to access the instances in the gameobject
	public AudioSource song;
	public float beatInterval = 0;  //number storing 60 / bpm, set after bpm is read in
	public float currentBeat = 0; //current beat the song is on
	PriorityQueue<float, string> beatMapPQueue;
	//Player 1 Link?
	//Player 2 Link?
	//Judge Link?
	//Link to background image for p1
	//link to background image for p2
	//victory state
	public GameObject P1Spawner;
	public GameObject P2Spawner;

	// Use this for initialization
	void Start () {
		beatMapPQueue = new PriorityQueue<float, string>();
		ReadBeatMap();
		P1Spawner = GameObject.Find ("Player1Spawner");
		P2Spawner = GameObject.Find ("Player2Spawner");
		//start counting beats?
		song = GetComponent<AudioSource>();
		song.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		//increment current beat or something
		//generate arrows depending on stuff in pQueue
		if (!beatMapPQueue.IsEmpty)
		{
			string[] arrows = beatMapPQueue.Dequeue().Split(' ');
			for (int i = 0; i < arrows.Length; i++)
			{
				foreach (Transform child in P1Spawner.transform)
				{
					if (arrows[i] == child.name)
						Instantiate(Resources.Load(child.name), child.position, child.rotation);
				}
				foreach (Transform child in P2Spawner.transform)
				{
					if (arrows[i] == child.name)
						Instantiate(Resources.Load(child.name), child.position, child.rotation);
				}
			}
		}
		//how to check if game is over?
		if (!song.isPlaying)
		{
			Application.LoadLevel("Credits");
		}
	}

	void ReadBeatMap() {
		try
		{
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(Application.dataPath + "/BeatMaps/" + TestApplicationModel.beatMap, Encoding.Default);
			
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				// While there's lines left in the text file, do this:
				string line;
				do
				{
					line = theReader.ReadLine();
					if (line != null)
					{
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to ReadLine()
						string[] entries = line.Split(' ');
						if (entries.Length > 0)
							ParseBeatMapLine(entries);
					}
				}
				while (line != null);
				
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
			}
		}
		
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (System.Exception e)
		{
			Debug.Log("{0}\n" + e.Message);
		}
	}

	void ParseBeatMapLine(string[] entries) {
		//If it's a BPM specifying line it'll immediately set the beat interval based off of BPM 
		if (entries[0] == "BPM")
		{
			beatInterval = 60 / float.Parse (entries[1]);
		}
		//Else it's probably a line for arrow entries
		else {
			try
			{
				string arrows = "";
				for (int i = 1; i < entries.Length; i++) {
					arrows += entries[i];
					if (i < entries.Length-1)
						arrows += " ";
				}
				//value here is the combination of arrows to be spawned, with the priority as the beat
				beatMapPQueue.Enqueue(arrows, float.Parse(entries[0]) * beatInterval);
			}
			catch (System.Exception e)
			{
				Debug.Log("{0}\n" + e.Message);
			}
		}
	}

	//will need a way to submit scores to victory screen?
}
