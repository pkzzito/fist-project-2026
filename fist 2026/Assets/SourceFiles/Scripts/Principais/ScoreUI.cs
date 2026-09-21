using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [Header("Textos da UI")]
    public TMP_Text p1Text;
    public TMP_Text p2Text;
    public TMP_Text winnerText;

    private PlayerScore player1;
    private PlayerScore player2;

    private bool jogoTerminado = false;

    private void Start()
    {
        // Procura os jogadores
        PlayerScore[] players =
            FindObjectsByType<PlayerScore>(FindObjectsSortMode.None);

        foreach (PlayerScore player in players)
        {
            if (player.playerNumber == 1)
                player1 = player;

            if (player.playerNumber == 2)
                player2 = player;
        }

        // Configura a pontuação inicial
        if (player1 != null)
        {
            p1Text.text = "P1: " + player1.coins;
            player1.OnCoinsChanged += AtualizarP1;
        }

        if (player2 != null)
        {
            p2Text.text = "P2: " + player2.coins;
            player2.OnCoinsChanged += AtualizarP2;
        }

        // Esconde o texto de vencedor no início
        if (winnerText != null)
            winnerText.text = "";
    }

    private void OnDestroy()
    {
        if (player1 != null)
            player1.OnCoinsChanged -= AtualizarP1;

        if (player2 != null)
            player2.OnCoinsChanged -= AtualizarP2;
    }

    private void AtualizarP1(int coins)
    {
        p1Text.text = "P1: " + coins;
    }

    private void AtualizarP2(int coins)
    {
        p2Text.text = "P2: " + coins;
    }

    public void MostrarResultado()
    {
        if (jogoTerminado)
            return;

        if (player1 == null || player2 == null)
            return;

        jogoTerminado = true;

        if (player1.stars > player2.stars)
        {
            winnerText.text =
                "PARABÉNS! JOGADOR 1 GANHOU!!!";
        }
        else if (player2.stars > player1.stars)
        {
            winnerText.text =
                "PARABÉNS! JOGADOR 2 GANHOU!!!";
        }
        else
        {
            winnerText.text = "EMPATE!";
        }
    }
}