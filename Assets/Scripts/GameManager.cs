using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GameOver()
    {
        Debug.Log("Game Over!");

        SceneManager.LoadScene("GameOverScene");
    }
    public void Victory()
    {
        Debug.Log("You Win!");

        SceneManager.LoadScene("VictoryScene");
    }
    public void RestartGame()
    {
        Debug.Log("Restarting the game...");

        SceneManager.LoadScene("MainGameScene");
    }
}
