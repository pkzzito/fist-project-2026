using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [Header("Identificação do jogador")]
    public int playerNumber = 1;

    [Header("Pontuação")]
    public int coins { get; private set; }
    public int stars { get; private set; }

    // Observer
    public event Action<int> OnCoinsChanged;
    public event Action<int> OnStarsChanged;

    public void AddCoin()
    {
        coins++;

        Debug.Log(
            "Jogador " + playerNumber +
            " pegou uma moeda. Total: " + coins
        );

        // Avisa todos os interessados que a quantidade mudou
        OnCoinsChanged?.Invoke(coins);
    }

    public void AddStar()
    {
        stars++;

        Debug.Log(
            "Jogador " + playerNumber +
            " pegou uma estrela. Total: " + stars
        );

        OnStarsChanged?.Invoke(stars);
    }
}