using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour
{
    public GameObject ship;
    public GameObject[] asteroids;
    public int totalAsteroids = 10;
    private Vector3 newPosition;

    // Use this for initialization
    void Start ()
    {
        spawnAsteroids();
	}
	
    void spawnAsteroids()
    {
        for (int i = 0; i < totalAsteroids; i++)
        {
            float newX = ship.gameObject.transform.position.x + Random.Range(-10.0f, 10.0f);
            float newY = ship.gameObject.transform.position.y + Random.Range(-10.0f, 10.0f);
            float newZ = ship.gameObject.transform.position.z + Random.Range(10.0f, 10.0f);
            newPosition = new Vector3(newX, newY, newZ);
            //Debug.Log(newPosition);

            GameObject newAsteroid = (GameObject)Instantiate(asteroids[Random.Range(0, 4)], newPosition, Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));
            //newAsteroid.GetComponent<Rigidbody>().AddForce(new Vector3((Random.Range(-200.0f, 200.0f)), (Random.Range(-200.0f, 200.0f)), (Random.Range(-200.0f, 200.0f))));
        }
    }

	// Update is called once per frame
	void Update ()
    {
	    
	}
}
