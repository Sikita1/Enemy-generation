using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _numberEnemies;
    [SerializeField] private float _interval;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int minInclusive = 0;

        for (int i = 0; i < _numberEnemies; i++)
        {
            int randomPosition = Random.Range(minInclusive, _spawnPoints.Length);
            Instantiate(_template, _spawnPoints[randomPosition].position, Quaternion.identity);
            yield return new WaitForSeconds(_interval);
        }
    }
}
