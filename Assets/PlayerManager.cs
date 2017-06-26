﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {


    public Slider player_health;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        //transform.Rotate(0, x, 0);
        transform.Translate(x, 0, z);
    }

    public void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collision with object detected.  " + collision.gameObject.name);

        if ( collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collision with enemy detected.");
            player_health.value -= 10;

        }

        if(player_health.value <=0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);

    }
}
