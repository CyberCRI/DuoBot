using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinButton : MonoBehaviour {

	private int widthBox = 150;
	private int heightBox = 40;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width/2 - widthBox/2, Screen.height/2 - heightBox/2, widthBox, heightBox), "You win! \n click to restart"))
			SceneManager.LoadScene(0);
	}
}
