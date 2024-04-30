using System.Collections.Generic;
using UnityEngine;

public class ObjectPull<T> where T : MonoBehaviour
{
    protected readonly List<T> _pullList = new List<T>();
    protected readonly Transform _parent;

    public T Prefab { get; private set; }

    public ObjectPull(string assetPath, Transform parent = null)
    {
        Prefab = Resources.Load<T>(assetPath);
        _parent = parent;
        if (Prefab == null)
        {
            Debug.LogError("Resourcesl Load error:" + assetPath);
        }
    }

    public ObjectPull(T prefab, Transform parent = null)
    {
        Prefab = prefab;
        _parent = parent;
        if (Prefab == null)
        {
            Debug.LogError("Prefab null");
        }
    }

    public T Get()
    {
        foreach (T objectPull in _pullList)
        {
            if (objectPull.gameObject.activeInHierarchy == false)
            {
                objectPull.gameObject.SetActive(true);
                return objectPull;
            }
        }

        return Create();
    }

    public T Create(Vector3 position)
    {
        T spawnObject = Create();
        spawnObject.transform.position = position;
        _pullList.Add(spawnObject);
        return spawnObject;
    }

    public T Create()
    {
        T spawnObject = Object.Instantiate(Prefab);
        _pullList.Add(spawnObject);
        return spawnObject;
    }

    public void Destroy(T destroyObject)
    {
        _pullList.Remove(destroyObject);
        Destroy(destroyObject);
    }
}