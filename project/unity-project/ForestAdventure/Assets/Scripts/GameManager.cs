
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int crystalsCollected = 0;
    public int crystalsToWin = 5;

    public UIManager uiManager;
    public Portal portal;

    private bool gameWon = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        uiManager.UpdateCounter(crystalsCollected, crystalsToWin);
    }

    public void AddCrystal()
    {
        crystalsCollected++;

        uiManager.UpdateCounter(crystalsCollected, crystalsToWin);

        Debug.Log("Crystals collected: " + crystalsCollected);

        if (crystalsCollected >= crystalsToWin)
        {
            portal.OpenPortal();
        }
    }

    public void WinGame()
    {
        if (gameWon)
            return;

        gameWon = true;

        uiManager.ShowWinPanel();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("You won Forest Adventure!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
