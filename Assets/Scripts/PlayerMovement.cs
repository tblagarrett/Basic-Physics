using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float thrust;
    public float rotation;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Backwards and Forwards Movement
        if (rb.velocity.magnitude < thrust) { 
            if (Input.GetAxis("Vertical") > 0)
            {
                rb.AddRelativeForce(Vector3.forward * thrust);
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                rb.AddRelativeForce(-1 * Vector3.forward * thrust);
            }
        }

        rotation = Input.GetAxis("Horizontal");
        // Side to Side rotation
        if (rotation > 0)
        {
            rb.AddRelativeTorque(Vector3.up);
        }
        if (rotation < 0) {
            rb.AddRelativeTorque(Vector3.down);
        }
        if (Mathf.Abs(rotation) < 0.1)
        {
            rb.angularVelocity = Vector3.zero;
        }
    }
}
