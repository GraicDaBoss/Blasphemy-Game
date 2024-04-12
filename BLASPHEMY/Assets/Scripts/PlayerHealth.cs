using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public int damage = 10;
    public float farts;


    


    void Start()
    {
        maxHealth = health;
    }

    IEnumerator Respawn()
    {
        health = 100;
        GetComponent<PlayerMovement>().enabled = false;
        transform.position = new Vector3(1, 1, 0);
        yield return new WaitForSeconds(1);
        GetComponent<PlayerMovement>().enabled = true;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            StartCoroutine(Respawn());

            print("DEAD");
        }
        
      


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) 
        {
            health -= damage;
            Debug.Log("Player health decreased by: " + damage);
        }

    }
    
}