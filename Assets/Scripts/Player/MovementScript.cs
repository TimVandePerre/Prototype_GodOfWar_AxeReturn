using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction Player_Movement;

    //Speed of the player.
    [SerializeField] private float Player_MovementSpeed;

    private void OnEnable()
    {
        Player_Movement.Enable();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        //Update the direction based on the input value
        Vector2 Move = Player_Movement.ReadValue<Vector2>() * Player_MovementSpeed;

        Debug.Log(Player_Movement.ReadValue<Vector2>());
        Vector3 currentPos = transform.position;
        
        currentPos.x += Move.x;
        currentPos.z += Move.y;

        Vector3.Lerp(transform.position, currentPos, Player_MovementSpeed);
    }

    private void OnDisable()
    {
        Player_Movement.Disable();
    }
}
