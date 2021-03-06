using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private PoolObject _poolPrefab;
    [SerializeField] private Transform _contaner;
    [SerializeField] private int _minObjects, _maxObjects;
    [SerializeField] private bool _autoExpand;

    private List<PoolObject> _pool;

    private void OnValidate()
    {
        if(_autoExpand) _maxObjects = Int32.MaxValue;
    }

    private void Start()
    {
        CreatePool();
    }
    private void CreatePool()
    {
        _pool = new List<PoolObject>(_minObjects);

        for (int i = 0; i < _minObjects; i++)
        {
            CreateElement();
        }
    }

    private PoolObject CreateElement(bool isActiveByDefault = false)
    {
        var createdObject = Instantiate(_poolPrefab, _contaner);
        createdObject.gameObject.SetActive(false);

        _pool.Add(createdObject);

        return createdObject;
    }

    public bool TryGetElement(out PoolObject element)
    {
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;

            }
        }
        element = null;
        return false;
    }
    public PoolObject GetFreeElement(Vector3 position, Quaternion rotation)
    {
        var element = GetFreeElement(position);
        element.transform.rotation = rotation;
        return element;
    }
    public PoolObject GetFreeElement(Vector3 position)
    {
        var element = GetFreeElement();
        element.transform.position = position;
        return element;
    }

    public PoolObject GetFreeElement()
    {
        if (TryGetElement(out var element))
        {
            return element;
        }

        if (_autoExpand)
        {
            return CreateElement(true);
        }

        if (_pool.Count < _maxObjects)
        {
            return CreateElement(true);
        }

        throw new Exception("Pool is over.");
    }
}
