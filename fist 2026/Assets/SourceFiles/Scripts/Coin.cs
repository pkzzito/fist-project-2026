using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerCoin player = other.GetComponent<PlayerCoin>();

        if (player != null)
        {
            player.CollectCoin();

            Destroy(gameObject);
        }
    }
}