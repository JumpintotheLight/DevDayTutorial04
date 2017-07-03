using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





public class PlayerManager : MonoBehaviour {


    // Create an event system for every action a player should be able to do.

    // Player should be able to die, pickup items, spawn, achievements

    public delegate void DeathDelegate();
    public static event DeathDelegate deathEvent;


    public delegate void GameOverDelegate();
    public static event GameOverDelegate gameOverEvent;

    public delegate void PickupDelegate();
    public static event PickupDelegate pickupEvent;


    public delegate void AchievementDelegate();
    public static event AchievementDelegate achievementEvent;

    //public GameObject playerPrefab;
    public int player_health;
    public Slider player_health_slider;
    public int number_of_lives = 3;


    public static PlayerManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);


   
    }



    public void Die()
    {


        number_of_lives--;


        if (number_of_lives<=0)
        {

            Destroy(gameObject);

            if (gameOverEvent != null)
                gameOverEvent();
        }

        deathEvent();


        //StartCoroutine(WaitAndDie(0.5f));

        Debug.Log("Reset player.");
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.identity;
        this.player_health = 100;
        //Destroy(gameObject);


    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        //transform.Rotate(0, x, 0);
        transform.Translate(x, 0, z);

        player_health_slider.value = player_health;
    }

    public void OnCollisionEnter(Collision collision)
    {

        //Debug.Log("Collision with object detected.  " + collision.gameObject.name);

        if ( collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collision with enemy detected.");
            player_health -= 15;

        }

        if (collision.gameObject.tag == "Pickup")
        {
            Debug.Log("Collision with pickup detected.");
            if (pickupEvent != null)
                pickupEvent();

        }

        if (player_health_slider.value <=0)
        {
    

            Die();
        }
    }



    public void OnCollisionExit(Collision collision)
    {

        //Debug.Log("Collision with object detected.  " + collision.gameObject.name);

        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Player exited off of platform.");
            if (deathEvent != null)
                deathEvent();

            Die();
        }



    }

    IEnumerator WaitAndDie(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("Game Over");
        

    }
}
