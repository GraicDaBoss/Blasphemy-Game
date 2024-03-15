using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtyScript : MonoBehaviour
{
    //public damage pHealth;
    public static damage instance;
    public float pHealth;
    public float damage;
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth.health -= damage;
        }
    
    }
}
