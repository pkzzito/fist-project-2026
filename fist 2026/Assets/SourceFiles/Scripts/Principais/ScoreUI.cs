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

        // Configura P1
        if (player1 != null)
        {
            AtualizarP1();

            player1.OnCoinsChanged += AtualizarP1Coins;
            player1.OnStarsChanged += AtualizarP1Stars;
        }

        // Configura P2
        if (player2 != null)
        {
            AtualizarP2();

            player2.OnCoinsChanged += AtualizarP2Coins;
            player2.OnStarsChanged += AtualizarP2Stars;
        }

        // Esconde o texto de vencedor no início
        if (winnerText != null)
            winnerText.text = "";
    }

    private void OnDestroy()
    {
        if (player1 != null)
        {
            player1.OnCoinsChanged -= AtualizarP1Coins;
            player1.OnStarsChanged -= AtualizarP1Stars;
        }

        if (player2 != null)
        {
            player2.OnCoinsChanged -= AtualizarP2Coins;
            player2.OnStarsChanged -= AtualizarP2Stars;
        }
    }

    // =========================
    // ATUALIZAÇÃO DO P1
    // =========================

    private void AtualizarP1()
    {
        p1Text.text =
            "P1: " +
            player1.coins +
            " moedas | " +
            player1.stars +
            " estrelas";
    }

    private void AtualizarP1Coins(int coins)
    {
        AtualizarP1();
    }

    private void AtualizarP1Stars(int stars)
    {
        AtualizarP1();
    }

    // =========================
    // ATUALIZAÇÃO DO P2
    // =========================

    private void AtualizarP2()
    {
        p2Text.text =
            "P2: " +
            player2.coins +
            " moedas | " +
            player2.stars +
            " estrelas";
    }

    private void AtualizarP2Coins(int coins)
    {
        AtualizarP2();
    }

    private void AtualizarP2Stars(int stars)
    {
        AtualizarP2();
    }

    // =========================
    // RESULTADO
    // =========================

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