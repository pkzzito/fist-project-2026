using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int coins = 0;

    public void AddCoin()
    {
        coins++;

        Debug.Log(
            gameObject.name +
            " pegou uma moeda. Total: " +
            coins
        );
    }
}
