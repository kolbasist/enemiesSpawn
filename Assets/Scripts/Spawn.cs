using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private uint _spawnperiod = 2;

    private bool _isSpawned = false;
    private uint _spawnCount = 0;

    private void Start()
    {
        Debug.Log($"Spawn {_template.name} started every {_spawnperiod} seconds.");
    }

    private void Update()
    {
        _isSpawned = Time.time / _spawnperiod <_spawnCount;
        Debug.Log($"{Time.time} - {_isSpawned}");

        if (_isSpawned == false)
        {
            GameObject newObject = Instantiate(_template, new Vector3(0, 0, 0), Quaternion.identity);
            _isSpawned = true;
        }
    }
}
