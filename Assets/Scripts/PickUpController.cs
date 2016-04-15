using UnityEngine;
using System.Collections;

public class PickUpController : MonoBehaviour {

    public Transform pickUpCheck;
    public Transform carryingPosition;
    public float throwForce = 1000f;
    
    private Rigidbody2D rb2d;
    
    private GameObject carryingObject;
    
    private GameObject movableGameObject;
    private FixedJoint2D fixedJoint;
    
	// Use this for initialization
	void Awake () {
	    rb2d = GetComponent<Rigidbody2D>();
        fixedJoint = GetComponent<FixedJoint2D>();
        fixedJoint.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {        
        // Can't pick up an object when carrying
        if(carryingObject) return;
        
        // Raycast to find objects to pick up
        Vector2 raycastDirection = GetComponent<SimplePlatformController>().facingRight ? Vector2.right : Vector2.left;        
	    RaycastHit2D[] castResults = Physics2D.CircleCastAll(transform.position, 0.5f, raycastDirection, Vector2.Distance(transform.position, pickUpCheck.position));
        
        // Find first object that is movable
        movableGameObject = null;
        for(int i = 0; !movableGameObject && i < castResults.Length; i++) 
        {
            if(castResults[i].rigidbody.gameObject.CompareTag("Movable")) movableGameObject = castResults[i].rigidbody.gameObject;
        }
        if(!movableGameObject) return;
	}
    
    void FixedUpdate() 
    {
        if(!Input.GetButtonDown("Jump")) return;
        
        if(carryingObject)
        {
            // Throw the object
            fixedJoint.enabled = false; 
            fixedJoint.connectedBody = null;
            
            Vector2 throwDirection = GetComponent<SimplePlatformController>().facingRight ? new Vector2(1, 1) : new Vector2(-1, 1);        
            carryingObject.GetComponent<Rigidbody2D>().AddForce(throwDirection * throwForce);
            
            carryingObject = null;            
        }
        else if(movableGameObject)
        {
            // Pick up the object
            
            carryingObject = movableGameObject;
            movableGameObject = null;
           
            // Move object to carrying position
            carryingObject.transform.position = carryingPosition.position;
            carryingObject.transform.rotation = carryingPosition.rotation;
                        
            // Attach it to the joint
            fixedJoint.connectedBody = carryingObject.GetComponent<Rigidbody2D>();
            fixedJoint.enabled = true; 
        } 
    }
}
