using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {


    // Create an event system for every action a player should be able to do.

    // Player should be able to die, pickup items, spawn, achievements






    public string scenename = "game_over";

    public PlayerManager playerPrefab;


    // Any object that is listening for events should have the following code.
    // the Die functioni should have same signature as deathEvent and be listed in this object.
    private void OnEnable()
    {
        PlayerManager.gameOverEvent += GameOver;
        PlayerManager.achievementEvent += UpdateAchievement;
        //PlayerManager.deathEvent += DestroyPlayer;
        PlayerManager.deathEvent += SpawnPlayer;


    }


    // Any object that is listening for events should have the following code.
    // the Die function should have same signature as deathEvent and be listed in this object.

    void OnDisable()
    {
        PlayerManager.gameOverEvent -= GameOver;
        PlayerManager.achievementEvent -= UpdateAchievement;
        //PlayerManager.deathEvent -= DestroyPlayer;
        PlayerManager.deathEvent -= SpawnPlayer;

    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


    public void UpdateAchievement()
    {


    }

    public void DestroyPlayer()
    {
       
        // Destroying components immediately is not permitted during physics trigger/contact, 
        // animation event callbacks or OnValidate. You must use Destroy instead.
        //DestroyImmediate(playerPrefab, true);

    }

    public void SpawnPlayer()
    {
        Debug.Log("Spawning player.");
        //
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        
    }

    public void GameOver()
    {
        DestroyPlayer();
        scenename = "game_over";
        StartCoroutine(WaitAndDie(0.1f));
        SceneManager.LoadScene(scenename);

    }

    IEnumerator WaitAndDie(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("Game Over");


    }
}
