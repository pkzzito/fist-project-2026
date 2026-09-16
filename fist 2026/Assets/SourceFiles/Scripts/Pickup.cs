using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Effects")]
    public GameObject particleEffectPrefab;

    [Header("Motion Settings")]
    public float rotationSpeed = 100f;
    public float bobbingAmount = 0.1f;
    public float bobbingSpeed = 1f;

    private Vector3 startPosition;
    private float timer;
    private bool coletada = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotação da estrela
        transform.Rotate(
            Vector3.up,
            rotationSpeed * Time.deltaTime,
            Space.World
        );

        // Movimento para cima e para baixo
        timer += Time.deltaTime * bobbingSpeed;

        float newY =
            startPosition.y +
            Mathf.Sin(timer) * bobbingAmount;

        transform.position =
            new Vector3(
                transform.position.x,
                newY,
                transform.position.z
            );
    }

    void OnTriggerEnter(Collider other)
    {
        // Impede que a mesma estrela seja coletada duas vezes
        if (coletada)
            return;

        PlayerScore score =
            other.GetComponentInParent<PlayerScore>();

        if (score != null)
        {
            coletada = true;
            
            // Adiciona uma estrela ao jogador
            score.AddStar();
            
            GameManagerStars.Instance.EstrelaColetada();

            // Efeito de partículas
            if (particleEffectPrefab != null)
            {
                Instantiate(
                    particleEffectPrefab,
                    transform.position,
                    Quaternion.identity
                );
            }

            // Destrói a estrela
            Destroy(gameObject);
        }
    }
}