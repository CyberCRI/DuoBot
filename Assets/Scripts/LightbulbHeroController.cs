using UnityEngine;
using System.Collections;

public class LightbulbHeroController : MonoBehaviour, HeroInterface {

    public bool isActivated = true;

	// Use this for initialization
	void Awake () {
	    SetIsActivated(isActivated);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void SetIsActivated(bool isActivated)
    {
        Debug.Log("On lightbulb. aIsActive: " + (isActivated ? "true" : "false"));

        GetComponent<SimplePlatformController>().enabled = isActivated;

        // Find camera child and enable/disable it
        foreach (Transform child in transform) 
        {
            if(child.gameObject.GetComponent<Camera>()) 
            {
                child.gameObject.GetComponent<Camera>().gameObject.SetActive(isActivated);        
                Debug.Log("found lightbulb camera child. active " + (child.GetComponent<Camera>().gameObject.activeSelf ? "true" : "false"));
            }
        }
        
        this.isActivated = isActivated;
    }
}
