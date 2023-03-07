using UnityEngine;

public class EnemySpavner : MonoBehaviour
{
    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnTime;

    private float _elapserTime = 0;

    private void Update()
    {
        _elapserTime += Time.deltaTime;

        if (_elapserTime >= _spawnTime)
        {
            _elapserTime = 0;

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            Instantiate(_enemyPrefab, _spawnPoints[spawnPointNumber]);
        }
    }
}