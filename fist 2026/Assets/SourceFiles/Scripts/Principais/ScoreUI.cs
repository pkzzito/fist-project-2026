using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [Header("Textos da UI")]
    public TMP_Text p1Text;
    public TMP_Text p2Text;

    [Header("Jogadores")]
    public PlayerScore player1;
    public PlayerScore player2;

    private void Start()
    {
        // Atualiza a UI inicialmente
        AtualizarP1(player1.coins);
        AtualizarP2(player2.coins);

        // Escuta quando a pontuação mudar
        player1.OnCoinsChanged += AtualizarP1;
        player2.OnCoinsChanged += AtualizarP2;
    }

    private void OnDestroy()
    {
        // Remove os eventos quando a UI for destruída
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
}