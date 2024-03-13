using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";
    private Animator animator;
    private Vector2 InputDirection;
    private const string MoveForwardHash = "MoveValue";
    private const string MoveStrafeHash = "StrafeValue";

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        InputDirection = new Vector2(Input.GetAxis(HorizontalAxisName), Input.GetAxis(VerticalAxisName));
        
        if (Input.GetKey(KeyCode.LeftShift))InputDirection.y += 1;
        
        animator.SetFloat(MoveForwardHash, InputDirection.y);
        animator.SetFloat(MoveStrafeHash, InputDirection.x);
    }
}
