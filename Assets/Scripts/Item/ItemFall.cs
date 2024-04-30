using UnityEngine;

public class ItemFall : MonoBehaviour
{
    [SerializeField] private float _fallSpeed = 5f;

    private void Update()
    {
        Vector3 newPosition = transform.position + Vector3.down * _fallSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}
