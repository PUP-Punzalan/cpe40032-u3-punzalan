using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Variables
    public float speed; // environment and obstacle speed
    private PlayerController playerControllerScript; // to reference PlayerController script
    private float leftBoundary = -15; // obstacle boundary

    // Start is called before the first frame update
    void Start()
    {
        // Storing PlayerController script to the variable
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Do if gameOver variable from PlayerController script is false
        if (playerControllerScript.gameOver == false)
        {
            // Apply speed to the environment and obstacle
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // Do if obstacle reaches the boundary
        if (transform.position.x < leftBoundary && gameObject.CompareTag("Obstacle"))
        {
            // Destroys the obstacle
            Destroy(gameObject);
        }
    }
}
