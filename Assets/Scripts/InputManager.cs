using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerScope scope;

    // Like update()
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        scope = GetComponent<PlayerScope>();

        // ctx call back context (.performed)
        onFoot.Jump.performed += ctx => motor.Jump();
    }

    // FixedUpdate for physics related thangs
    void FixedUpdate()
    {
        //tell the player motor to move using the value from our action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    void Update()
    { 
        scope.ProcessScope(onFoot.Scope.ReadValue<float>());
    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
