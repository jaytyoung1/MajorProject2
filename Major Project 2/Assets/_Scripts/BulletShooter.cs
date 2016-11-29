using UnityEngine;
using System.Collections;

public class BulletShooter : MonoBehaviour
{
    Vector3 bulletPosition;
    Vector3 bulletDirection;
    public GameObject bullet;
    float bulletSpeed = 750.0f;

    public void shoot()
    {
        //Debug.Log("shoot");
        float newX = gameObject.transform.position.x;
        float newY = gameObject.transform.position.y;
        float newZ = gameObject.transform.position.z - 0.25f;
        bulletPosition = new Vector3(newX, newY, newZ);
        //Debug.Log(bulletPosition);

        GameObject newBullet = (GameObject)Instantiate(bullet, bulletPosition, Quaternion.identity);

       // bulletDirection = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.1f));
        newBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletSpeed);
        //newBullet.GetComponent<Rigidbody>().AddForce(bulletDirection * bulletSpeed);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
