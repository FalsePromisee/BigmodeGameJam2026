using UnityEngine;

public class PlatfromMover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private float _startYPos = 0f;
    private float _endYPos = 3f;

    private float _timeToReturn = 3f;

    //might need
    private float _startXPos = 0f;
    private float _endXPos = 0f;

    private void Awake()
    {
        _rigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            Debug.Log("Player touched platform");
            
        }

    }
}
