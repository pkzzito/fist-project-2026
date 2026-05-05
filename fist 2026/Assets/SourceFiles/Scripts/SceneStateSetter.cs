using UnityEngine;

public class SceneStateSetter : MonoBehaviour
{
    public GameStates.GameState state;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetState(state);
        }
        else
        {
            Debug.LogWarning("GameManager não encontrado!");
        }
    }
}