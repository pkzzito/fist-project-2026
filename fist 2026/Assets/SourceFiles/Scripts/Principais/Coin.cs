using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLISÃO COM A MOEDA!");
        Debug.Log("Objeto: " + other.gameObject.name);
    }
}