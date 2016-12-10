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

    public void loadLevel1()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("Level1");
    }

    public void loadHighScoresScene()
    {
        SceneManager.LoadScene("HighScoresScene");
    }

    public void resetHighScores()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("HighScoresScene");
    }
}
