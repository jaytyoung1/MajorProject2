using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidManager : MonoBehaviour
{
    public GameObject ship;
    public GameObject[] asteroids;
    GameObject[] asteroidCollection;
    public int totalAsteroids = 20;
    private Vector3 newPosition;
    //ArrayList AsteroidCollection = new ArrayList();
    //List<GameObject> asteroidCollection; 

    // Use this for initialization
    void Start ()
    {
        spawnAsteroids();
        InvokeRepeating("updateAsteroidsDirection", 3.0f, 5.0f);
    }

    void spawnAsteroids()
    {
        for (int i = 0; i < totalAsteroids; i++)
        {
            float newX = ship.gameObject.transform.position.x + Random.Range(-50.0f, 50.0f);
            float newY = ship.gameObject.transform.position.y + Random.Range(-50.0f, 50.0f);
            float newZ = ship.gameObject.transform.position.z + Random.Range(10.0f, 50.0f);
            newPosition = new Vector3(newX, newY, newZ);
            //Debug.Log(newPosition);

            GameObject newAsteroid = (GameObject)Instantiate(asteroids[Random.Range(0, 4)], newPosition, Quaternion.Euler(Random.Range(100.0f, 360.0f), Random.Range(100.0f, 360.0f), Random.Range(100.0f, 360.0f)));

            Vector3 direction = ship.transform.position - newAsteroid.transform.position;
            direction = direction.normalized;
            newAsteroid.GetComponent<Rigidbody>().AddForce(direction * 40.0f); // Random.Range(10.0f, 50.0f));

            //newAsteroid.gameObject.transform.LookAt(ship.gameObject.transform);

            //newAsteroid.GetComponent<Rigidbody>().AddForce(new Vector3((Random.Range(-200.0f, 200.0f)), (Random.Range(-200.0f, 200.0f)), (Random.Range(-200.0f, 200.0f))));

            //newAsteroid.GetComponent<Rigidbody>().AddForce(newAsteroid.gameObject.transform.forward);
        }
        //add asteroids to array
        asteroidCollection = GameObject.FindGameObjectsWithTag("Asteroid");
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
        //Debug.Log("update direction");
        //yield return new WaitForSecondsRealtime(10);
        for (int i = 0; i < asteroidCollection.Length; i++)
        {
            Vector3 updatedDirection = ship.transform.position - asteroidCollection[i].transform.position;

            //updatedDirection.x = updatedDirection.x + Random.Range(-100.0f, 100.0f);
            //updatedDirection.y = updatedDirection.y + Random.Range(-100.0f, 100.0f);
            //updatedDirection.z = updatedDirection.z + Random.Range(-100.0f, 100.0f);

            updatedDirection = updatedDirection.normalized;
            asteroidCollection[i].GetComponent<Rigidbody>().AddForce(updatedDirection * 40.0f); // Random.Range(10.0f, 50.0f));
        }
        //yield return null;
    }

    // Update is called once per frame
    void Update ()
    {
	    
	}
}
