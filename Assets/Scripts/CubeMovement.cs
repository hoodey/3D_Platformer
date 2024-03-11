using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] float cubeSpeed = 2f;
    Rigidbody rb;
    Vector3 movementVector = new Vector3(0,0,1);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
        rb.velocity = movementVector * cubeSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        cubeSpeed *= -1;
    }
}
