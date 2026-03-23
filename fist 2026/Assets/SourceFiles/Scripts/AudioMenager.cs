using UnityEngine;

public class AudioMenager : MonoBehaviour
{
  
  public static AudioMenager Instance; 
  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject); // Keep this object across scenes
    }
    else
    {
      Destroy(gameObject); // Ensure only one instance exists
    }
  }
  
  
}
