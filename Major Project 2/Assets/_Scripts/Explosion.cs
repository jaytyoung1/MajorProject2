using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    //public GameObject scoreMg;
    public GameObject explosionPrefab;
    //[HideInInspector]
    //public ScoreManager scoreScript;
    private Vector3 newPosition;

    // Use this for initialization
    void Start()
    {
        //scoreScript = scoreMg.GetComponent<ScoreManager>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Asteroid"))
        {
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
        Destroy(this.gameObject);
        Destroy(exp, 2.0f);
    }

    // Update is called once per frame
    void Update ()
    {

    }
}
