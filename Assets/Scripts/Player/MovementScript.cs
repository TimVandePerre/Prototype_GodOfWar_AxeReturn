using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    private PlayerInputs _inputs;
    private InputAction _player_Movement;

    private CharacterController _characterController;
    //Speed of the player.
    [SerializeField] private float Player_MovementSpeed;
    [SerializeField] private Camera Cam;

    private void OnEnable()
    {
        _player_Movement = _inputs.Movement.Move;
        _player_Movement.Enable();
    }

    private void Awake()
    {
        _inputs = new PlayerInputs();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        //Get the input
        Vector2 Input = _player_Movement.ReadValue<Vector2>();

        //update movement based on rotation.
        Vector3 camRigthInput = Cam.transform.right * Input.x;
        Vector3 camForwardInput = Cam.transform.forward * Input.y;
        camForwardInput.y = 0; //otherwise the movement is also going to affect the height of the player.

        //calculat the direction the player is moving based on the input and camera.
        Vector3 direction = camForwardInput + camRigthInput;
        //direction.y = _velocity; To be added when using jumping or gravity.

        _characterController.Move(direction * Player_MovementSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        _player_Movement.Disable();
    }
}
