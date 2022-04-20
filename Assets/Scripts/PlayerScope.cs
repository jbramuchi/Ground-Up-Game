using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScope : MonoBehaviour
{
    public Animator animator;

    private bool isScoped = false;

    public void ProcessScope(float input)
    {
        if(input > 0f)
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);
        }
    }
}
