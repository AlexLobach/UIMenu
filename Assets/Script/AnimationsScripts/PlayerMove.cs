using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("GOOOOOOOOOOOOOOOOOOOOOO");
            animator.SetBool("IsWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("IsWalk", false);
        }
    }
}
