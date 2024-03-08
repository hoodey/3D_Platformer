using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] int speed;
    float forwardMovementInput;
    float rightMovementInput;
    Rigidbody rb;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float groundCheckDistance = 1;
    bool onGround = false;
    [SerializeField] LayerMask environmentOnly;
    [SerializeField] Animator anim;
    [SerializeField] PlayerStats stats;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        onGround = (Physics.Raycast(transform.position, Vector3.up * -1, groundCheckDistance, environmentOnly));

        forwardMovementInput = Input.GetAxis("Vertical");
        rightMovementInput = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.velocity += Vector3.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            anim.SetTrigger("jump");
            //stats.CurrentHealth -= 1; This is for modifying stats (use in a different capacity)
        }

        

        //Debug.DrawLine(transform.position, transform.position + transform.up * groundCheckDistance, Color.red);
    }

    private void FixedUpdate()
    {
        
        
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camForward.Normalize();

        camRight.y = 0;
        camRight.Normalize();

        Vector3 forwardRelative = forwardMovementInput * camForward;
        Vector3 rightRelative = rightMovementInput * camRight;

        Vector3 movementVector = (forwardRelative + rightRelative).normalized * speed;
       
        movementVector.y = rb.velocity.y;
        rb.velocity = movementVector;

        anim.SetFloat("speed", movementVector.magnitude);

        anim.transform.forward = movementVector;
    }
}
