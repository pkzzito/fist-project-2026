using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [Header("Textos da UI")]
    public TMP_Text p1Text;
    public TMP_Text p2Text;
    public TMP_Text winnerText;

    [Header("Configuração da vitória")]
    public int moedasParaVencer = 3;

    private PlayerScore player1;
    private PlayerScore player2;

    private bool jogoTerminado = false;

    private void Update()
    {
        // Procurar os jogadores
        if (player1 == null || player2 == null)
        {
            PlayerScore[] players =
                FindObjectsByType<PlayerScore>(FindObjectsSortMode.None);

            foreach (PlayerScore player in players)
            {
                if (player.playerNumber == 1)
                    player1 = player;

                if (player.playerNumber == 2)
                    player2 = player;
            }
        }

        // Atualizar contador do P1
        if (player1 != null)
        {
            p1Text.text = "P1: " + player1.coins;

            if (!jogoTerminado && player1.coins >= moedasParaVencer)
            {
                MostrarVencedor(1);
            }
        }

        // Atualizar contador do P2
        if (player2 != null)
        {
            p2Text.text = "P2: " + player2.coins;

            if (!jogoTerminado && player2.coins >= moedasParaVencer)
            {
                MostrarVencedor(2);
            }
        }
    }

    private void MostrarVencedor(int jogador)
    {
        jogoTerminado = true;

        winnerText.text =
            "PARABÉNS! JOGADOR " + jogador + " GANHOU!!!";

        Debug.Log(
            "JOGADOR " + jogador +
            " GANHOU A PARTIDA!"
        );
    }
}