using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    static public float healthPoints;

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;


        if (healthPoints <= 0)
        {
            Destroy(gameObject);

            print("dead");
        }
    }
}
