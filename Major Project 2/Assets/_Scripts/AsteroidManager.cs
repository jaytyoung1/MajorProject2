using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour
{
    public GameObject ship;
    public GameObject asteroid;
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
            float newX = ship.gameObject.transform.position.x + Random.Range(-50, 50);
            float newY = ship.gameObject.transform.position.y + Random.Range(-50, 50);
            float newZ = ship.gameObject.transform.position.z + Random.Range(10, 50);
            newPosition = new Vector3(newX, newY, newZ);
            //Debug.Log(newPosition);

            GameObject newAsteroid = (GameObject)Instantiate(asteroid, newPosition, Quaternion.identity);
            newAsteroid.GetComponent<Rigidbody>().AddForce(new Vector3((Random.Range(-100, 100)), (Random.Range(-100, 100)), (Random.Range(-100, 100))));
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
