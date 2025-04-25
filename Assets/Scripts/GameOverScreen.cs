using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] Button returnToTitleButton;
    void Start()
    {
        if (returnToTitleButton != null)
        {
            returnToTitleButton.onClick.AddListener(ReturnToTitleScreen);
        }
    }
    void ReturnToTitleScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreen");
    }
}