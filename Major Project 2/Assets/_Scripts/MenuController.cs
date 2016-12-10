using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void loadGameScene()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("GameScene");
    }	
}
