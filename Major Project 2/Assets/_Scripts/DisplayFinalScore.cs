using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayFinalScore : MonoBehaviour
{
    public InputField initialsInputField;
    public Text totalScoreTextBox;
    public Text livesLeftTextBox;
    public Text finalScoreTextBox;
    public Text highScoreTextBox;

    private int finalScore;
    public const int highScoreCount = 10;

    // Use this for initialization
    void Start ()
    {
        initialsInputField.gameObject.SetActive(false);
        totalScoreTextBox.text = "= " + PlayerPrefs.GetInt("Score");
        livesLeftTextBox.text = "= " + PlayerPrefs.GetInt("Lives");
        finalScore = PlayerPrefs.GetInt("Score") * PlayerPrefs.GetInt("Lives");
        PlayerPrefs.SetInt("finalScore", finalScore);

        finalScoreTextBox.text = "FINAL SCORE = " + PlayerPrefs.GetInt("Score") + " * " + PlayerPrefs.GetInt("Lives") + " = " + finalScore;

        if (isHighScore(finalScore))
        {
            highScoreTextBox.text = ("You earned a high score!\nType your initials and press ENTER.");
            initialsInputField.gameObject.SetActive(true);
        }
        else
        {
            highScoreTextBox.text = ("\t\t\t\tTry again. You did not earn a high score.");
        }
    }

    public bool isHighScore(int yourScore)
    {
        string lowestScoreKey = "highScore" + (highScoreCount - 1);
        int lowestScore = PlayerPrefs.GetInt(lowestScoreKey);
        if (yourScore >= lowestScore)
            return true;
        else
            return false;
    }

    public void intialsEntered()
    {
        string playerName = initialsInputField.text;
        string playerInitials = "";

        if (playerName.Length >= 3)
            playerInitials = playerName.Substring(0, 3);
        else
            playerInitials = playerName.Substring(0, playerName.Length);

        PlayerPrefs.SetString("InitialsEntered", playerInitials);
        SceneManager.LoadScene("HighScoresScene");
    }

}
