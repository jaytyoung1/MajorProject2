using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void loadWelcomeScene()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Lives");
        SceneManager.LoadScene("WelcomeScene");
    }

    public void loadGameScene()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("GameScene");
    }

    public void loadHighScoresScene()
    {
        SceneManager.LoadScene("HighScoresScene");
    }
}
