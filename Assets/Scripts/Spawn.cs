using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private uint _enemyCount = 12;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private Transform _points;

    private Transform[] _pointsArray;
    //private uint _spawnCount = 0;
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

        Debug.Log($"Spawn {_template.name} every {_duration} seconds started.");

        var spawnQueue = StartCoroutine( CreateSpawnQueue(_enemyCount));
    }

    private IEnumerator CreateSpawnQueue(uint count)
    {
        var waitForFewSeconds = new WaitForSeconds(_duration);

        for (int i = 0; i < count; i++)
        {
            Enemy newEnemy = Instantiate(_template, _pointsArray[_spawnIndex].position, Quaternion.identity);
            Debug.Log($"{Time.time}, _spawnCount spawned at {_pointsArray[_spawnIndex].position}.");
            _spawnIndex++;

            if (_spawnIndex >= _pointsCount)
            {
                _spawnIndex = 0;
            }

            yield return waitForFewSeconds;
        }
    }

    //private void Update()
    //{
    //    bool _isSpawned = Time.time / _duration < _spawnCount;

    //    if (_isSpawned == false)
    //    {
            
    //        _spawnCount++;
    //        
    //        _spawnIndex++;
    //    }

        
    //}
}
