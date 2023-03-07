using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyPoints;
    [SerializeField] private Enemy1 _enemy;

    private Transform[] _spawnPoints;
    private Coroutine _coroutine;

    private void Start()
    {
        _spawnPoints = new Transform[_enemyPoints.childCount];

        for (int i = 0; i < _enemyPoints.childCount; i++)
        {
            _spawnPoints[i] = _enemyPoints.GetChild(i);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds waitValue = new WaitForSeconds(2);

        foreach (var point in _spawnPoints)
        {
            Instantiate(_enemy, new Vector3(point.position.x, point.position.y), Quaternion.identity);
            yield return waitValue;
        }
    }
}

public class Enemy1 : MonoBehaviour
{
}