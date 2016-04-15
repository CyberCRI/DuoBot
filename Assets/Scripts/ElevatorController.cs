using UnityEngine;
using System.Collections;

public class ElevatorController : MonoBehaviour, Switchable {

    public Transform endTransform;
    public float speed = 1f;
    public bool isRunning = false;

    private Vector2 startPosition;
    private Vector2 endPosition;
    private Rigidbody2D rb2d;
    private bool movingForward = true;

    public void Switch(bool on) 
    {
        isRunning = on;    
    }

	// Use this for initialization
	void Awake () 
    {
	    rb2d = GetComponent<Rigidbody2D>();
        startPosition = rb2d.position;
        endPosition = endTransform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(!isRunning) return;
        
	    if(movingForward) 
        {
            rb2d.velocity = (endPosition - startPosition).normalized * speed;
            if(Vector2.Distance(rb2d.transform.position, endPosition) < 1) 
            {
                movingForward = false;
            }

        }
        else
        {
            rb2d.velocity = (startPosition - endPosition).normalized * speed;
            if(Vector2.Distance(rb2d.transform.position, startPosition) < 1) 
            {
                movingForward = true;
            }
        }
	}
}
