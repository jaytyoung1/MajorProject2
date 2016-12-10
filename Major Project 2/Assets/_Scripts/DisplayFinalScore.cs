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
    private int totalScore;
    public const int highScoreCount = 10;

    // Use this for initialization
    void Start ()
    {
        initialsInputField.gameObject.SetActive(false);
        totalScoreTextBox.text = "= " + PlayerPrefs.GetInt("Score");
        livesLeftTextBox.text = "= " + PlayerPrefs.GetInt("Lives");
        finalScoreTextBox.text = "FINAL SCORE = " + PlayerPrefs.GetInt("Score") + " * " + PlayerPrefs.GetInt("Lives") + " = " + PlayerPrefs.GetInt("Score") * PlayerPrefs.GetInt("Lives");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
