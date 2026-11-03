
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text counterText;
    public GameObject winPanel;

    public void UpdateCounter(int current, int total)
    {
        counterText.text = "Crystals: " + current + " / " + total;
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }
}
