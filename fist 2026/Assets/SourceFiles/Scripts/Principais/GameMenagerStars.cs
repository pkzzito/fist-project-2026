using UnityEngine;

public class GameManagerStars : MonoBehaviour
{
    public static GameManagerStars Instance;

    [Header("Configuração da partida")]
    public int totalEstrelas = 6;

    private int estrelasColetadas;
    private bool partidaFinalizada = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        estrelasColetadas = 0;

        Debug.Log("=================================");
        Debug.Log("TOTAL DE ESTRELAS: " + totalEstrelas);
        Debug.Log("MAIORIA NECESSÁRIA: " + (totalEstrelas / 2 + 1));
        Debug.Log("=================================");
    }

    public void EstrelaColetada()
    {
        // Se a partida já terminou, não faz mais nada
        if (partidaFinalizada)
            return;

        estrelasColetadas++;

        Debug.Log(
            "Estrelas coletadas: " +
            estrelasColetadas +
            "/" +
            totalEstrelas
        );

        VerificarVencedor();
    }

    private void VerificarVencedor()
    {
        PlayerScore[] players =
            FindObjectsByType<PlayerScore>(FindObjectsSortMode.None);

        PlayerScore player1 = null;
        PlayerScore player2 = null;

        foreach (PlayerScore player in players)
        {
            if (player.playerNumber == 1)
                player1 = player;

            else if (player.playerNumber == 2)
                player2 = player;
        }

        if (player1 == null || player2 == null)
        {
            Debug.LogError("Não foi possível encontrar os dois jogadores!");
            return;
        }

        // Calcula quantas estrelas são necessárias para ter maioria
        int maioria = totalEstrelas / 2 + 1;

        // Jogador 1 conseguiu a maioria
        if (player1.stars >= maioria)
        {
            FinalizarPartida();
            return;
        }

        // Jogador 2 conseguiu a maioria
        if (player2.stars >= maioria)
        {
            FinalizarPartida();
            return;
        }

        // Se todas as estrelas foram coletadas e ninguém teve maioria
        if (estrelasColetadas >= totalEstrelas)
        {
            FinalizarPartida();
        }
    }

    private void FinalizarPartida()
    {
        if (partidaFinalizada)
            return;

        partidaFinalizada = true;

        Debug.Log("PARTIDA FINALIZADA!");

        ScoreUI scoreUI =
            FindFirstObjectByType<ScoreUI>();

        if (scoreUI != null)
        {
            scoreUI.MostrarResultado();
        }
        else
        {
            Debug.LogError(
                "ScoreUI não foi encontrado na cena!"
            );
        }
    }
}