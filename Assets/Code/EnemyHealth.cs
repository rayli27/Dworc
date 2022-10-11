using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public int dropRateOutOf100 = 10;
    public GameObject theDrops;
    public Transform dropPoint;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);

            //need to figure out how to delay

            if (dropRateOutOf100 > Random.Range(0, 100))
            {
                Instantiate(theDrops, dropPoint.position, dropPoint.rotation);
            }
        }
    }
}
