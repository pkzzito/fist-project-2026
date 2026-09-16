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

    private void Update()
    {
        // Procurar os jogadores
        if (player1 == null || player2 == null)
        {
            PlayerScore[] players =
                FindObjectsByType<PlayerScore>(
                    FindObjectsSortMode.None
                );

            foreach (PlayerScore player in players)
            {
                if (player.playerNumber == 1)
                    player1 = player;

                if (player.playerNumber == 2)
                    player2 = player;
            }
        }

        // CONTINUA MOSTRANDO AS MOEDAS
        if (player1 != null)
        {
            p1Text.text = "P1: " + player1.coins;
        }

        if (player2 != null)
        {
            p2Text.text = "P2: " + player2.coins;
        }
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
            winnerText.text =
                "EMPATE!";
        }
    }
}