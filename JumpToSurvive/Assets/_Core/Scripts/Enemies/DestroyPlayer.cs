using System;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<PlayerMovement>())
        {
            Destroy(other.gameObject);
            Debug.Log("Game lost");
        }
    }
}
