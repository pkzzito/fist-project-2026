using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text coinsText;

    private void OnEnable()
    {
        PlayerObserve.OnCoinsChanged += UpdateCoins;
    }

    private void OnDisable()
    {
        PlayerObserve.OnCoinsChanged -= UpdateCoins;
    }

    private void UpdateCoins(int amount)
    {
        coinsText.text = "Moedas: " + amount;
    }
}
