using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreenManager : MonoBehaviour
{
    public Button restartButton;
    public Button returnToTitleButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        returnToTitleButton.onClick.AddListener(ReturnToTitleScreen);
    }
    void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Return to the title screen
    void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
