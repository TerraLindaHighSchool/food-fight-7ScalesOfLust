using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Let's player pickup and hold fruit on collision
 * Wil Bauer
 * 6-7-19
 */

public class PickUpAndHold : MonoBehaviour
{
    public int framesToSkip;
    public Text notification; 
    private bool holding, notified, moveNotif;
    private GameObject heldFruit;
    private int frames;
    private Vector3 defaultPosition;

    public bool isHolding()
    {
        return holding;
    }

    public GameObject getHeldFruit()
    {
        return heldFruit;
    }

    public void setHolding(bool isIt)
    {
        holding = isIt;
    }

    private void Start()
    {
        holding = false;
        defaultPosition = notification.rectTransform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Fruit" && !holding)
        {

            //Picks up touched fruit
            heldFruit = collision.gameObject;

            heldFruit.transform.parent = GameObject.FindGameObjectWithTag("Hand").transform;
            heldFruit.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            heldFruit.GetComponent<Collider>().enabled = false;
            heldFruit.transform.localPosition = new Vector3(0, 0, 0);
            heldFruit.transform.rotation = new Quaternion(0, 0, 0, 0);
            holding = true;

            //Notifies player of picked-up fruit
            notification.text += heldFruit.name;
            notified = true;
        }
    }

    private void Update()
    {
        //Clears notification after certain amount of time
        if (notified)
        {
            frames++;
            moveNotif = true;
            if(frames >= framesToSkip)
            {
                notification.text = "";
                notified = false;
                moveNotif = false;
                notification.rectTransform.position = defaultPosition;
                notification.color = new Color(0, 0, 0, 1);
                frames = 0;
            }
        }

        //Moves notification up and fades away
        if (moveNotif)
        {
            float currentAlpha = notification.color.a;
            notification.rectTransform.position = new Vector3(defaultPosition.x, defaultPosition.y + frames*2, defaultPosition.z);
            notification.color = new Color(0, 0, 0, currentAlpha-0.02f);
        }
    }
}