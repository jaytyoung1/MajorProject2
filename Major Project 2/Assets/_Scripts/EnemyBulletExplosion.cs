using UnityEngine;
using System.Collections;

public class EnemyBulletExplosion : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<ShipHandler>().loseLifeAndRestart();
            Destroy(this.gameObject);
        }
    }
}