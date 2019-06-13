using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Lets player control movement
 * Wil Bauer
 * 6-7-19
 */

public class Move : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (Input.GetButton("Fire3"))
            speed = 0.2f;
        else
            speed = 0.1f;

        rb.transform.Translate(movement * speed);
    }
}
        