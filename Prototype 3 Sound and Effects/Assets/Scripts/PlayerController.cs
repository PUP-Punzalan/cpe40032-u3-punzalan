using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables to store player's existing components
    private Rigidbody playerRigidbody;
    private Animator playerAnimation;
    private AudioSource playerAudio;

    // Variables for particles and audios
    public ParticleSystem bloodParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    // Variables
    public float jumpPower;
    public float gravityModifier;
    public bool isOnGround = true; // to limit players jump one at the time
    public bool gameOver; // default value is false, to know when the game ended

    // Start is called before the first frame update
    void Start()
    {
        // Storing the player's existing components to their variables
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Modifying the gravity in the scene
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Do if user clicked spacebar
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // Added jump force to the player
            playerRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            // Added bool in order for the player to not jump simultaneously
            isOnGround = false;

            // Added jump animation, and jump audio
            playerAnimation.SetTrigger("Jump_trig");
            dirtParticle.Stop(); // stops the dirt particle in mid-air
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Do if player collides with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // switched to true for the player to jump again
            dirtParticle.Play(); // play the particle again after the jump is done
        }
        // Do if player collides with the obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!"); // message to console
            gameOver = true; // bool representing the the game is ended

            // Added death animation to the player
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);

            // Play blood particle, but stop dirt particle
            bloodParticle.Play();
            dirtParticle.Stop();

            // Added crash sound to the player
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
