using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class TextInput : MonoBehaviour {
	public string stuff;

	// Use this for initialization
	void Start () {
		try
		{
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(Application.dataPath + "/" + "test.txt", Encoding.Default);
			
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				// While there's lines left in the text file, do this:
				do
				{
					line = theReader.ReadLine();
					
					if (line != null)
					{
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()
						string[] entries = line.Split(',');
						if (entries.Length > 0)
							Debug.Log(entries[0]);
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

// Update is called once per frame
void Update () {
	if (Input.GetButtonDown("Attack"))
	{
		Debug.Log("stuff");
	}
}
}
