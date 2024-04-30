using TMPro;
using UnityEngine;

public class OutputCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private CoinController _controller;

    private void Start()
    {
        _controller = ProjectContext.Instance.CoinController;
        Output(_controller.Coins);
        _controller.OnUpdateCoins += Output;
    }

    private void OnDestroy()
    {
        _controller.OnUpdateCoins -= Output;
    }

    private void Output(int coins)
    {
        _text.text = coins.ToString();
    }
}
