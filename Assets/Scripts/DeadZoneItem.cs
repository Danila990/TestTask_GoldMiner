using UnityEngine;

public class DeadZoneItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Item item))
        {
            item.gameObject.SetActive(false);
        }
    }
}
