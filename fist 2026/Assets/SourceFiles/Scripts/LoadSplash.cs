using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSplash : MonoBehaviour
{
    void Start()
    {
        Invoke("CarregarSplash", 0.5f); // espera 2 segundos
    }

    void CarregarSplash()
    {
        SceneManager.LoadScene("SplashManager");
    }
}