using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
    public float scale_change_speed;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
    private float scale;

    // 记录五角星数目
    private int numOfF;

    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
        scale = 1;
        numOfF = 0;
    }

	// Each physics step..
	void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");
        if(moveHorizontal!=0 || moveVertical!=0)
        {
            scale -= scale_change_speed;
            transform.localScale =new Vector3(scale,scale,scale);

            //mass change
            rb.mass = scale;
            if (rb.mass < 0.1) rb.mass = 0.1f;
            
            //game over judgement
            if(scale<0)
            {
                Destroy(this);

            }
        }
		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce (movement * speed);
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		//if (other.gameObject.CompareTag ("Pick Up"))
		//{
			// Make the other game object (the pick up) inactive, to make it disappear
			//other.gameObject.SetActive (false);
		//}
	}

    public void incF()
    {
        numOfF++;
    }

    public int getF()
    {
        return numOfF;
    }

}