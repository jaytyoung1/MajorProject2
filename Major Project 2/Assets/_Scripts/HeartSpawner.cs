using UnityEngine;
using System.Collections;

public class HeartSpawner : MonoBehaviour
{
    public GameObject ship;
    public GameObject heart;
    public int totalHearts = 5;
    private Vector3 newPosition;

    // Use this for initialization
    void Start ()
    {
        spawnHearts();
	}

    void spawnHearts()
    {
        for (int i = 0; i < totalHearts; i++)
        {
            float newX = ship.gameObject.transform.position.x + Random.Range(-50.0f, 50.0f);
            float newY = ship.gameObject.transform.position.y + Random.Range(-50.0f, 50.0f);
            float newZ = ship.gameObject.transform.position.z + Random.Range(-50.0f, 50.0f);
            newPosition = new Vector3(newX, newY, newZ);

            GameObject spawnedHeart = (GameObject)Instantiate(heart, newPosition, Quaternion.identity);
            spawnedHeart.GetComponent<Rigidbody>().AddTorque(Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f));
        }
    }
}
