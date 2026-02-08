using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class RemoveBasePlatform : MonoBehaviour
{
    private float _timer = 10f;
    private float _timeBeforeDestroy = 2f;
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            Destroy(gameObject);
        }

        if (Input.anyKeyDown)
        {
            StartCoroutine(DestroyPlatform());
        }
    }

    private IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(_timeBeforeDestroy);
        Destroy(gameObject);
    }
    
}
