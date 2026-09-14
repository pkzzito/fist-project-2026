using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string sceneName;

    public enum GameState
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    public GameState currentState;

    private bool guiLoaded = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetState(GameState.Iniciando);
        LoadScene("SplashManager");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Cena carregada: " + scene.name);

        if (scene.name == "SplashManager")
        {
            SetState(GameState.Iniciando);
        }
        else if (scene.name == "menu")
        {
            SetState(GameState.MenuPrincipal);
        }
        else if (scene.name == "GetStarted_Scene")
        {
            SetState(GameState.Gameplay);

            LoadGUI();
        }
    }

    public void SetState(GameState newState)
    {
        currentState = newState;

        Debug.Log("Estado atual: " + currentState);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadGameplay()
    {
        Debug.Log("Carregando Gameplay...");

        guiLoaded = false;

        SceneManager.LoadScene("GetStarted_Scene");
    }

    private void LoadGUI()
    {
        if (guiLoaded)
            return;

        guiLoaded = true;

        Debug.Log("Carregando GUI de forma aditiva...");

        SceneManager.LoadScene(
            "GUI",
            LoadSceneMode.Additive
        );
    }

    public void SetupPlayerInput(PlayerInput playerInput)
    {
        Debug.Log(
            "Input atribuído ao jogador: " +
            playerInput.name
        );
    }

    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}