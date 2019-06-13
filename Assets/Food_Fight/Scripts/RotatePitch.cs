using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Lets player rotate pitch of camera
 * Wil Bauer
 * 6-7-19
 */

public class RotatePitch : MonoBehaviour
{
    public float speedV = 2.0f;

    private float pitch = 0.0f;
    private float fixedPitch = 0.0f;
    private float yaw = 0;

    void Update()
    {
        pitch -= speedV * Input.GetAxis("Mouse Y");
        yaw = transform.eulerAngles.y;

        if (pitch > -80 && pitch < 80)
        {
            transform.eulerAngles = new Vector3(pitch, yaw, 0);
            fixedPitch = pitch;
        }
        else
        {
            transform.eulerAngles = new Vector3(fixedPitch, yaw, 0);
            pitch = fixedPitch;
        }
    }
}
