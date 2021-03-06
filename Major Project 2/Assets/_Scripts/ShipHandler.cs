﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipHandler : MonoBehaviour
{
    Vector3 posInput;
    Vector3 rotInput;
    Rigidbody rbody;
    public AudioSource restartAudio;
    public HealthManager healthMg;
    public Image redScreen;
    //bool powered = true;
    float shipSpeed = 150.0f;

    void Start()
    {
        redScreen.gameObject.SetActive(false);
        rbody = GetComponent<Rigidbody>();
    }

    public void MoveInput(Vector3 move, Vector3 rote)
    {
        posInput = move;
        rotInput = rote;
        //powered = power;
        ActuallyMove();
    }

    void ActuallyMove()
    {
        if (posInput.z != 0)
            shipSpeed = 150.0f;
        else
            shipSpeed = 0;

        rbody.AddRelativeForce(posInput * shipSpeed);
        rbody.AddRelativeTorque(rotInput);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Asteroid") || coll.gameObject.CompareTag("BigAsteroid") || coll.gameObject.CompareTag("EnemyShip"))
        {
            loseLifeAndRestart();
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        //if ship collides with heart, destroy heart and add life
        if (coll.gameObject.CompareTag("Heart"))
        {
            Destroy(coll.gameObject);
            healthMg.increaseLives(PlayerPrefs.GetInt("Lives"));
        }
    }

    public void loseLifeAndRestart()
    {
        redScreen.gameObject.SetActive(true);
        StartCoroutine("fadeRedScreen");
        restartAudio.Play();
        healthMg.decreaseLives(PlayerPrefs.GetInt("Lives"));
        if (PlayerPrefs.GetInt("Lives") > 0)
            StartCoroutine(deathRestartCo());
        else
            StartCoroutine(restartGame());
    }

    IEnumerator fadeRedScreen()
    {
        for (float f = 0.75f; f >= 0; f -= 0.02f)
        {
            Color c = redScreen.color;
            //Color c = renderer.material.color;
            c.a = f;
            redScreen.color = c;
            yield return null;  
        }
    }

    IEnumerator deathRestartCo()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        redScreen.gameObject.SetActive(false);
        transform.position = new Vector3(0, 0, 0);
    }

    IEnumerator restartGame()
    {
        yield return new WaitForSecondsRealtime(0.75f);

        //NEEDS TO LOAD DISPLAY SCORE SCENE
        SceneManager.LoadScene("DeathScene");
    }
}
