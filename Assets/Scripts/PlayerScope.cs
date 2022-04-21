using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScope : MonoBehaviour
{
    public Animator animator;
    //GameObject weaponHolder = GameObject.Find("weaponHolder");
    

    private bool isScoped = false;

    public void ProcessScope(bool input)
    {
        //animator = weaponHolder.GetComponent<Animator>();
        Debug.Log("flag1");
        if (input)
        {
            Debug.Log("flag2");
            isScoped = !isScoped;
            animator.SetBool("Scoped", !isScoped);
        }
    }
}
