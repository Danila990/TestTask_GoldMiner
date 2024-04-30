using UnityEngine;

[RequireComponent(typeof(ItemFall))]
public class CoinItem : Item
{
    [SerializeField] private int _addCoin = 1;

    private CoinController _coinController;
    private AudioController _audioController;

    private void Start()
    {
        _coinController = ProjectContext.Instance.CoinController;
        _audioController = AudioController.Instance;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            _audioController.PlayCoin();
            _coinController.AddCoind(_addCoin);
            gameObject.SetActive(false);
        }
    }
}
