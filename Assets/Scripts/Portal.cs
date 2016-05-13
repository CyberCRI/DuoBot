using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, Switchable {

    public Transform destinationPosition;
    public string destinationScene = null;
    
    public bool isRunning = false;

    private SpriteRenderer spriteRenderer;

    public void Switch(bool on)
    {
        isRunning = true;
        spriteRenderer.color = Color.white;
    }	
    
   	// Use this for initialization
	void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(!isRunning) spriteRenderer.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () 
    {
	}
   

    void OnTriggerEnter2D(Collider2D other) 
    { 
        if(other.gameObject.CompareTag("Player") && isRunning) 
        {
            Debug.Log("Entered portal");
            
            if(destinationPosition)
                other.gameObject.transform.position = destinationPosition.position;
            else 
                SceneManager.LoadScene(destinationScene); 
        }
    }
}
