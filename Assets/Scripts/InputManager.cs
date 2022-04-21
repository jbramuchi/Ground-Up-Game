using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class InputManager : MonoBehaviour
{

    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    //private PlayerMotor motor;
    private PlayerLook look;
    private PlayerScope scope;

    // Scoped Variables
    private bool isScoped = false;
    Animator animator;

    // Like update()
    void Awake()
    {
        //Hide Cursor (PC Testing Purposes)
        Cursor.lockState = CursorLockMode.Locked;

        playerInput = new PlayerInput();

        // Weapon
        GameObject weaponHolder = GameObject.Find("weaponHolder");

        onFoot = playerInput.OnFoot;
        animator = weaponHolder.GetComponent<Animator>();
        //motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        //ctx call back context (.performed)
        //onFoot.Jump.performed += ctx => motor.Jump();
    }

    // FixedUpdate for physics related thangs
    void FixedUpdate()
    {
        //*OLD* Player movement capabilites
        //motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    void Update()
    {
        // Scope Function
        if (onFoot.Scope.triggered)
        {
            Debug.Log("flag");
            isScoped = !isScoped;

            Debug.Log("flag2");
            animator.SetBool("Scoped", !isScoped);

            Debug.Log("flag3");
        }
        //scope.ProcessScope(onFoot.Scope.triggered);
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
