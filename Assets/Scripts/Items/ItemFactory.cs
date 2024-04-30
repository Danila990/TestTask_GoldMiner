using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class ItemFactory
{
    public event Action<Item> OnSpawnItem;

    [SerializeField] private Item _prefab;
    [SerializeField] private float _spawnDelay;

    public ObjectPull<Item> ObjectPull { get; private set; }

    public void Init(MonoBehaviour monoBehaviour)
    {
        ObjectPull = new ObjectPull<Item>(_prefab);
        monoBehaviour.StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Item item = ObjectPull.Get();
            item.gameObject.SetActive(false);
            OnSpawnItem?.Invoke(item);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

}
