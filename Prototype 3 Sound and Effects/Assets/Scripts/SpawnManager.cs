using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables to store an object and existing components
    public GameObject obstaclePrefab;
    private PlayerController playerControllerScript; // to reference the PlayerController script

    // Variables
    private Vector3 spawnPosition = new Vector3(30, 0, 0);
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Storing PlayerController script to the variable
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        // Run the SpawnObstacle method with start delay and spawn interval applied
        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
    }

    // Spawn obstacle method
    void SpawnObstacle()
    {
        // Do if gameOver variable from PlayerController script is false
        if (playerControllerScript.gameOver == false)
        {
            // Make a copy of the obstacle to the spawn variable and to their respective rotation
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
