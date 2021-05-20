using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    public void NewGameBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void TutorialBtn()
    {
        gameOverPanel.gameObject.SetActive(true);

    }
    public void TutorialExitBtn()
    {
        gameOverPanel.gameObject.SetActive(false);

    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
