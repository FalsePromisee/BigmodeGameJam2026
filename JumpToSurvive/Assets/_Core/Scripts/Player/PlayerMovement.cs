using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Vector2 _playerVelocity;
    
    private float horizontalInput;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InputHandler();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        _playerVelocity = _rigidBody.linearVelocity;
        _playerVelocity.x = horizontalInput * _speed * Time.fixedDeltaTime;
        _rigidBody.linearVelocity = _playerVelocity;
    }

    private void InputHandler()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }
    
}
