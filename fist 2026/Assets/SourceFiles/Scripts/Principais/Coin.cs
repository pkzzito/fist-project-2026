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

            // Desliga o collider
            Collider collider = GetComponent<Collider>();

            if (collider != null)
                collider.enabled = false;

            // Desliga a imagem da moeda
            Renderer renderer = GetComponent<Renderer>();

            if (renderer != null)
                renderer.enabled = false;

            // Dá o ponto
            score.AddCoin();

            // Aumenta a velocidade
            player.IncreaseSpeed();

            // Destrói a moeda
            Destroy(gameObject);
        }
    }
}