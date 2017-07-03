using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {


    public Slider enemy_health;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      
    }

    public void OnCollisionEnter(Collision collision)
    {

        //Debug.Log("Collision with object detected.  " + collision.gameObject.name);

        if ( collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision with player detected.");
            enemy_health.value -= 15;

        }

        if(enemy_health.value <=0)
        {
            Die();
        }
    }

    public void OnCollisionExit(Collision collision)
    {

        //Debug.Log("Collision with object detected.  " + collision.gameObject.name);

        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Enemy exited off of platform.");
            enemy_health.value -= 15;

            Die();
        }

       
        
    }

    public void Die()
    {
        Destroy(gameObject);

    }
}
