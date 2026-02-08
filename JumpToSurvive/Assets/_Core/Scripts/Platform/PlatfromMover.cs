using System.Collections;
using UnityEngine;

public class PlatfromMover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private BoxCollider2D _collider;
    
    private float _timeToDestroy = 3f;
    private float _timeToReturn = 5f;
    private bool _isObjectDestroyed;

    private void Update()
    {
        if (_isObjectDestroyed)
        {
            _timeToReturn -= Time.deltaTime;
            if (_timeToReturn <= 0f)
            {
                PlatformReturn();
                _timeToReturn = 5f;
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            StartCoroutine(PlatfromDestroyer());
        }
    }

    private IEnumerator PlatfromDestroyer()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        _sprite.enabled = false;
        _collider.enabled = false;
        _isObjectDestroyed = true;
    }

    private void PlatformReturn()
    {
        _sprite.enabled = true;
        _collider.enabled = true;
        _isObjectDestroyed = false;
    }
    
}
