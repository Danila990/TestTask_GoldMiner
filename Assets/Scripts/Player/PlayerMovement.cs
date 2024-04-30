using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private float _minXScreenBounds;
    private float _maxXScreenBounds;
    private SpriteRenderer _spriteRenderer;
    private float _inputX;
    private IInputService _inputService;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        CalculateScreenBounds();
        _inputService = ProjectContext.Instance.InputService;
        _inputService.OnInputX += UpdateInput;
    }

    private void OnDestroy()
    {
        _inputService.OnInputX -= UpdateInput;
    }

    private void Update()
    {
        Flip();
        Movement();
    }

    private void CalculateScreenBounds()
    {
        float playerWidth = _spriteRenderer.bounds.size.x / 2f;
        Camera camera = Camera.main;
        _minXScreenBounds = camera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + playerWidth;
        _maxXScreenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - playerWidth;
    }

    private void UpdateInput(float x)
    {
        _inputX = x;
    }

    private void Movement()
    {
        Vector3 newPosition = transform.position + Vector3.right * _inputX * _moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, _minXScreenBounds, _maxXScreenBounds);
        transform.position = newPosition;
    }

    private void Flip()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        if (_inputX > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_inputX < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
