using UnityEngine;

public class GameManagerStars : MonoBehaviour
{
    public static GameManagerStars Instance;

    [Header("Configuração da partida")]
    public int totalEstrelas = 6;

    private int estrelasColetadas;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        estrelasColetadas = 0;

        Debug.Log("=================================");
        Debug.Log("TOTAL DE ESTRELAS DA FASE: " + totalEstrelas);
        Debug.Log("=================================");
    }

    public void EstrelaColetada()
    {
        // Impede que passe de 6
        if (estrelasColetadas >= totalEstrelas)
            return;

        estrelasColetadas++;

        Debug.Log(
            "Estrelas coletadas: " +
            estrelasColetadas +
            "/" +
            totalEstrelas
        );

        // Quando as 6 estrelas forem coletadas
        if (estrelasColetadas >= totalEstrelas)
        {
            FinalizarPartida();
        }
    }

    private void FinalizarPartida()
    {
        Debug.Log("TODAS AS 6 ESTRELAS FORAM COLETADAS!");

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