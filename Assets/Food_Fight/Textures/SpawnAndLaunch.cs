using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Spawns a random fruit and launches it randomly
 * Wil Bauer
 * 6-7-19
 */

public class SpawnAndLaunch : MonoBehaviour
{
    private int frames;
    public int framesToSkip;
    private float powerY, powerZ;
    private GameObject fruit;

    void Update()
    {
        frames++;

        if (frames % framesToSkip == 0)
        {
            //Generates a random throw force
            powerY = Random.Range(50, 1000);
            powerZ = Random.Range(50, 1000);

            //Creates a fruit to launch
            GameObject fruitToSpawn = GetComponent<ChooseRandomFruit>().ChooseAFruit();
            fruit = Instantiate(fruitToSpawn, transform.position, Quaternion.identity);
            fruit.tag = "Enemy Launched Fruit";
            fruit.name = fruitToSpawn.name;

            //Throws fruit
            Rigidbody rb = fruit.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.AddRelativeForce(0, powerY, -powerZ);
        }
    }
}
