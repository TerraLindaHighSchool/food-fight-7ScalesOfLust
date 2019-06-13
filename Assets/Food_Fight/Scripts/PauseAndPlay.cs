using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndPlay : MonoBehaviour
{
    private bool paused = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetButtonUp("Cancel") && paused)
        {
            Time.timeScale = 1;
            paused = false;
            Cursor.visible = false;
        }
        else if (Input.GetButtonUp("Cancel") && !paused)
        {
            Time.timeScale = 0;
            paused = true;
            Cursor.visible = true;
        }
    }
}
