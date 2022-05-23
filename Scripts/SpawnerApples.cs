using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerApples : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _shift;

    private void Awake()
    {
        _points = new Transform[gameObject.transform.childCount];

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            _points[i] = gameObject.transform.GetChild(i);
        }
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            for (int j = 0; j < Random.Range(1,5); j++)
            {
                Instantiate(_template, _points[i].transform.position, _points[i].transform.rotation);
                _points[i].transform.position = new Vector3(_points[i].transform.position.x + _shift, _points[i].transform.position.y);
            }
        }
    }
}
