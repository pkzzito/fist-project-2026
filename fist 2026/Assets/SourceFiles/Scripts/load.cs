using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    public string sceneName;
   
    public void Load()
    {
        GameManager.Instance.Load();
    }
}