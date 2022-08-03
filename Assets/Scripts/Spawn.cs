using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private uint _spawnperiod = 2;
    [SerializeField] private Transform  _points;

    private Transform[] _pointsArray;
    private bool _isSpawned = false;
    private uint _spawnCount = 0;
    private int _pointsCount; 
    private int _spawnIndex = 0;

    private void Start()
    {
        _pointsCount = _points.childCount;
        _pointsArray = new Transform[_pointsCount];

        for (int i = 0; i < _pointsCount; i++)
        {
            _pointsArray[i] = _points.GetChild(i);
        }

        Debug.Log($"Spawn {_template.name} every {_spawnperiod} seconds started.");
    }

    private void Update()
    {
        _isSpawned = Time.time / _spawnperiod <_spawnCount;
        

        if (_isSpawned == false)
        {
            GameObject newObject = Instantiate(_template, _pointsArray[_spawnIndex].position, Quaternion.identity);
            _isSpawned = true;
            _spawnCount++;
            _spawnIndex++;
            Debug.Log($"{Time.time}, {_spawnCount} spawned");
        }

        if(_spawnIndex >= _pointsCount)
        {
            _spawnIndex = 0;
        }
    }
}
