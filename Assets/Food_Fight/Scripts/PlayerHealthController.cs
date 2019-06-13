using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Controls player health
 * Wil Bauer
 * 6-7-19
 */

public class PlayerHealthController : MonoBehaviour
{
    public Text healthBar;
    private string healthBarPrefix;
    private int health;

    private void Start()
    {
        healthBarPrefix = healthBar.text;
        health = 100;
        healthBar.text += health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy Launched Fruit")
        {
            health -= 10;
            healthBar.text = healthBarPrefix + health;
        }
    }

    public int getHealth()
    {
        return health;
    }
}
