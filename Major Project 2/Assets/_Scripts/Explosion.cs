using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    private Vector3 newPosition;

    //public ParticleSystem explosion;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Asteroid"))
        {
            Destroy(coll.gameObject);
            explode();
        }
    }

    void explode()
    {
        Debug.Log("in explode function");
        //ParticleSystem explo = GetComponent<ParticleSystem>();
        // explo.Play();
        //explosion.Play();
        newPosition = gameObject.transform.position;
        GameObject exp = (GameObject)Instantiate(explosionPrefab, newPosition, Quaternion.identity);
        Destroy(this.gameObject);
        //explosionPrefab.PlayAnimation();
        Destroy(exp, 2.0f);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
