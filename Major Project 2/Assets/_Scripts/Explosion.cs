using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    public GameObject ship;
    public ShipHandler sHandler;

    //public GameObject scoreMg;
    public GameObject explosionPrefab;
    //[HideInInspector]
    //public ScoreManager scoreScript;
    private Vector3 newPosition;

    //public GameObject audioHandler;
    AudioSource explosionAudio;

    // Use this for initialization
    void Start()
    {
        //scoreScript = scoreMg.GetComponent<ScoreManager>();
        explosionAudio = ship.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Asteroid"))
        {
           // explosionAudio = coll.gameObject.GetComponent<AudioSource>();
            //Debug.Log(explosionAudio);
            explosionAudio.Play();
            Destroy(coll.gameObject);
            explode();

            int score = PlayerPrefs.GetInt("Score");
            score = score + 1;
            PlayerPrefs.SetInt("Score", score);
        }
    }

    void explode()
    {
        newPosition = gameObject.transform.position;
        GameObject exp = (GameObject)Instantiate(explosionPrefab, newPosition, Quaternion.identity);
        //explosionAudio = exp.gameObject.GetComponent<AudioSource>();
        //explosionAudio.Play();
        Destroy(this.gameObject);
        Destroy(exp, 2.0f);
    }

    // Update is called once per frame
    void Update ()
    {

    }
}
