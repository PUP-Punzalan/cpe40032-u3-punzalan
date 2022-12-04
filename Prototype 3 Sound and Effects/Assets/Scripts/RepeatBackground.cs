using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Variables
    private Vector3 startPosition; // to store initial postion of the background
    private float repeatWidth; // width of the background

    // Start is called before the first frame update
    void Start()
    {
        // Storing the initial position of the background to the variable
        startPosition = transform.position;

        // Storing the middle value of the background size
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Do if the background reaches the middle value of its size on x-axis
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            // Reset the backgrounds position
            transform.position = startPosition;
        }    
    }
}
