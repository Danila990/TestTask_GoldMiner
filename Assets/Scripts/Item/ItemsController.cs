using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    [SerializeField] private float _screenBoundsOffsetX = 1f;
    [SerializeField] private float _screenBoundsOffsetY = 2f;
    [SerializeField] private float _spawnDelay = 0.5f;
    [SerializeField] private float _spawnOffsetX = 0.3f;
    [SerializeField] private ItemFactory[] _ItemFactorys;

    private Stack<Item> _stackItems = new Stack<Item>();
    private float _minXScreenBounds;
    private float _maxXScreenBounds;
    private float _YScreenBounds;

    public void Init(ProjectContext projectContext)
    {
        CalculateOffsets();
        StartItemFactorys();
        StartCoroutine(SpawnCoroutine());
    }

    private void StartItemFactorys()
    {
        foreach (var item in _ItemFactorys)
        {
            item.Init(this);
            item.OnSpawnItem += SpawnItem;
        }
    }

    private void CalculateOffsets()
    {
        Camera camera = Camera.main;
        _minXScreenBounds = camera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + _screenBoundsOffsetX;
        _maxXScreenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - _screenBoundsOffsetX;
        _YScreenBounds = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y + _screenBoundsOffsetY;
    }

    private IEnumerator SpawnCoroutine()
    {
        Vector3 preview = new Vector3();
        while (true)
        {
            yield return new WaitUntil(() => _stackItems.Count > 0);
            Item item = _stackItems.Pop();
            item.gameObject.SetActive(true);
            Vector3 spawnPosition = GetRandomPosition(preview);
            preview = spawnPosition;
            item.transform.position = spawnPosition;
            yield return new WaitForSeconds(_spawnDelay - _stackItems.Count * 0.05f);
        }
    }

    private Vector3 GetRandomPosition(Vector3 preview)
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(_minXScreenBounds, _maxXScreenBounds), _YScreenBounds, 0);
            if (Vector3.Distance(preview, spawnPosition) > _spawnOffsetX)
            {
                return spawnPosition;
            }
        }
    }

    private void SpawnItem(Item item)
    {
        _stackItems.Push(item);
    }
}

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
        while(true)
        {
            Item item = ObjectPull.Get();
            item.gameObject.SetActive(false);
            OnSpawnItem?.Invoke(item);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

}
