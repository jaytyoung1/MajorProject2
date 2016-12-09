using UnityEngine;
using System.Collections;

public class EnemyBulletShooter : MonoBehaviour
{
    Vector3 bulletPosition;
    Vector3 bulletDirection;
    public GameObject bullet;
    //public GameObject ship;
    float bulletSpeed = 750.0f;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("enemyFireRepeat", 3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update ()
    {

    }

    void enemyFireRepeat()
    {
        StartCoroutine("shootEnemyBullets");
    }

    IEnumerator shootEnemyBullets()
    {
        yield return new WaitForSecondsRealtime(Random.Range(1.0f, 3.0f));
        float newX = gameObject.transform.position.x;
        float newY = gameObject.transform.position.y;
        float newZ = gameObject.transform.position.z;
        bulletPosition = new Vector3(newX, newY, newZ);

        GameObject newBullet = (GameObject)Instantiate(bullet, bulletPosition, Quaternion.identity);
        GameObject ship = GameObject.FindGameObjectWithTag("Player");

        Vector3 updatedDirection = ship.transform.position - newBullet.transform.position;
        updatedDirection.x = updatedDirection.x + Random.Range(-10.0f, 10.0f);
        updatedDirection.y = updatedDirection.y + Random.Range(-10.0f, 10.0f);
        updatedDirection.z = updatedDirection.z + Random.Range(-10.0f, 10.0f);
        updatedDirection = updatedDirection.normalized;

        newBullet.GetComponent<Rigidbody>().AddForce(updatedDirection * bulletSpeed);
        Destroy(newBullet, 5.0f);
    }
}
