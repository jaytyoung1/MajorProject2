using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    private int finalScore;
    public const int highScoreCount = 10;

    //public InputField initialsInputField;
    public Text highScoreTextBox;

    // Use this for initialization
    void Start()
    {
        displayScores();
        //Debug.Log("final score: " + PlayerPrefs.GetFloat("totalScore"));
        finalScore = PlayerPrefs.GetInt("finalScore");
        string initialsEntered = PlayerPrefs.GetString("InitialsEntered");

        //Debug.Log("final score: " + finalScore + "\ninitials: " + initialsEntered);
        if (isHighScoresUpdated(initialsEntered, finalScore))
        {
            //displayHighScoresTextBox.gameObject.SetActive(true);
            displayScores();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool isHighScoresUpdated(string yourInitials, int yourScore)
    {
        int scoreInTopTen = 0;
        string scoreKey = "";
        string initialsKey = "";
        for (int i = 0; i < highScoreCount; i++)
        {
            scoreKey = "highScore" + i;
            initialsKey = "initials" + i;
            scoreInTopTen = PlayerPrefs.GetInt(scoreKey);
            if (yourScore >= scoreInTopTen)
            {
                insertYourScore(yourScore, i, scoreKey, initialsKey, yourInitials);
                return true;
            }
        }
        return false;
    }

    public void insertYourScore(int yourScore, int index, string scoreKey, string initialsKey, string initials)
    {
        string tempInitialsKey = "";
        string tempInitialsVal = "";
        string tempInitialsKey2 = "";
        string tempInitialsVal2 = "";

        string tempStringKey = "";
        int tempStringVal = 0;
        string tempStringKey2 = "";
        int tempStringVal2 = 0;

        for (int i = index; i < highScoreCount; i++)
        {
            tempStringKey = "highScore" + i;
            tempInitialsKey = "initials" + i;
            //int tempStringVal;
            if (i == index)
            {
                tempStringVal = PlayerPrefs.GetInt(tempStringKey);
                tempInitialsVal = PlayerPrefs.GetString(tempInitialsKey);

            }
            else
            {
                tempStringVal = tempStringVal2;
                tempInitialsVal = tempInitialsVal2;
            }

            tempStringKey2 = "highScore" + (i + 1);
            tempStringVal2 = PlayerPrefs.GetInt(tempStringKey2);

            tempInitialsKey2 = "initials" + (i + 1);
            tempInitialsVal2 = PlayerPrefs.GetString(tempInitialsKey2);

            PlayerPrefs.SetInt(tempStringKey2, tempStringVal);
            PlayerPrefs.SetString(tempInitialsKey2, tempInitialsVal);
        }
        PlayerPrefs.SetInt(scoreKey, yourScore);
        PlayerPrefs.SetString(initialsKey, initials);
    }

    public void displayScores()
    {
        string scoreStr = "";
        for (int i = 0; i < highScoreCount; i++)
        {
            string scoreKey = "highScore" + i;
            string initialsKey = "initials" + i;

            //string initials = PlayerPrefs.GetString(initialsKey);
            //int initialsLength = initials.Length;

            if (i == 0)
                scoreStr = scoreStr + (string.Format("{0, 12}", (i + 1))) + "." + (string.Format("{0, 12}", PlayerPrefs.GetString(initialsKey))) + (string.Format("{0, 12}", PlayerPrefs.GetInt(scoreKey))) + "\n";
            else
                scoreStr = scoreStr + (string.Format("{0, 12}", (i + 1))) + "." + (string.Format("{0, 12}", PlayerPrefs.GetString(initialsKey))) + (string.Format("{0, 12}", PlayerPrefs.GetInt(scoreKey))) + "\n";
        }
        highScoreTextBox.text = scoreStr;
        //highScoresTextBox.text = scoreStr;
    }

    public void restartGame()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.DeleteKey("Coins");
        //PlayerPrefs.DeleteKey("Time");
        //PlayerPrefs.DeleteKey("totalScore");
        //PlayerPrefs.DeleteKey("InitialsEntered");
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Lives");
        SceneManager.LoadScene("GameScene");
    }

    public void goToMainMenu()
    {
        //PlayerPrefs.DeleteKey("Coins");
        //PlayerPrefs.DeleteKey("Time");
        //PlayerPrefs.DeleteKey("totalScore");
        //PlayerPrefs.DeleteKey("InitialsEntered");
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Lives");
        SceneManager.LoadScene("WelcomeScene");
    }

    public void resetHighScores()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("HighScoresScene");
    }
}

