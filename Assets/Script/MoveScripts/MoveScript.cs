using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveScript : MonoBehaviour

//ести на плеере будет отсутствовать компонент Rigidbody
//эта строчка гарантирует что наш скрипт не завалится 

{
    public float Speed = 10f;
    public float JumpForce = 300f;

    //что бы эта переменная работала добавьте тэг "Ground" на вашу поверхность земли
    private bool _isGrounded;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // обратите внимание что все действия с физикой 
    // необходимо обрабатывать в FixedUpdate, а не в Update
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
        else _rb.AddForce(movement * Speed);
    }

    private void JumpLogic()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * JumpForce);

                // Обратите внимание что я делаю на основе Vector3.up 
                // а не на основе transform.up. Если персонаж упал или 
                // если персонаж -- шар, то его личный "верх" может 
                // любое направление. Влево, вправо, вниз...
                // Но нам нужен скачек только в абсолютный вверх, 
                // потому и Vector3.up
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        _isGrounded = value;
        
    }
}
