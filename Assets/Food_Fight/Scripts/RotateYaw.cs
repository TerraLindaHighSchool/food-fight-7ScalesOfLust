using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Lets player rotate the player object's yaw
 * Wil Bauer
 * 6-7-19
 */

public class RotateYaw : MonoBehaviour
{
    public float speedH = 2.0f;

    private float yaw = 0.0f;

    void Update()
    {
            yaw += speedH * Input.GetAxis("Mouse X");

            transform.eulerAngles = new Vector3(0, yaw, 0);
    }
}
