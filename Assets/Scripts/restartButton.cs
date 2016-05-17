using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class restartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {
		if (GUI.Button(new Rect(10, 10, 100, 30), "restart level"))
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
