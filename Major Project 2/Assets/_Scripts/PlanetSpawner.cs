using UnityEngine;
using System.Collections;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject ship;
    public GameObject[] planets;
    public int totalPlanets = 5;
    private Vector3 newPosition;

    // Use this for initialization
    void Start ()
    {
        spawnPlanets();
	}
	
    void spawnPlanets()
    {
        for (int i = 0; i < totalPlanets; i++)
        {
            float newX = ship.gameObject.transform.position.x + Random.Range(-1000.0f, 1000.0f);
            float newY = ship.gameObject.transform.position.y + Random.Range(-1000.0f, 1000.0f);
            float newZ = ship.gameObject.transform.position.z + Random.Range(-1000.0f, 1000.0f);
            newPosition = new Vector3(newX, newY, newZ);
            GameObject spawnedPlanet = (GameObject)Instantiate(planets[Random.Range(0, 4)], newPosition, Quaternion.identity);
        }
    }
}
