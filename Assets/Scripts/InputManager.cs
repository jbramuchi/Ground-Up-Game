using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerLook look;

    // Scoped Variables
    private bool isScoped = false;
    Animator animator;
    GameObject weaponHolder;
    GameObject scopeView;

    const float zoomPOV = 35f, normalPOV = 60f;

    void Awake()
    {

        // Hide Cursor (PC Testing Purposes)
        Cursor.lockState = CursorLockMode.Locked;


        // For Use by Look action
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        look = GetComponent<PlayerLook>();


        // Declare GO's for use of Scope action
        weaponHolder = GameObject.Find("weaponHolder");
        scopeView = GameObject.Find("ScopeView2");
        scopeView.SetActive(false);
        animator = weaponHolder.GetComponent<Animator>();
        
    }

    void Update()
    {
        // Scope Function
        if (onFoot.Scope.triggered)
        {
            isScoped = !isScoped;

            // Trigger "Scoped" animation
            animator.SetBool("Scoped", isScoped);

            // Delay Crosshairs and Gun Removal to account for "Scoped" Animation
            if(isScoped)
                StartCoroutine(OnScoped());
            else
                OnUnscoped();
        }
    }

    void OnUnscoped()
    {
        scopeView.SetActive(false);
        weaponHolder.SetActive(true);
        Camera.main.fieldOfView = normalPOV;
    }

    IEnumerator OnScoped()
    {
        // .15 seconds is the exact same duration of the "Scoped" animation in 
        //  the animation controller in Unity
        yield return new WaitForSeconds(.15f);

        scopeView.SetActive(true);
        weaponHolder.SetActive(false);
        Camera.main.fieldOfView = zoomPOV;
    }

    // This calls look to adjust accordingly with player input
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    // These allow Look to work but idk what they do
    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
