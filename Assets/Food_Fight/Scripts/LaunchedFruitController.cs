using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Checks if fruit has hit a part of the room
 * Wil Bauer
 * 6-7-19
 */

public class LaunchedFruitController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Wall")
            gameObject.tag = "Fruit";
    }
}