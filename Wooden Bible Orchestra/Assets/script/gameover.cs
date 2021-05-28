using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;

    }

}
