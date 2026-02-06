using System;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer; 
    
    private float _jumpForce = 5f;
    private bool _isGrounded = true;
    
    
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputJump();
    }
    
    private void InputJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            
        }
    }
}
