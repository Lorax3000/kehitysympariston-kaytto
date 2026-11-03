
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject howToPlayPanel;

    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is closing...");
    }

    public void OpenInstructions()
    {
        howToPlayPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        howToPlayPanel.SetActive(false);
    }
}
