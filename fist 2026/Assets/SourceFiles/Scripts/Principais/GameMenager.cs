using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // ==============================
    // SINGLETON
    // ==============================

    public static GameManager Instance;

    public string sceneName;

    // ==============================
    // ESTADOS DO JOGO
    // ==============================

    public enum GameState
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    public GameState currentState;

    // Impede que a GUI seja carregada várias vezes
    private bool guiLoaded = false;

    // ==============================
    // AWAKE
    // ==============================

    private void Awake()
    {
        // Singleton
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

    // ==============================
    // START
    // ==============================

    private void Start()
    {
        SetState(GameState.Iniciando);

        LoadScene("SplashManager");
    }

    // ==============================
    // CENA CARREGADA
    // ==============================

    private void OnSceneLoaded(
        Scene scene,
        LoadSceneMode mode)
    {
        Debug.Log(
            "Cena carregada: " + scene.name
        );

        // Splash
        if (scene.name == "SplashManager")
        {
            SetState(GameState.Iniciando);
        }

        // Menu
        else if (scene.name == "menu")
        {
            SetState(GameState.MenuPrincipal);
        }

        // Gameplay
        else if (scene.name == "GetStarted_Scene")
        {
            SetState(GameState.Gameplay);

            LoadGUI();
        }
    }

    // ==============================
    // ESTADO
    // ==============================

    public void SetState(GameState newState)
    {
        currentState = newState;

        Debug.Log(
            "Estado atual: " + currentState
        );
    }

    // ==============================
    // CARREGAR CENA NORMAL
    // ==============================

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ==============================
    // CARREGAR GAMEPLAY
    // ==============================

    public void LoadGameplay()
    {
        Debug.Log("Carregando Gameplay...");

        guiLoaded = false;

        SceneManager.LoadScene(
            "GetStarted_Scene"
        );
    }

    // ==============================
    // CARREGAR GUI
    // ==============================

    private void LoadGUI()
    {
        if (guiLoaded)
            return;

        guiLoaded = true;

        Debug.Log(
            "Carregando GUI de forma aditiva..."
        );

        SceneManager.LoadScene(
            "GUI",
            LoadSceneMode.Additive
        );
    }

    // ==============================
    // PLAYER INPUT
    // ==============================

    public void SetupPlayerInput(
        PlayerInput playerInput)
    {
        Debug.Log(
            "Input atribuído ao jogador: " +
            playerInput.name
        );
    }

    // ==============================
    // LOAD
    // ==============================

    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}