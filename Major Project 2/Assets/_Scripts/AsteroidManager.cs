using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AsteroidManager : MonoBehaviour
{
    public GameObject ship;
    public GameObject[] asteroids;
    public string sceneToLoad;

    GameObject[] smallAsteroidCollection;
    GameObject[] bigAsteroidCollection;

    //List<GameObject> smallAsteroidCollection = new List<GameObject>();

    public int numberOfStartingAsteroids;
    private Vector3 newPosition;
    int asteroidsRemaining;
    //ArrayList AsteroidCollection = new ArrayList();
    //List<GameObject> asteroidCollection; 

    // Use this for initialization
    void Start ()
    {
        PlayerPrefs.SetInt("asteroidsRemaining", numberOfStartingAsteroids);
        spawnAsteroids();
        InvokeRepeating("updateAsteroidsDirection", 3.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

        //if (PlayerPrefs.GetInt("asteroidsRemaining") <= 0)
        //{
        //    SceneManager.LoadScene("WelcomeScene");
        //}

        //smallAsteroidCollection.AddRange(GameObject.FindGameObjectsWithTag("Asteroid"));
        //smallAsteroidCollection.AddRange(GameObject.FindGameObjectsWithTag("BigAsteroid"));
        //asteroidsRemaining = smallAsteroidCollection.Count;

        smallAsteroidCollection = GameObject.FindGameObjectsWithTag("Asteroid");
        bigAsteroidCollection = GameObject.FindGameObjectsWithTag("BigAsteroid");
        asteroidsRemaining = smallAsteroidCollection.Length + bigAsteroidCollection.Length;

        if (asteroidsRemaining <= 0)
        {
            StartCoroutine(levelComplete());
            //SceneManager.LoadScene("WelcomeScene");
        }
        PlayerPrefs.SetInt("asteroidsRemaining", asteroidsRemaining);

        Debug.Log("asteroids remaining = " + asteroidsRemaining);
    }

    void spawnAsteroids()
    {
        for (int i = 0; i < numberOfStartingAsteroids; i++)
        {
            float newX = ship.gameObject.transform.position.x + Random.Range(-50.0f, 50.0f);
            float newY = ship.gameObject.transform.position.y + Random.Range(-50.0f, 50.0f);
            float newZ = ship.gameObject.transform.position.z + Random.Range(10.0f, 50.0f);
            newPosition = new Vector3(newX, newY, newZ);
            //Debug.Log(newPosition);

            GameObject newAsteroid = (GameObject)Instantiate(asteroids[Random.Range(0, 7)], newPosition, Quaternion.identity);

            Vector3 direction = ship.transform.position - newAsteroid.transform.position;
            direction = direction.normalized;
            newAsteroid.GetComponent<Rigidbody>().AddForce(direction * 40.0f); // Random.Range(10.0f, 50.0f));
            newAsteroid.GetComponent<Rigidbody>().AddTorque(Random.Range(-25, 25), Random.Range(-25, 25), Random.Range(-25, 25));
        }
        //add asteroids to array
        smallAsteroidCollection = GameObject.FindGameObjectsWithTag("Asteroid");
        bigAsteroidCollection = GameObject.FindGameObjectsWithTag("BigAsteroid");
        //asteroidCollection.AddRange(GameObject.FindGameObjectsWithTag("Asteroid"));
        //asteroidCollection.AddRange(GameObject.FindGameObjectsWithTag("BigAsteroid"));

        //foreach (GameObject ast in asteroidCollection)
        //{
        //    Debug.Log(ast);
        //}
    }

    void FixedUpdate()
    {
        //StartCoroutine(updateAsteroidsDirection());
    }

    //IEnumerator updateAsteroidsDirection()
    void updateAsteroidsDirection()
    {
        StartCoroutine(updateAsteroidsCO());
    }

    IEnumerator updateAsteroidsCO()
    {
        //Debug.Log("update direction");
        //yield return new WaitForSecondsRealtime(10);

        //foreach (GameObject asteroid in asteroidCollection)
        for (int i = 0; i < smallAsteroidCollection.Length; i++)
        {
            //Debug.Log(ship.transform.position);
            Vector3 updatedDirection = ship.transform.position - smallAsteroidCollection[i].transform.position;

            updatedDirection.x = updatedDirection.x + Random.Range(-100.0f, 100.0f);
            updatedDirection.y = updatedDirection.y + Random.Range(-100.0f, 100.0f);
            updatedDirection.z = updatedDirection.z + Random.Range(-100.0f, 100.0f);

            updatedDirection = updatedDirection.normalized;

            Rigidbody rb = smallAsteroidCollection[i].GetComponent<Rigidbody>();

            rb.velocity = Vector3.zero;
            rb.AddForce(updatedDirection * 40.0f);
            //asteroidCollection[i].GetComponent<Rigidbody>().AddForce(updatedDirection * 40.0f); // Random.Range(10.0f, 50.0f));
        }
        yield return null;
    }

    IEnumerator levelComplete()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(sceneToLoad);
    }
}
