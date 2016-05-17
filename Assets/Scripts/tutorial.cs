using UnityEngine;
using System.Collections;

public class tutorial : MonoBehaviour {
	public string text = "this is the tutorial"; // you can put a \n to add a line
	public int secondsForRead = 3;
	public int widthBox = 300;
	public int heightBox = 30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(Time.time <= secondsForRead){
			GUI.Box(new Rect(200, 200, widthBox, heightBox), text);
		}
	}
}
