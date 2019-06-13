using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Chooses a random fruit
 * Wil Bauer
 * 6-7-19
 */

public class ChooseRandomFruit : MonoBehaviour
{
    public GameObject[] fruits;

    public GameObject ChooseAFruit()
    {
        int ranFruit = Random.Range(0, fruits.Length);
        return fruits[ranFruit];
    }
}