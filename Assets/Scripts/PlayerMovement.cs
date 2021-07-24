using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 7.0f;
    private float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;
    AudioSource audioSrc;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            if (!audioSrc.isPlaying && controller.isGrounded)
                audioSrc.Play();       
        }
        else 
        {
            audioSrc.Stop();
        }

        // Changes the height position of the player..
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            if (audioSrc.isPlaying)
                audioSrc.Stop();
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}