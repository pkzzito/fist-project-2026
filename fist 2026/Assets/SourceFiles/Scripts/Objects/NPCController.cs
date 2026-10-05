using UnityEngine;

public class NPCController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material material;
    
    [SerializeField] private NPCDataSO NPCData;
    

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
        material.color = NPCData.meshColor;
        transform.localScale *= NPCData.meshSize;
    }
}
