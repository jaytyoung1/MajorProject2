using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletExplosion : MonoBehaviour
{
    public AudioSource explosionAudio;
    public GameObject ship;
    public GameObject audioManager;
    public GameObject[] smallAsteroidCollection;
    public GameObject explosionPrefab;
    private Vector3 newPosition;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Asteroid"))
        {
            PlayerPrefs.SetInt("asteroidsRemaining", (PlayerPrefs.GetInt("asteroidsRemaining") - 1));
            GameObject audioMg = (GameObject)Instantiate(audioManager, ship.gameObject.transform.position, Quaternion.identity);
            Destroy(coll.gameObject);

            explode();

            int score = PlayerPrefs.GetInt("Score");
            score = score + 1;
            PlayerPrefs.SetInt("Score", score);
        }

        if (coll.gameObject.CompareTag("EnemyShip"))
        {
            GameObject audioMg = (GameObject)Instantiate(audioManager, ship.gameObject.transform.position, Quaternion.identity);
            Destroy(coll.gameObject);

            explode();

            int score = PlayerPrefs.GetInt("Score");
            score = score + 1;
            PlayerPrefs.SetInt("Score", score);
        }

        if (coll.gameObject.CompareTag("BigAsteroid"))
        {
            GameObject audioMg = (GameObject)Instantiate(audioManager, ship.gameObject.transform.position, Quaternion.identity);
            Destroy(coll.gameObject);

            explodeAndSpawnSmallerAsteroids();

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

    void explodeAndSpawnSmallerAsteroids()
    {
        newPosition = gameObject.transform.position;
        GameObject exp = (GameObject)Instantiate(explosionPrefab, newPosition, Quaternion.identity);
        Destroy(this.gameObject);
        
        //spawn two smaller asteroids
        GameObject smallerAsteroid1 = (GameObject)Instantiate(smallAsteroidCollection[Random.Range(0, 4)], newPosition, Quaternion.identity);

        //shrink the scale in half
        smallerAsteroid1.transform.localScale = smallerAsteroid1.transform.localScale * 0.5f;

        //GameObject smallerAsteroid2 = (GameObject)Instantiate(smallAsteroidCollection[Random.Range(0, 4)], newPosition, Quaternion.identity);

        Vector3 direction1 = ship.transform.position - smallerAsteroid1.transform.position;
        direction1 = direction1.normalized;
        smallerAsteroid1.GetComponent<Rigidbody>().AddForce(direction1 * 80.0f); // Random.Range(10.0f, 50.0f));
        smallerAsteroid1.GetComponent<Rigidbody>().AddTorque(Random.Range(-25, 25), Random.Range(-25, 25), Random.Range(-25, 25));


        //spawn two smaller asteroids
        GameObject smallerAsteroid2 = (GameObject)Instantiate(smallAsteroidCollection[Random.Range(0, 4)], newPosition, Quaternion.identity);

        //shrink the scale in half
        smallerAsteroid2.transform.localScale = smallerAsteroid2.transform.localScale * 0.5f;

        //GameObject smallerAsteroid2 = (GameObject)Instantiate(smallAsteroidCollection[Random.Range(0, 4)], newPosition, Quaternion.identity);

        Vector3 direction2 = ship.transform.position - smallerAsteroid2.transform.position;
        direction2 = direction2.normalized;
        smallerAsteroid2.GetComponent<Rigidbody>().AddForce(direction2 * 80.0f); // Random.Range(10.0f, 50.0f));
        smallerAsteroid2.GetComponent<Rigidbody>().AddTorque(Random.Range(-25, 25), Random.Range(-25, 25), Random.Range(-25, 25));

        Destroy(exp, 2.0f);
    }
}
