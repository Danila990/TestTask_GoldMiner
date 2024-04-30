using System;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public event Action<int> OnUpdateCoins;

    public int Coins { get; private set; } = 0;

    public void AddCoind(int coins)
    {
        Coins += coins;
        OnUpdateCoins?.Invoke(Coins);
    }
}
