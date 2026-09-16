using UnityEngine;

public class GameManagerStars : MonoBehaviour
{
    public static GameManagerStars Instance;

    private int totalEstrelas;
    private int estrelasColetadas;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Conta quantas estrelas existem na cena
        totalEstrelas =
            FindObjectsByType<Pickup>(FindObjectsSortMode.None).Length;

        Debug.Log(
            "Total de estrelas na fase: " +
            totalEstrelas
        );
    }

    public void EstrelaColetada()
    {
        estrelasColetadas++;

        Debug.Log(
            "Estrelas coletadas: " +
            estrelasColetadas +
            "/" +
            totalEstrelas
        );

        if (estrelasColetadas >= totalEstrelas)
        {
            FinalizarPartida();
        }
    }

    private void FinalizarPartida()
    {
        Debug.Log("TODAS AS ESTRELAS FORAM COLETADAS!");

        ScoreUI scoreUI =
            FindFirstObjectByType<ScoreUI>();

        if (scoreUI != null)
        {
            scoreUI.MostrarResultado();
        }
    }
}