using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveScript : MonoBehaviour

{
    public ParticleSystem[] dusts;
    public float Speed = 10f;
    public float JumpForce = 300f;

    //что бы эта переменная работала добавьте тэг "Ground" на вашу поверхность земли
    private bool _isGrounded;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }    
    void FixedUpdate()
    {
        MovementLogic();        
        JumpLogic();
    }

    private void MovementLogic()
    {
                    
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _rb.AddForce(movement * (Speed * 3));
        }
        else
        {
            _rb.AddForce(movement * Speed);
            
        }
    
    }

    private void JumpLogic()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_isGrounded)
            {
                _rb.AddForce(transform.up * JumpForce);                
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpdate(collision, true);
        Debug.Log("On the Ground");
        CreateDust();
               
    
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpdate(collision, false);
        Debug.Log("Out the Ground");
    }

    private void IsGroundedUpdate(Collision collision, bool value)
    {        
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
           
        }
        
    }
    void CreateDust()
    {
        foreach(var dust in dusts) {
            dust.Play();            
        }              
    }


}
