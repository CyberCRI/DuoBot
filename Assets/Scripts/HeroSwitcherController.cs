using UnityEngine;
using System.Collections;

public class HeroSwitcherController : MonoBehaviour {

    public GameObject heroAObject;
    public GameObject heroBObject;
    
    public bool aIsActive = true;
    
    private HeroInterface heroA;
    private HeroInterface heroB;
    
	// Use this for initialization
	void Awake () 
    {
        heroA = heroAObject.GetComponent<HeroInterface>();
        heroB = heroBObject.GetComponent<HeroInterface>();
        
        //SetActivation();  
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1")) 
        {
            aIsActive = !aIsActive;

            //Debug.Log("Switching characters. aIsActive: " + (aIsActive ? "true" : "false"));
            
            SetActivation();   
        }
	}
    
    void SetActivation() 
    {
        Debug.Log("ICI ....8......." + aIsActive);
        heroA.SetIsActivated(aIsActive);    
        heroB.SetIsActivated(!aIsActive);  
    }
}
