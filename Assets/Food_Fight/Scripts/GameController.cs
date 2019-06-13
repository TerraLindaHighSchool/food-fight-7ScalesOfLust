using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Controlls when the player wins or loses
 * Wil Bauer
 * 6-10-19
 */

public class GameController : MonoBehaviour
{
    public Text victoryText, loseText;
    private EnemyHealthController enemy;
    private PlayerHealthController player;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Vending Machine").GetComponent<EnemyHealthController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthController>();
        victoryText.color = new Color(0, 0, 0, 0);
        loseText.color = new Color(0, 0, 0, 0);
    }

    private void Update()
    {
        if(enemy.getHealth() <= 0)
        {
            victoryText.color = new Color(1, 1, 1, 1);
        }

        if(player.getHealth() <= 0)
        {
            loseText.color = new Color(1, 1, 1, 1);
        }
    }
}
