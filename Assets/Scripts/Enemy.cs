using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private float _startTime;

    private void Start()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time >= _startTime + _lifeTime)
            Destroy(gameObject);
    }
}
