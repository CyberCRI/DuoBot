using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

    public GameObject switchableObject;

    private bool playerIsTouching = false;
    private SpriteRenderer spriteRenderer;
    private Switchable switchable;

	// Use this for initialization
	void Awake () {
	    spriteRenderer = GetComponent<SpriteRenderer>();
        switchable = switchableObject.GetComponent<Switchable>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Jump") && playerIsTouching) 
        {
            switchable.Switch(true);
            spriteRenderer.color = Color.red;
        }
	}
    
    void OnTriggerEnter2D(Collider2D other) 
    { 
        if(other.gameObject.CompareTag("Player")) 
        {
            playerIsTouching = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    { 
        if(other.gameObject.CompareTag("Player")) 
        {
            playerIsTouching = false;
        }
    }    
}
