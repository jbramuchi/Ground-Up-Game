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

    // Like update()
    void Awake()
    {
        //Hide Cursor (PC Testing Purposes)
        Cursor.lockState = CursorLockMode.Locked;

        playerInput = new PlayerInput();
        weaponHolder = GameObject.Find("weaponHolder");
        scopeView = GameObject.Find("ScopeView2");
        scopeView.SetActive(false);

        onFoot = playerInput.OnFoot;
        
        animator = weaponHolder.GetComponent<Animator>();
        look = GetComponent<PlayerLook>();
    }

    void Update()
    {
        // Scope Function
        if (onFoot.Scope.triggered)
        {
            Debug.Log("flag");
            isScoped = !isScoped;

            Debug.Log("flag2");
            animator.SetBool("Scoped", isScoped);

            Debug.Log("flag3");
            if(isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                OnUnscoped();
            }

            
        }
    }

    void OnUnscoped()
    {
        scopeView.SetActive(false);
        weaponHolder.SetActive(true);
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);

        scopeView.SetActive(true);
        weaponHolder.SetActive(false);
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
