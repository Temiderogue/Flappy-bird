using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _column;
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        Vector2 _spawnPosition = new Vector2(7, Random.Range(-3.6f, 2.7f));
        Instantiate(_column, _spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Spawn());
    }
}
