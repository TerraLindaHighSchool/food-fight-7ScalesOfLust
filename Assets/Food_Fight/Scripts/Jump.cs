using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Lets player jump when and only when they are grounded
 * Wil Bauer
 * 6-7-19
 */

public class Jump : MonoBehaviour
{
    public float jumpPower;
    private bool grounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grounded = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
            grounded = true;
    }

    void Update()
    {
        if (Input.GetButton("Jump") && grounded)
        {
            if (Input.GetButton("Fire3"))
                jumpPower = 2400;
            else
                jumpPower = 1600;

            rb.AddForce(0, jumpPower, 0);
            grounded = false;
        }
    }
}
