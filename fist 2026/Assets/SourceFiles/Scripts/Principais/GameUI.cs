using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("Textos da interface")]
    public TextMeshProUGUI player1Coins;
    public TextMeshProUGUI player2Coins;
    public TextMeshProUGUI winnerText;

    private PlayerScore player1;
    private PlayerScore player2;

    private void Start()
    {
        winnerText.text = "";

        PlayerScore[] players =
            FindObjectsByType<PlayerScore>(FindObjectsSortMode.None);

        foreach (PlayerScore player in players)
        {
            if (player.playerNumber == 1)
            {
                player1 = player;
            }
            else if (player.playerNumber == 2)
            {
                player2 = player;
            }
        }

        if (player1 != null)
        {
            player1.OnCoinsChanged += UpdatePlayer1Coins;

            UpdatePlayer1Coins(player1.coins);
        }

        if (player2 != null)
        {
            player2.OnCoinsChanged += UpdatePlayer2Coins;

            UpdatePlayer2Coins(player2.coins);
        }
    }

    private void UpdatePlayer1Coins(int amount)
    {
        player1Coins.text = "P1: " + amount;
    }

    private void UpdatePlayer2Coins(int amount)
    {
        player2Coins.text = "P2: " + amount;
    }

    public void ShowWinner()
    {
        if (player1 == null || player2 == null)
            return;

        if (player1.stars > player2.stars)
        {
            winnerText.text = "JOGADOR 1 VENCEU!";
        }
        else if (player2.stars > player1.stars)
        {
            winnerText.text = "JOGADOR 2 VENCEU!";
        }
        else
        {
            winnerText.text = "EMPATE!";
        }
    }

    private void OnDestroy()
    {
        if (player1 != null)
        {
            player1.OnCoinsChanged -= UpdatePlayer1Coins;
        }

        if (player2 != null)
        {
            player2.OnCoinsChanged -= UpdatePlayer2Coins;
        }
    }
}