using UnityEngine;
using System.Collections;

public class ShovelHeroController : MonoBehaviour, HeroInterface {

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
        Debug.Log("On shovel. aIsActive: " + (isActivated ? "true" : "false"));

        GetComponent<SimplePlatformController>().enabled = isActivated;
        GetComponent<PickUpController>().enabled = isActivated;

        // Find camera child and enable/disable it
        foreach (Transform child in transform) 
        {
            if(child.GetComponent<Camera>()) 
            {
                child.GetComponent<Camera>().gameObject.SetActive(isActivated);        
                Debug.Log("found shovel camera child. active " + (child.GetComponent<Camera>().gameObject.activeSelf ? "true" : "false"));
            }
        }
        
        this.isActivated = isActivated;
    }
}
