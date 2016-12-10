using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public GameObject[] hearts;
    public int startingLives = 3;
    private int lifeCounter;

    // Use this for initialization
    void Start()
    {
        lifeCounter = startingLives;
        PlayerPrefs.SetInt("Lives", lifeCounter);
        
        for (int i = lifeCounter; i < hearts.Length; i++)
        {
            hearts[i].SetActive(false);
        }
    }

    public void increaseLives(int lives)
    {
        switch (lives)
        {
            case 6:
                break;
            case 5:
                hearts[lives].SetActive(true);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                break;
            case 4:
                hearts[lives].SetActive(true);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                break;
            case 3:
                hearts[lives].SetActive(true);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                break;
            case 2:
                hearts[lives].SetActive(true);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                break;
            case 1:
                hearts[lives].SetActive(true);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                break;
        }
    }

    public void decreaseLives(int lives)
    {
        switch (lives)
        {
            case 6:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                break;
            case 5:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                break;
            case 4:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                break;
            case 3:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                break;
            case 2:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                break;
            case 1:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                break;
        }
    }
}
