using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
