using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset =
        new Vector3(0, 5, -7);

    public float smoothSpeed = 5f;

    // Velocidade de rotação da câmera
    public float rotationSpeed = 100f;

    private float currentRotation;

    private PlayerController playerController;

    private void Start()
    {
        if (target != null)
        {
            playerController =
                target.GetComponent<PlayerController>();

            // Começa atrás do personagem
            currentRotation = target.eulerAngles.y;
        }
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Procura o PlayerController caso ainda não tenha encontrado
        if (playerController == null)
        {
            playerController =
                target.GetComponent<PlayerController>();
        }

        // ==============================
        // ROTAÇÃO DA CÂMERA
        // ==============================

        if (playerController != null)
        {
            currentRotation +=
                playerController.CameraTurnInput *
                rotationSpeed *
                Time.deltaTime;
        }

        // ==============================
        // POSIÇÃO DA CÂMERA
        // ==============================

        Quaternion rotation =
            Quaternion.Euler(0, currentRotation, 0);

        Vector3 desiredPosition =
            target.position +
            rotation * offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // ==============================
        // CÂMERA OLHANDO PARA O PLAYER
        // ==============================

        transform.LookAt(target);
    }
}