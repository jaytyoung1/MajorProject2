using UnityEngine;
using System.Collections;

public class EnemyShipManager : MonoBehaviour
{
    public GameObject ship;
    public GameObject enemyShip;
    public GameObject[] enemyShipCollection;
    public int totalEnemyShips = 3;
    private Vector3 newPosition;
    private Quaternion[] facingDirections;
    //Vector3 bulletPosition;
    //Vector3 bulletDirection;
    //public GameObject bullet;
    //float bulletSpeed = 750.0f;

    // Use this for initialization
    void Start ()
    {
        spawnEnemyShips();
        InvokeRepeating("updateEnemyShipsDirection", 3.0f, 5.0f);
    }

    void spawnEnemyShips()
    {
        for (int i = 0; i < totalEnemyShips; i++)
        {
            float newX = ship.gameObject.transform.position.x + Random.Range(-10.0f, 10.0f);
            float newY = ship.gameObject.transform.position.y + Random.Range(-10.0f, 10.0f);
            float newZ = ship.gameObject.transform.position.z + Random.Range(10.0f, 10.0f);
            newPosition = new Vector3(newX, newY, newZ);

            GameObject newEnemyShip = (GameObject)Instantiate(enemyShip, newPosition, Quaternion.identity);

            Vector3 direction = ship.transform.position - newEnemyShip.transform.position;
            direction.x = Random.Range(-25.0f, 25.0f);
            direction.y = Random.Range(-25.0f, 25.0f);
            direction.z = Random.Range(-25.0f, 25.0f);
            direction = direction.normalized;
            newEnemyShip.GetComponent<Rigidbody>().AddForce(direction * 100.0f); // Random.Range(10.0f, 50.0f));

            //enemyShip.transform.Rotate(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));

        }
        enemyShipCollection = GameObject.FindGameObjectsWithTag("EnemyShip");
        for (int i = 0; i < enemyShipCollection.Length; i++)
        {
            //enemyShipCollection[i].transform.rotation = Quaternion.LookRotation(enemyShipCollection[i].GetComponent<Rigidbody>().velocity);
            facingDirections[i] = enemyShipCollection[i].transform.rotation;
        }
    }

    void updateEnemyShipsDirection()
    {
        //Debug.Log("update direction");
        //yield return new WaitForSecondsRealtime(10);
        for (int i = 0; i < enemyShipCollection.Length; i++)
        {
            //Debug.Log(ship.transform.position);
            Vector3 updatedDirection = ship.transform.position - enemyShipCollection[i].transform.position;

            updatedDirection.x = updatedDirection.x + Random.Range(-100.0f, 100.0f);
            updatedDirection.y = updatedDirection.y + Random.Range(-100.0f, 100.0f);
            updatedDirection.z = updatedDirection.z + Random.Range(-100.0f, 100.0f);

            updatedDirection = updatedDirection.normalized;
            enemyShipCollection[i].GetComponent<Rigidbody>().AddForce(updatedDirection * 100.0f); // Random.Range(10.0f, 50.0f));
            //enemyShipCollection[i].transform.Rotate(enemyShipCollection[i].GetComponent<Rigidbody>().velocity);

            //StartCoroutine("shootEnemyBullets");

            //enemyShipCollection[i].transform.up = enemyShipCollection[i].GetComponent<Rigidbody>().velocity;

        }
        //yield return null;
    }

    //IEnumerator shootEnemyBullets()
    //{
    //    yield return new WaitForSecondsRealtime(Random.Range(1.0f, 3.0f));
    //    float newX = gameObject.transform.position.x;
    //    float newY = gameObject.transform.position.y;
    //    float newZ = gameObject.transform.position.z;
    //}

    // Update is called once per frame
    void Update ()
    {
        for (int i = 0; i < enemyShipCollection.Length; i++)
        {
            enemyShipCollection[i].transform.rotation = Quaternion.LookRotation(enemyShipCollection[i].GetComponent<Rigidbody>().velocity);
            //facingDirections[i] = enemyShipCollection[i].transform.rotation;
        }
    }
}
