using System;
using UnityEngine;

public class LevelComplition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
                Debug.Log("Player won");
            
        }
    }
}
