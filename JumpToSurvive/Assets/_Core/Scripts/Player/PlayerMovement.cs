using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Jump _jumpScript;
    
    
    private Vector2 _playerVelocity;
    private float horizontalInput;
    [SerializeField] private float _speed;

    #region WallJumpVariables
    
    [SerializeField] private float _wallSlidingSpeed = 3f;
    private bool _isWallJumping;
    private float _wallJumpDirection;
    private float _wallJumpCounter;
    private float _wallJumpDuration = .4f;
    private float _wallJumpTime = .2f;
    private Vector2 _wallJumpPower = new Vector2(16f, 20f);
    
    #endregion
    
    
    private bool _isFacingRight = true;
    private bool _isWallSliding;
    
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private LayerMask _wallLayer;
    
    
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _jumpScript = GetComponent<Jump>();
    }

    private void Update()
    {
        InputHandler();
        WallSlide();
        WallJump();

        if (!_isWallJumping)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (!_isWallJumping)
        {
            Movement();            
        }
        
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

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(_wallCheck.position, 0.2f, _wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !_jumpScript._isGrounded && horizontalInput != 0)
        {
            _isWallSliding = true;
            _rigidBody.linearVelocity = new Vector2(_rigidBody.linearVelocity.x, Mathf.Clamp(_rigidBody.linearVelocity.y, -_wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            _isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (_isWallSliding)
        {
            _isWallJumping = false;
            _wallJumpDirection = -transform.localScale.x;
            _wallJumpCounter = _wallJumpTime;
            
            CancelInvoke(nameof(StopWallJump));
        }
        else
        {
            _wallJumpCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _wallJumpCounter > 0)
        {
            _isWallJumping = true;
            _rigidBody.linearVelocity = new Vector2(_wallJumpPower.x * _wallJumpDirection, _wallJumpPower.y); 
            _wallJumpCounter = 0f;
            if (transform.localScale.x != _wallJumpDirection)
            {
                _isFacingRight =  !_isFacingRight;
                Vector2 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
            
            Invoke(nameof(StopWallJump), _wallJumpDuration);
        }
    }
    
    private void StopWallJump()
    {
        _isWallJumping = false;
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
