using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Vector2 _playerVelocity;
    
    private float horizontalInput;
    [SerializeField] private float _speed;
    
    private bool _isFacingRight = true;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InputHandler();
        Flip();
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

    private void Flip()
    {
        if (_isFacingRight && horizontalInput < 0f || !_isFacingRight && horizontalInput > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
