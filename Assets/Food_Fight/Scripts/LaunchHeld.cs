using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Throws fruit on player command a player determined distance
 * Wil Bauer
 * 6-7-19
 */

public class LaunchHeld : MonoBehaviour
{
    private GameObject fruitToLaunch;
    private PickUpAndHold pickedUpAndHeld;
    private float notifFrames, chargeFrames;
    private bool notify;
    public Text noFruit, chargeThrowText;
    public int framesToSkip, chargableFrames;
    public Vector3 throwPower;

    private void Start()
    {
        pickedUpAndHeld = GetComponent<PickUpAndHold>();
    }

    private void Update()
    {
        //Charges up throwPower while fire1 is held
        if(Input.GetButton("Fire1") && pickedUpAndHeld.isHolding() && chargeFrames <= chargableFrames)
        {
            chargeThrowText.color = new Color(0, 0, 0, 1);
            chargeFrames++;
            throwPower.z += 0.5f;
            chargeThrowText.text = throwPower.z.ToString();
        }

        //Throws fruit on command
        if (Input.GetButtonUp("Fire1") && pickedUpAndHeld.isHolding())
        {
            chargeFrames = 0;
            throwPower.z *= 10;
            fruitToLaunch = pickedUpAndHeld.getHeldFruit();
            Rigidbody rb = fruitToLaunch.GetComponent<Rigidbody>();

            //Makes fruit follow laws of physics
            rb.constraints = RigidbodyConstraints.None;
            fruitToLaunch.transform.parent = null;
            fruitToLaunch.GetComponent<Collider>().enabled = true;

            //Throws Fruit
            rb.AddRelativeForce(throwPower);
            pickedUpAndHeld.setHolding(false);
            fruitToLaunch.gameObject.tag = "Player Launched Fruit";
            fruitToLaunch = null;
            throwPower.z = 50;
            chargeThrowText.color = new Color(0, 0, 0, 0);
        }

        //Notifies player if there is no fruit to throw
        else if(Input.GetButton("Fire1") && !pickedUpAndHeld.isHolding())
        {
            notify = true;
            noFruit.color = new Color(1, 0, 0, 1);
        }
        if(notify)
        {
            notifFrames++;

            //Clears notification after set time
            if (notifFrames >= framesToSkip)
            {
                noFruit.color = new Color(1, 0, 0, 0);
                notify = false;
                notifFrames = 0;
            }
        }

    }


}
