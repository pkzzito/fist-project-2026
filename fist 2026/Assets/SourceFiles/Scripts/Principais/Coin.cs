using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Coin.cs funcionando!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Moeda tocada por: " + other.gameObject.name);

        PlayerController player =
            other.GetComponentInParent<PlayerController>();

        PlayerScore score =
            other.GetComponentInParent<PlayerScore>();

        if (player != null && score != null)
        {
            Debug.Log("Jogador encontrado: " + score.playerNumber);

            score.AddCoin();
            player.IncreaseSpeed();

            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning(
                "Não encontrei PlayerController ou PlayerScore em " +
                other.gameObject.name
            );
        }
    }
}