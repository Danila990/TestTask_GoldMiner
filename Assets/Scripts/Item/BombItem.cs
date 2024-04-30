using UnityEngine;

public class BombItem : Item
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private string _pageOpen = "GameOver";

    private AudioController _audioController;

    private void Start()
    {
        _audioController = AudioController.Instance;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            _audioController.PlayBomb();
            Instantiate(_explosionPrefab).transform.position = collision.transform.position;
            Time.timeScale = 0;
            PagesController.Instance.ShowPage(_pageOpen);
            gameObject.SetActive(false);
        }
    }
}
