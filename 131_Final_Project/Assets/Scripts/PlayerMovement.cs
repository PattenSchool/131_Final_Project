using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player's movement, is the example from class
public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 1; 
    public float Gravity = -9.81f;
    private CharacterController _controller; 
    private Vector3 _velocity;
    private bool _groundedPlayer;
    private float _jumpHeight = 3.0f;
    public Vector3 location; // Stores player's location, also used to save that location

    void Start()
    {
        _controller = GetComponent<CharacterController>(); 
    }

    // Saves the player's data (just the location)
    public void SavePlayer()
    {
        SaveData.SavePlayer(gameObject.transform.position);
    }

    // Loads the player's data (just the location)
    public void LoadPlayer()
    {
        PlayerData data = SaveData.LoadPlayer();

        // Disables the character controller so the player can be moved
        CharacterController myController = gameObject.GetComponent<CharacterController>();
        myController.enabled = false;

        gameObject.transform.position = new Vector3(data.PlayerLocation[0], data.PlayerLocation[1], data.PlayerLocation[2]);

        // Re-enables the character controller
        myController.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        _groundedPlayer = _controller.isGrounded; 

        if (_groundedPlayer && _velocity.y < 0)
        {
            _velocity.y = 0f; 

        }

        location = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); 
        move = transform.TransformDirection(move);

        _controller.Move(move * Time.deltaTime * moveSpeed);

        if (Input.GetButton("Jump") && _groundedPlayer) 
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * Gravity); 
        }

        _velocity.y += Gravity * Time.deltaTime; //setting velocity in the y direction to the acceleration of gravity in the relation to our fps (Time.deltaTime)
        _controller.Move(_velocity * Time.deltaTime); // Movement based on velocity

        //Sets movement speed depending on normal key press, sprinting (left shift), and idle (no input)
        if (move != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            // Walk
            moveSpeed = 5;
        }
        else if (move != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            // Run
            moveSpeed = 10;
        }
        else
        {
            // Idle
            moveSpeed = 5;
        }
    }
}
