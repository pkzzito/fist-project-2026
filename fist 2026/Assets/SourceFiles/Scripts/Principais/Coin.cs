using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool coletada = false;

    private void OnTriggerEnter(Collider other)
    {
        if (coletada)
            return;

        PlayerController player =
            other.GetComponentInParent<PlayerController>();

        PlayerScore score =
            other.GetComponentInParent<PlayerScore>();

        if (player != null && score != null)
        {
            coletada = true;

            // Desativa o collider imediatamente
            Collider coinCollider = GetComponent<Collider>();

            if (coinCollider != null)
                coinCollider.enabled = false;

            // Adiciona a moeda ao contador
            score.AddCoin();

            // AUMENTA A VELOCIDADE
            player.IncreaseSpeed();

            Debug.Log(
                "Moeda coletada! Nova velocidade: " +
                player.speed
            );

            // Faz a moeda desaparecer
            Renderer coinRenderer = GetComponent<Renderer>();

            if (coinRenderer != null)
                coinRenderer.enabled = false;

            Destroy(gameObject);
        }
    }
}