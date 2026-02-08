using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    [SerializeField] private GameObject _groundCheck;
    [SerializeField] private LayerMask _groundLayer; 
    
    [SerializeField] private float _jumpForce = 7f;
    public bool _isGrounded {get; private set;}
    
    
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        IsGrounded();
        InputJump();

    }
    
    private void InputJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            
        }
    }

    private void IsGrounded()
    {
        float _capsuleDistance = .1f;
        float _capsuleAngle = 0f;
        _isGrounded = Physics2D.CapsuleCast(_groundCheck.transform.position, new Vector2(0.3f, 0.3f),
            CapsuleDirection2D.Vertical, _capsuleAngle, Vector2.down,  _capsuleDistance, _groundLayer);
    }
    
}
