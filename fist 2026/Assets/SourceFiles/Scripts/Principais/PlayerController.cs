using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float speedIncrease = 0.5f;

    [Header("Pulo")]
    public float jumpForce = 7f;

    [Header("Câmera")]
    public Transform cameraTransform;

    private Vector2 moveInput;
    private Rigidbody rb;

    private bool isGrounded;

    public float CameraTurnInput
    {
        get { return moveInput.x; }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Comando de pulo
    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.AddForce(
                Vector3.up * jumpForce,
                ForceMode.Impulse
            );

            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (cameraTransform == null)
            return;

        Vector3 cameraForward = cameraTransform.forward;

        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 movement =
            cameraForward * moveInput.y;

        Vector3 newPosition =
            rb.position +
            movement * speed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }

    // Verifica se o jogador está no chão
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }

    // Aumenta a velocidade quando pega uma moeda
    public void IncreaseSpeed()
    {
        speed += speedIncrease;

        Debug.Log(
            gameObject.name +
            " ficou mais rápido! Velocidade: " +
            speed
        );
    }
}