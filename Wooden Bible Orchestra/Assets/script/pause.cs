using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject gameOverPanel;
    public void PauseToggle()
    {
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            gameOverPanel.gameObject.SetActive(true);

        }
        else
        {
            Time.timeScale = 1f;
            gameOverPanel.gameObject.SetActive(false);

        }
    }
}
