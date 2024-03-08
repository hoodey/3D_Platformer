using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] int speed = 2;
    [SerializeField] float groundCheckDistance = 1f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] Animator anim;
    [SerializeField] LayerMask environmentOnly;

    //Fields
    Rigidbody rb;
    bool onGround = false;
    Transform cam;
    float fmi; //forward movement input = fmi 
    float rmi; //right movement input = rmi

    //[SerializeField] UnityEvent OnJump //This is for creating an on jump event to trigger like a particle animation
    //UnityAction OnJumpA

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Conditional to track whether we are on ground (by sending a raycast into the floor)
        onGround = (Physics.Raycast(transform.position, Vector3.up * -1, groundCheckDistance, environmentOnly));

        //Create movement controls based on input from the left/right axis, and forward/back axis
        fmi = Input.GetAxis("Vertical");
        rmi = Input.GetAxis("Horizontal");

        //Jump logic
        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }

        //code for an event on jump (this should be in the jump logic)
        // OnJump.Invoke();
        //OnJumpA.Invoke();
    }

    //Fixed Update for physics based updates
    private void FixedUpdate()
    {
        //Vector3's for different object's transform data
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;
        //This code will keep our vertical at 0 for our cam because we only want to face our character left/right and forward/back, not up/down
        camForward.y = 0;
        camForward.Normalize();
        camRight.y = 0;
        camRight.Normalize();
        //Create a vector3 that depends on the direction the camera is facing
        Vector3 forwardRelative = fmi * camForward;
        Vector3 rightRelative = rmi * camRight;

        //Create a vector3 that controls what direction our character travels, multiply that direction by speed (magnitude)
        Vector3 movementVector = (forwardRelative + rightRelative).normalized * speed;

        //Sets our animations transform according to movementVector
        if (movementVector != Vector3.zero)
            anim.transform.forward = movementVector;
        //match our y vector direction to our y velocity
        movementVector.y = rb.velocity.y;
        rb.velocity = movementVector;
        

        //This sets the speed variable to the magnitude of movement in order to trigger walking/running anim
        anim.SetFloat("speed", movementVector.magnitude);
        
    }
}
