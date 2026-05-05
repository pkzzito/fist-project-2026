using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameStates.GameState currentState;

    private void Awake()
    {
        // Singleton (só existe um GameManager)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // não destrói ao trocar de cena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetState(GameStates.GameState newState)
    {
        currentState = newState;
        Debug.Log("Novo estado: " + currentState);
    }
    
    void CarregarMenu()
    {
        SceneManager.LoadScene("menu");
    }
    
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}