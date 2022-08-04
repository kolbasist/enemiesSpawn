using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _lifeTime;    

    private void Start()
    {
        var lifeCycle = StartCoroutine(DestroyEnemy());
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(_lifeTime);

        Destroy(gameObject);
    }    
}
